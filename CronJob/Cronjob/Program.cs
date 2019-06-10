using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cronjob
{
    class Program
    {
        Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            Program pp = new Program();
            //pp.stopwatch.Start();
            //Console.WriteLine("Hello World!");

            //StreamReader file = File.OpenText(@"../../../australian_postcodes.json");
            //string jsonString = file.ReadToEnd();
            //var postcodeGeo = PostcodeGeo.FromJson(jsonString);

            ////var xd= postcodeGeo.SelectMany((pp => postcodeGeo.))
            //var tt = postcodeGeo.Find(p => p.Locality.Contains("Mortdale"));

            //  var xd = pp.OshcGetQuote();

            var context = new mbsContext();
           // context.Database.ExecuteSqlCommand("truncate mbs.OshcQuote;");
            foreach (var v in Enum.GetNames(typeof(types)))
            {
                for (int i = 1; i < 61; i++)
                {
                    // pp.stopwatch.Start();
                    int xd = pp.OshcGetQuote(v, i);
                    Console.WriteLine($"Month {i}, Cover {v} ::{pp.stopwatch.Elapsed.ToString()} has elapsed");

                    Thread.Sleep(1500);
                    //  pp.stopwatch.Reset();
                }
                Console.WriteLine(v);
            }

            Console.WriteLine($"Finished at {pp.stopwatch.Elapsed.ToString()} has elapsed");
            pp.stopwatch.Stop();

            Environment.Exit(0);
        }

        public enum types
        {
            Single,
            Couple,
            Family,
            Parent
        }
        public int OshcGetQuote(string Covertype, int duration)
        {
            


            var bq = new BaseQuote
            {
                duration = duration
            };

            var op = new OshcQuote
            {
                Date = DateTime.UtcNow.AddHours(10),
                Duration = duration
            };
            // Generating ID using covertype, duration and datetime
            op.Id = Covertype +"-" +duration +"-"+ op.Date.ToString("ddMMyyHH");
            if (Covertype=="Single")
            {
                bq.Allianzadult = "1";
                bq.Allianzchild = "0";
                bq.NibCoverType = "Single";
                bq.medibankCoverType = "S";
                op.Covertype = "Single";
            }
            else if (Covertype=="Couple")
            {
                bq.Allianzadult = "2";
                bq.Allianzchild = "0";
                bq.NibCoverType = "Couple";
                bq.medibankCoverType = "D";
                op.Covertype = "Couple";
            }
            else if (Covertype=="Family")
            {
                bq.Allianzadult = "2";
                bq.Allianzchild = "1";
                bq.NibCoverType = "Family";
                bq.medibankCoverType = "F";
                op.Covertype = "Family";
            }
            else if (Covertype=="Parent")
            {
                bq.Allianzadult = "1";
                bq.Allianzchild = "1";
                bq.NibCoverType = "Family";
                bq.medibankCoverType = "P";
                op.Covertype = "Single Parent";
            }

          //  Console.WriteLine($"Sending to Handler: {stopwatch.Elapsed.ToString()} has elapsed");

            var oshcApiHandler = new OshcApiHandler();

            //Parallel request to reduce processing time
            //Might not work in linux based installations. Check before deploying
            //Doesn't work in 5 dollar DigitalOcean droplets
            Parallel.Invoke(
                async () =>op.Allianz = await oshcApiHandler.AllianzQuoteHandler(bq),
                async () => op.Nib = await oshcApiHandler.NibApiHandler(bq),
                async () => op.Ahm = await oshcApiHandler.AhmQuoteHandler(bq),
                async () => op.Medibank = await oshcApiHandler.MedibankQuoteHandler(bq)
            );
            
            
            var context = new mbsContext();

           

            context.OshcQuote.Add(op);
           context.SaveChanges();
           Console.WriteLine($"OP class: {stopwatch.Elapsed.ToString()} has elapsed");
            //stopwatch.Stop();
            return 1;
        }
    }

}
