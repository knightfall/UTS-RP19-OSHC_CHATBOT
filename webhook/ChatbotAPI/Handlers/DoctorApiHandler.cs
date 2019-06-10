using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ChatbotAPI.Models;

namespace ChatbotAPI.Handlers
{
    
    public class DoctorApiHandler
    {
        HttpClient client = new HttpClient();
        public async Task<Location> GetLocationAsync(string address)
        {
            var apiresponse = await client
                .GetAsync(
                    "https://maps.googleapis.com/maps/api/geocode/json?address={address}%2CNSW%2CAU&key=AIzaSyDkuQVy4g8kxwSBwao1hL-uw1bANvbd8rU")
                .Result.Content.ReadAsStringAsync();
            var mapsGeocodeApiResponse = MapsGeocodeApiResponse.FromJson(apiresponse);
            return mapsGeocodeApiResponse.Results[0].Geometry.Location;
        }

        public async Task AllianzDoctorRetrieverAsync(string address)
        {
            Location location = await GetLocationAsync(address);


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://ihfinddoctorapi.agaassistance.com.au/v1/doctors?lat={location.Lat}&lng={location.Lng}"),
                Headers =
                {
                    {HttpRequestHeader.Referer.ToString(),"https://ihfinddoctor.agaassistance.com.au/"},
                    {"Origin","https://ihfinddoctor.agaassistance.com.au" },
                    {HttpRequestHeader.Host.ToString(), "ihfinddoctorapi.agaassistance.com.au" },
                    {HttpRequestHeader.AcceptEncoding.ToString(),"gzip, deflate, br" },
                    {HttpRequestHeader.AcceptLanguage.ToString(),"en-US,en;q=0.5" },
                    {HttpRequestHeader.Connection.ToString(), "keep-alive"},
                    {"DNT","1" },
                    {"Accept", "*/*" },
                    {HttpRequestHeader.UserAgent.ToString(),"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0" }
                }
            };
            var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            var doctorlist = AllianzDoctorApiResponse.FromJson(response);
        }
    }
}
