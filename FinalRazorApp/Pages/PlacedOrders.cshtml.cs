using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalRazorApp.Services;
using FinalRazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlacedOrdersModel : PageModel
{
    private readonly OrdersHandler _ordersHandler;

    public List<OrderDetails> Orders { get; set; }

    public PlacedOrdersModel(OrdersHandler ordersHandler)
    {
        _ordersHandler = ordersHandler;
    }

    public async Task OnGetAsync()
    {
        Orders = await _ordersHandler.GetOrdersAsync();
    }
}
