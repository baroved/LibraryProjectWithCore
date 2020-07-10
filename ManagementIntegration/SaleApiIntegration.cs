using FluentAssertions;
using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementIntegration
{
    public class SaleApiIntegration
    {
        [Fact]
        public async Task GetHistorySales()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Sale/GetHistorySales");
                var result = JsonConvert.DeserializeObject<List<Sale>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }

        [Fact]
        public async Task Buy()
        {
            Sale newSale = new Sale
            {
                Date=DateTime.Now,
                UserId=1,
                CustomerId=2,
                ItemId=3,
                FinalPrice=29.9

            };

            using (var client = new TestClientProvider().HttpClient)
            {
                var response = await client.PostAsync("api/Sale/Buy",
    new StringContent(JsonConvert.SerializeObject(newSale), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }
    }
}
