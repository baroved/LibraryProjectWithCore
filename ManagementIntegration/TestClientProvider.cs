using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ServerCoreLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManagementIntegration
{
    public class TestClientProvider
    {
        public TestServer server { get; set; }
        public HttpClient  HttpClient { get; private set; }
        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>()
                .UseSetting("ConnectionStrings:DefaultConnection", "Data Source=(localdb)\\ProjectsV13;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
                
            HttpClient = server.CreateClient();
            
        }
    }
}
