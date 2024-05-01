using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using FinalRazorApp.Models; // Replace 'YourNamespace' with the actual namespace of your project

namespace FinalRazorApp.Services
{
public class OrdersHandler
{
private readonly HttpClient _client;
public OrdersHandler(HttpClient client)
{
_client = client;
}
public async Task<IEnumerable<OrderDetails>> GetOrdersList()
{
var response = await _client.GetAsync("http://localhost:5266/OrderDetails");
response.EnsureSuccessStatusCode();
var stream = await response.Content.ReadAsStreamAsync();
return await JsonSerializer.DeserializeAsync<IEnumerable<OrderDetails>>(stream);
}
public async Task SaveOrderInfo(OrderDetails orderDetails)
{
var json = JsonSerializer.Serialize(orderDetails);
var content = new StringContent(json, System.Text.Encoding.UTF8,"application/json");
var response = await _client.PostAsync("http://localhost:5266/OrderDetails", content);
response.EnsureSuccessStatusCode();
}
}
}