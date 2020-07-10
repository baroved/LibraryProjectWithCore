using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementIntegration
{
    public class PromotionApiIntegration
    {
        [Fact]
        public async Task GetPromotions()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Promotions/GetPromotions");
                var result = JsonConvert.DeserializeObject<List<Promotion>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }
    }
}
