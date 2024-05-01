using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using FinalRazorApp.Models; // Replace 'YourNamespace' with the actual namespace of your project

namespace FinalRazorApp.Services
{
    public class ProductsHandler
    {
        private readonly HttpClient _client;

        public ProductsHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Products>> GetProductsList()
        {
            var response = await _client.GetAsync("http://localhost:5266/Products");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Products>>(stream);
        }

        // If you need additional methods for handling product-related operations, you can add them here
    }
}
