using ClientLib.Api;
using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Service
{
    public class HttpService : IHttpService
    {
        #region Properties
        public readonly string baseUrlAddress;
        #endregion

        #region Constructor
        public HttpService()
        {
            baseUrlAddress = "http://localhost:62781/api/";
        }
        #endregion

        #region Methods
        public async Task<R> PostAsync<T, R>(string url, T payload)
        {
            try
            {
                R result = default(R);
                using (HttpClient client = new HttpClient())
                {

                    var json = JsonConvert.SerializeObject(payload);//set object to json
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");


                    var response = await client.PostAsync($"{baseUrlAddress}{url}", stringContent);
                    var responseresult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<R>(responseresult);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<R> PostAsyncJson<T, R>(string url, T payload)
        {
            try
            {
                R result = default(R);
                using (HttpClient client = new HttpClient())
                {

                    var json = JsonConvert.SerializeObject(payload);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{baseUrlAddress}{url}", stringContent);
                    var responseresult = await response.Content.ReadAsStringAsync();
                    JsonConverter[] converters = { new JsonConvertExtension() };
                    result = JsonConvert.DeserializeObject<R>(json, new JsonSerializerSettings() { Converters = converters });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<R> GetAsync<R>(string url)
        {
            try
            {
                R result = default(R);
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.GetAsync($"{baseUrlAddress}{url}");
                    result = JsonConvert.DeserializeObject<R>(await response.Content.ReadAsStringAsync());
                }

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<R> GetAsyncJason<R>(string url)
        {
            try
            {
                R result = default(R);
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.GetAsync($"{baseUrlAddress}{url}");
                    var json = await response.Content.ReadAsStringAsync();
                    JsonConverter[] converters = { new JsonConvertExtension() };//all items need to be create by their type because it is abstract class 
                    result = JsonConvert.DeserializeObject<R>(json, new JsonSerializerSettings() { Converters = converters });

                }

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}

