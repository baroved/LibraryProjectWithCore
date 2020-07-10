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
    public class PublisherApiIntegration
    {
        [Fact]
        public async Task GetAllPublishers()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Publishers/GetPublishers");
                var result = JsonConvert.DeserializeObject<List<Publisher>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }
    }
}
