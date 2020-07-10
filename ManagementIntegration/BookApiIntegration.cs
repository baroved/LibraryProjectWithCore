using FluentAssertions;
using Newtonsoft.Json;
using Shared.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementIntegration
{
    public class BookApiIntegration
    {
        [Fact]
        public async Task AddBook()
        {
            Book newBook = new Book
            {
                Name = "Test",
                CopiesInStock = 10,
                PrintDate = DateTime.Now,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg",
                WriterId = 1,
                PublisherId = 2

            };

            using (var client = new TestClientProvider().HttpClient)
            {
                var response = await client.PostAsync("api/Book/AddBook",
    new StringContent(JsonConvert.SerializeObject(newBook), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }

        }

        [Fact]
        public async Task UpdateBook()
        {
            Book updateBook = new Book
            {
                Name = "Test",
                CopiesInStock = 10,
                Description = "dfgdfgdfgdfgdg",
                Price = 49.9,
                ImgUrl = "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg"
            };

            using (var client = new TestClientProvider().HttpClient)
            {
                var response = await client.PostAsync("api/Book/UpdateBook",
    new StringContent(JsonConvert.SerializeObject(updateBook), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }

        }


        [Fact]
        public async Task GetBookById()
        {
            using (var client = new TestClientProvider().HttpClient)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Book/GetBook/1");
                var result = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
                
                Assert.NotNull(result);

            }

        }


    }
}
