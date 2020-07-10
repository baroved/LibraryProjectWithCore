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
    public class ItemApiIntegration
    {
        [Fact]
        public async Task GetAllItems()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/items/Items");
                var result = JsonConvert.DeserializeObject<List<AbstractItem>>(await response.Content.ReadAsStringAsync());

                Assert.NotNull(result);

            }

        }

        [Fact]
        public async Task GetItemById()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Item/1");
                var result = JsonConvert.DeserializeObject<AbstractItem>(await response.Content.ReadAsStringAsync());

                Assert.NotNull(result);

            }

        }


        [Fact]
        public async Task GetItemsByPublisherDiscount()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Item/ItemsByPublisherDiscount/keshet");
                var result = JsonConvert.DeserializeObject<List<AbstractItem>>(await response.Content.ReadAsStringAsync());

                Assert.NotNull(result);

            }

        }

        [Fact]
        public async Task GetItemsByWriterDiscount()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Item/ItemsByWriterDiscount/Joseph Elijah");
                var result = JsonConvert.DeserializeObject<List<AbstractItem>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }


        [Fact]
        public async Task GetItemsByGenreDiscount()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Item/ItemsByGenreDiscount/drama");
                var result = JsonConvert.DeserializeObject<List<AbstractItem>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }


        [Fact]
        public async Task GetItemsByTypeDiscount()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Item/ItemsByTypeDiscount/book");
                var result = JsonConvert.DeserializeObject<List<AbstractItem>>(await response.Content.ReadAsStringAsync());

                Assert.True(result.Any());

            }

        }
    }
}
