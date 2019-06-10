using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChatbotAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace ChatbotAPI.Handlers
{
    public class OshcApiHandler
    {
      // private HttpClient client = new HttpClient();
      private readonly IHttpClientFactory _clientFactory;
        private readonly ServiceProvider services = new ServiceCollection().AddHttpClient().BuildServiceProvider();

        public OshcApiHandler()
        {
            _clientFactory = services.GetRequiredService<IHttpClientFactory>();
        }

        public async Task<string> NibApiHandler(BaseQuote bq)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("NIB Start");
            stopwatch.Start();
            var startDate = DateTime.Now.ToString("dd-MMM-yyyy");
            var endDate = DateTime.Now.AddMonths(bq.duration).AddDays(-1).ToString("dd-MMM-yyyy");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://www.nib.com.au/overseas-students/join/api/price?startDate={startDate}&endDate={endDate}&scale={bq.NibCoverType}"),
                Headers =
                {
                    {HttpRequestHeader.Referer.ToString(), "https://www.nib.com.au/overseas-students"},
                    {"Origin", "https://allianzassistancehealth.com.au"},
                    {HttpRequestHeader.AcceptEncoding.ToString(), "gzip, deflate, br"},
                    {HttpRequestHeader.AcceptLanguage.ToString(), "en-US,en;q=0.5"},
                    {HttpRequestHeader.ContentType.ToString(), "application/json, text/plain, */*"},
                    {"DNT", "1"},
                    {
                        HttpRequestHeader.UserAgent.ToString(),
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0"
                    }
                }
            };
            var client = _clientFactory.CreateClient();
            var t = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            Console.WriteLine($"NIB: {stopwatch.Elapsed.ToString()} has elapsed");
            stopwatch.Stop();
            return t;
        }

        /// <summary>
        ///     FundID =17
        ///     single = S; Single Parent =P
        ///     Family = F; Couple=D
        /// </summary>
        /// <returns></returns>
        public async Task<string> MedibankQuoteHandler(BaseQuote bq)
        {
            Console.WriteLine("Medibank Start");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var startdate = DateTime.Now.ToString("d", new CultureInfo("en-AU"));
            var enddate = DateTime.Now.AddMonths(bq.duration).AddDays(-1).ToString("d", new CultureInfo("en-AU"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://www.members.medibankoshc.com.au/api/quotes/new?startDate={startdate}&visaEndDate={enddate}&fundId=17&scope={bq.medibankCoverType}&courseCompletionDate={enddate}"),
                Headers =
                {
                    {HttpRequestHeader.Referer.ToString(), "https://www.medibankoshc.com.au/get-a-quote/"},
                    {"Origin", "https://www.medibankoshc.com.au"},
                    {
                        HttpRequestHeader.CacheControl.ToString(),
                        "no-store, no-cache, must-revalidate, proxy-revalidate"
                    },
                    {HttpRequestHeader.AcceptEncoding.ToString(), "gzip, deflate, br"},
                    {HttpRequestHeader.AcceptLanguage.ToString(), "en-US,en;q=0.5"},
                    {"pragma", "no-cache"},
                    {HttpRequestHeader.ContentType.ToString(), "application/json"},
                    {"x-api-key", "WeDmY4YdhyhLxvVrKEiO6OvLod7kiin5HaOBTjxe"},
                    {"DNT", "1"},
                    {
                        HttpRequestHeader.UserAgent.ToString(),
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36"
                    }
                }
            };
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            var t = JObject.Parse(response)["amount"].ToString();
            Console.WriteLine($"Medibank: {stopwatch.Elapsed.ToString()} has elapsed");
            stopwatch.Stop();
            return t;
        }

        /// <summary>
        ///     FundID =16
        ///     single = S; Single Parent =P
        ///     Family = F; Couple=D
        /// </summary>
        /// <returns></returns>
        public async Task<string> AhmQuoteHandler(BaseQuote bq)
        {
            Console.WriteLine("AHM Start");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var startdate = DateTime.Now.ToString("d", new CultureInfo("en-AU"));
            var enddate = DateTime.Now.AddMonths(bq.duration).AddDays(-1).ToString("d", new CultureInfo("en-AU"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://www.members.ahmoshc.com.au/api/quotes/new?startDate={startdate}&visaEndDate={enddate}&fundId=16&scope={bq.medibankCoverType}&courseCompletionDate={enddate}"),
                Headers =
                {
                    {HttpRequestHeader.Referer.ToString(), "https://www.ahmoshc.com.au/get-a-quote/"},
                    {"Origin", "https://www.ahmoshc.com.au"},
                    {
                        HttpRequestHeader.CacheControl.ToString(),
                        "no-store, no-cache, must-revalidate, proxy-revalidate"
                    },
                    {HttpRequestHeader.AcceptEncoding.ToString(), "gzip, deflate, br"},
                    {HttpRequestHeader.AcceptLanguage.ToString(), "en-US,en;q=0.5"},
                    {"pragma", "no-cache"},
                    {HttpRequestHeader.ContentType.ToString(), "application/json"},
                    {"x-api-key", "WeDmY4YdhyhLxvVrKEiO6OvLod7kiin5HaOBTjxe"},
                    {"DNT", "1"},
                    {
                        HttpRequestHeader.UserAgent.ToString(),
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36"
                    }
                }
            };

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            Console.WriteLine($"Ahm: {stopwatch.Elapsed.ToString()} has elapsed");
            stopwatch.Stop();
            return JObject.Parse(response)["amount"].ToString();
        }

        public async Task<string> AllianzQuoteHandler(BaseQuote bq)
        {
            Console.WriteLine("Allianz Start");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var startDate = DateTime.Now.ToString("yyyy-MM-dd");
            var endDate = DateTime.Now.AddMonths(bq.duration).AddDays(-1).ToString("yyyy-MM-dd");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://ihealthapi.agaassistance.com.au/v1/quote?Adults={bq.Allianzadult}&Dependants={bq.Allianzchild}&StartDate={startDate}&EndDate={endDate}"),
                Headers =
                {
                    {
                        HttpRequestHeader.Referer.ToString(),
                        "https://allianzassistancehealth.com.au/oneweb/angular/iHealth/index.html?appKey=troy-1176533814&&"
                    },
                    {"Origin", "https://allianzassistancehealth.com.au"},
                    {HttpRequestHeader.AcceptEncoding.ToString(), "gzip, deflate, br"},
                    {HttpRequestHeader.AcceptLanguage.ToString(), "en-US,en;q=0.5"},
                    {"timestamp", DateTime.Now.Ticks.ToString()},
                    {HttpRequestHeader.ContentType.ToString(), "application/json"},
                    {"X-Requested-With", "XMLHttpRequest"},
                    {"DNT", "1"},
                    {"Accept", "application/json, text/plain, */*"},
                    {
                        HttpRequestHeader.UserAgent.ToString(),
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0"
                    }
                }
            };
           var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            var tt = JObject.Parse(response)["premium"]["amount"].ToString();
            Console.WriteLine($"Allianz: {stopwatch.Elapsed.ToString()} has elapsed");
            stopwatch.Stop();
            return tt;
        }
        /// <summary>
        /// CBHS's OSHC page contains the session ID inline.
        /// Session ID is needed to send request to the pricing API.
        /// Instead of reusing session ID, getting the session ID programmatically.
        /// Regex is slower in dotnet. 
        /// </summary>
        /// <returns></returns>
        //private async Task<string> CbhsSessionID()
        //{
        //    Regex rr = new Regex("SID = \".*\";");
        //    var url = "https://overseas.cbhscorporatehealth.com.au/oshc";
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://overseas.cbhscorporatehealth.com.au/oshc"),
        //        Headers =
        //        {
        //            {HttpRequestHeader.Host.ToString(), "overseas.cbhscorporatehealth.com.au" },
        //            {HttpRequestHeader.AcceptEncoding.ToString(),"gzip, deflate, br" },
        //            {HttpRequestHeader.AcceptLanguage.ToString(),"en-US,en;q=0.9,bn;q=0.8" },
        //            {HttpRequestHeader.ContentType.ToString(),"application/json"},
        //            {"DNT","1" },
        //            {"Upgrade-Insecure-Requests", "1" },
        //            {"Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3" },
        //            {HttpRequestHeader.UserAgent.ToString(),"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0" }
        //        }
        //    };
        //   // var response = await client.SendAsync(request);
        //   // var content = GZipDecompress(await response.Content.ReadAsStreamAsync());
        //    string match = rr.Match(content).Value.ToString();
        //    match = match.Remove(0, match.IndexOf('\"') + 1);
        //    match = match.Remove(match.Length - 2, 2);
        //    return match;
        //}

        //private static async Task CbhsApiRequest()
        //{
        //    HttpClient client = new HttpClient();

        //    var values = new Dictionary<string, string>
        //    {
        //        {"sid","{15e30a38-b318-48b8-bdc7-4417dcd25dc2}" },
        //        {"applicationJSON","{\"hasLoadedStep2b\":false,\"hasLoadedStep2c\":false,\"hasLoadedStep2aOnce\":true,\"hasLoadedStep2bOnce\":false,\"hasLoadedStep2cOnce\":false,\"hasLoadedStep2dOnce\":false,\"hasAttemptedTokenRetrievalOnce\":false,\"hasAttemptedPaymentOnce\":false,\"hasAttemptedSFDCSyncOnce\":false,\"hasCompletedApplication\":false,\"curMemNum\":\"\",\"curCoverage\":\"\",\"curFund\":\"\",\"sessionId\":\"{15e30a38-b318-48b8-bdc7-4417dcd25dc2}\",\"selectedState\":\"NSW\",\"coverType\":\"Single\",\"myself\":{\"DOB\":\"1994-01-01T00:00:00+11:00\"},\"partner\":{},\"numOfChild\":0,\"visa\":\"500 Student Visa\",\"passportCountry\":\"BANGLADESH\",\"childrenJSON\":{\"numOfChild\":0},\"prevPageStep\":1,\"currentPageStep\":\"2a\"}" },
        //        {"action","retrievePricing" }
        //    };

        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri("https://overseas.cbhscorporatehealth.com.au/oshccontroller"),
        //        Headers =
        //        {
        //            {HttpRequestHeader.Referer.ToString(),"https://overseas.cbhscorporatehealth.com.au/oshc" },
        //            {HttpRequestHeader.AcceptEncoding.ToString(),"gzip, deflate, br" },
        //            {HttpRequestHeader.AcceptLanguage.ToString(),"en-US,en;q=0.5" },
        //            {HttpRequestHeader.ContentType.ToString(),"application/x-www-form-urlencoded"},
        //            {"X-Requested-With", "XMLHttpRequest" },
        //            {"Accept", "application/json, text/javascript, */*; q=0.01" },
        //            {HttpRequestHeader.UserAgent.ToString(),"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0" }
        //        },
        //        Content = new FormUrlEncodedContent(values)

        //    };


        //    var respone = await client.SendAsync(request);
        //    string t;
        //    var content = await respone.Content.ReadAsStreamAsync();

        //    t = GZipDecompress(content);


        //    int x = 0;
        //}

        /// <summary>
        ///     CBHS sends gzipped response from its API.
        ///     this method unzips gzipped stream
        /// </summary>
        /// <param name="content"></param>
        /// <returns>Strings</returns>
        private static string GZipDecompress(Stream content)
        {
            using (var decompressionStream = new GZipStream(content, CompressionMode.Decompress))
            {
                using (var sr = new StreamReader(decompressionStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}