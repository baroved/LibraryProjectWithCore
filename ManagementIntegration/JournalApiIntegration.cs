using FluentAssertions;
using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementIntegration
{
    public class JournalApiIntegration
    {
        [Fact]
        public async Task GetJournalById()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Journal/GetJournal/1");
                var result = JsonConvert.DeserializeObject<Journal>(await response.Content.ReadAsStringAsync());

                Assert.NotNull(result);

            }

        }

        [Fact]
        public async Task AddJournal()
        {
            Journal newJournal = new Journal
            {
                Name = "Test",
                CopiesInStock = 10,
                PrintDate = DateTime.Now,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                EditionId = 1,
                PublisherId = 2

            };

            using (var client = new TestClientProvider().HttpClient)
            {
                var response = await client.PostAsync("api/Journal/AddJournal",
    new StringContent(JsonConvert.SerializeObject(newJournal), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }

        }

        [Fact]
        public async Task UpdateJournal()
        {
            Journal Journal = new Journal
            {
                Name = "Test",
                CopiesInStock = 10,
                PrintDate = DateTime.Now,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
            };

            using (var client = new TestClientProvider().HttpClient)
            {
                var response = await client.PostAsync("api/Journal/UpdateJournal",
    new StringContent(JsonConvert.SerializeObject(Journal), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }

        }
    }
}
