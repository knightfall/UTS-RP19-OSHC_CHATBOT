using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChatbotAPI.EFModels;
using ChatbotAPI.Handlers;
using ChatbotAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {


        //[HttpGet("{id}")]
        //public string ShortResult(int id)
        //{
        //    var Bhd = new DbHandler();

        //    var srj = Bhd.MbsItemAsync(id.ToString());
        //    var x = JsonConvert.SerializeObject(srj, Formatting.Indented);
        //    // Response.Headers.Add("Content-type", "application/json");
        //    return x;
        //}

            /// <summary>
            /// Webhook handler receives POST request
            /// You can generate the JSON deserializer class from quicktype.io; but make sure you change any long? to STRING to avoid unmarshall error
            /// Switch case works based on the intent's display name
            /// </summary>
            /// <returns></returns>
        [Route("/dflow")]
        [HttpPost]
        public async Task<ContentResult> DialogflowHandler()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var model = new WebhookResponseModel();
            
            var reader = new StreamReader(Request.Body, Encoding.UTF8);
            
             var dflow = DflowWebhookRequest.FromJson(await reader.ReadToEndAsync());
            
            switch (dflow.QueryResult.Intent.DisplayName)
            {
                case "Chat.gotNumber-item":
                    model.FulfillmentText = await GetItemPrice(dflow.QueryResult.Parameters.Item.ToString());
                    break;
                case "MBS.getItemPrice":
                    {
                        model.FulfillmentText = await GetItemPrice(dflow.QueryResult.Parameters.Item.ToString());
                        break;
                    }
                case "MBS.getItemPrice-details":
                    {
                        model.FulfillmentText = await GetItemDetails(dflow.QueryResult.Parameters.Item.ToString());
                        break;
                    }
                case "MBS.getItemDetails-fee":
                    {
                        model.FulfillmentText = await GetItemPrice(dflow.QueryResult.Parameters.Item.ToString());
                        break;
                    }
                case "MBS.getItemDetails":
                    {
                        model.FulfillmentText = await GetItemDetails(dflow.QueryResult.Parameters.Item.ToString());
                        break;
                    }
                case "OSHC.GetQuote":
                    {
                        var duratype = dflow.QueryResult.Parameters.Duration.DurationDuration;
                        var duration = dflow.QueryResult.Parameters.Duration.Value;
                        if (duratype == "month" && duration < 61 || duratype == "year" && duration < 6)
                        {
                            model.FulfillmentText = OshcGetQuote(dflow);
                            Console.WriteLine($"{stopwatch.Elapsed.ToString()} has elapsed");
                            Console.WriteLine(model.FulfillmentText);
                        }
                        else
                        {
                            model.FulfillmentText =
                                "Sorry, the max duration I can get a quote for is 5 years or 60 months.\n" +
                                "Please refer to https://immi.homeaffairs.gov.au/visas/getting-a-visa/visa-listing/student-500 for the max duration of student visa.";
                        }

                        break;
                    }
                case "Chat.gotNumber":
                    {
                        model = ChatGotNumber(dflow);

                        break;
                    }
            }

            return Content(model.ToJson(), "application/json");
        }
            /// <summary>
            /// Quote is fetched from db because of the response time limitation.
            /// Check cronjob folder for the cronjob that fetches and save prices automatically
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
        public string OshcGetQuote(DflowWebhookRequest request)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var bq = new BaseQuote();
            var cover = "";
            bq.duration = (int)(request.QueryResult.Parameters.Duration.Value ?? 0);
            if (request.QueryResult.Parameters.Duration.DurationDuration == "year") bq.duration = bq.duration * 12;
            var child = request.QueryResult.Parameters.Child.ToLower();
            var adult = request.QueryResult.Parameters.Partner.ToLower();
            if (child == "no" && adult == "no")
            {
                cover = "Single";
            }
            else if (child == "no" && adult == "yes")
            {

                cover = "Couple";
            }
            else if (child == "yes" && adult == "yes")
            {
                cover = "Family";
            }
            else if (child == "yes" && adult == "no")
            {
                cover = "Single Parent";
            }

            string model = "";
            Console.WriteLine($"Sending to Handler: {stopwatch.Elapsed.ToString()} has elapsed");
            mbsContext mbs = new mbsContext();
            try
            {
                OshcQuote quote = mbs.OshcQuote.Where(e => (e.Covertype == cover) && (e.Duration == bq.duration)).OrderByDescending(a => a.Date)
                    .Select(p => p).FirstOrDefault(); ;
                Console.WriteLine($"OP class: {stopwatch.Elapsed.ToString()} has elapsed");
                model = $"You will need a {cover} cover.\n" +
                              $"For {bq.duration} months, this is the quote I have fetched:\n" +
                              $"1. Allianz OSHC: ${quote.Allianz}AUD \n" +
                              $"2. Medibank OSHC: ${quote.Medibank}AUD \n" +
                              $"3. Nib OSHC: ${quote.Nib}AUD \n" +
                              $"4. AHM OSHC: ${quote.Ahm}AUD \n" +
                              $"**This quote was fetched on {quote.Date.ToString("g", new CultureInfo("en-AU"))} AEST. It will be updated on {quote.Date.AddDays(1).ToString("d", new CultureInfo("en-AU"))} at 6:00 AM AEST";
                stopwatch.Stop();
            }
            catch (Exception e)
            {
                model = "Sorry, but something went wrong. Please try later";
            }

            return model;
        }
        public WebhookResponseModel ChatGotNumber(DflowWebhookRequest dflow)
        {
            var model = new WebhookResponseModel();


            var val = dflow.QueryResult.Parameters.Number;

            if (val == 0)
            {
                model.FulfillmentText = "Sorry, 0 isn't a valid input. Maybe try something else?";
            }

            else
            {
                model.FulfillmentText = $"If you are looking for quotes, try asking me: Get me a quote\n" +
                                        $"or for MBS item number, ask me: what is item {val}";
                model.OutputContexts = dflow.QueryResult.OutputContexts;
            }

            return model;
        }
        async Task<string> GetItemDetails(string itemNumber)
        {

            string result = "";
            mbsContext mb = new mbsContext();
            try
            {
                Schedule msr =
                    await mb.Schedule.SingleAsync(b => b.ItemNum == itemNumber);
                result = $"This is the description I have found in MBS for item number {msr.ItemNum}:\n"
                         + msr.Description.Replace(":", ":\n")
                         + "Type fee to see the scheduled fee of this item";
                result = Regex.Replace(result, @"; \(", "\n ");
            }
            catch (Exception e)
            {
                result =
                    "I am extremely sorry but I couldn't find any information about your desired MBS item number";

            }


            return result;
        }
        async Task<string> GetItemPrice(string itemNumber)
        {
            string result = "";
            mbsContext mb = new mbsContext();
            try
            {
                Schedule msr =
                    await mb.Schedule.SingleAsync(b => b.ItemNum == itemNumber);

                if (msr.Benefit85 > 0)
                {
                    result =
                        $"MBS rate for the item number {msr.ItemNum} is ${msr.ScheduleFee}.\nYou will get back 85% of the amount, which is ${msr.Benefit85}.\n" +
                        $"Type info if you want the description of the item"; ;
                }
                else
                {
                    result =
                        $"MBS rate for the item number {msr.ItemNum} is ${msr.Benefit100}.\nYou will get back 100% of the amount, which is ${msr.Benefit100}.\n" +
                        $"Type info if you want the description of the item";
                }

            }
            catch (Exception e)
            {
                result =
                    "I am extremely sorry but I couldn't find any information about your desired MBS item number";
            }


            return result;
        }
    }
}
