using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementIntegration
{
    public class CustomerApiIntegration
    {
        [Fact]
        public async Task GetCustomers()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Customers/Customers/");
                var result = JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());

                Assert.NotNull(result);

            }

        }
    }
}
