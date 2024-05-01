using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalRazorApp.Services;
using FinalRazorApp.Models;

public class PlaceOrderModel : PageModel
{
    private readonly OrdersHandler _ordersHandler;
    private readonly ProductsHandler _productsHandler;

    [BindProperty]
    public string SelectedProductId { get; set; }

    [BindProperty]
    public decimal UnitPrice { get; set; }

    [BindProperty]
    public short Quantity { get; set; }

    public List<Products> Products { get; set; }

    public PlaceOrderModel(OrdersHandler ordersHandler, ProductsHandler productsHandler)
    {
        _ordersHandler = ordersHandler;
        _productsHandler = productsHandler;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Products = await _productsHandler.GetProductsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var orderDetails = new OrderDetails
        {
            ProductId = SelectedProductId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };

        await _ordersHandler.SaveOrderInfo(orderDetails); 
        return RedirectToPage("./PlacedOrders");
    }
}
