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
    public class EditionApiIntegration
    {
        [Fact]
        public async Task GetAllEditions()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Edition/GetAllEditions");
                var result = JsonConvert.DeserializeObject<List<Edition>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }
    }
}
