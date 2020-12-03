using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MCloudDNSCF
{
    static class Program
    {
        private static PacketInfo _pi;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            IConfiguration config = builder.Build();

            _pi = new PacketInfo();
            _pi.Type = config["CF_DNS_TYPE"];
            _pi.Name = config["CF_DNS_NAME"];
            _pi.Content = GetPublicIPAddress(config["GET_IP_ENDPOINT"]);
            _pi.TTL = 3600;
            _pi.Proxied = false;

            UpdateDNS(_pi, config);
        }

        private static void UpdateDNS(PacketInfo packet, IConfiguration config)
        {
            Console.WriteLine(packet.SerializeData());
            var content = new StringContent(packet.SerializeData(), System.Text.Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> update = Task.Run(() => SendUpdatedDNS(config["CF_API"] + config["CF_ZONE_ID"] + "/dns_records/" + config["CF_DNS_ID"], content, config["CF_API_KEY"]));
            var result = update.Result;
            Console.WriteLine(result);
        }

        private static string GetPublicIPAddress(string endpoint)
        {
            return new WebClient().DownloadString(endpoint);
        }

        private static async Task<HttpResponseMessage> SendUpdatedDNS(this string requestUri, HttpContent content, string api_key)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api_key);
            return await client.PutAsync(requestUri, content);
        }
    }
}
