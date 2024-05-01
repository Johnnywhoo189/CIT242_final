var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services
builder.Services.AddHttpClient<ProductsHandler>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5266/"); // Update the base address as per your API
});
builder.Services.AddHttpClient<OrdersHandler>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5266/"); // Update the base address as per your API
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Define routes for Products
app.MapGet("/Products", async (ProductsHandler handler) =>
{
    var products = await handler.GetProductsList();
    return Results.Ok(products);
})
.WithName("GetProducts");

// Define routes for OrderDetails
app.MapGet("/OrderDetails", async (OrdersHandler handler) =>
{
    var orders = await handler.GetOrdersList();
    return Results.Ok(orders);
})
.WithName("GetOrderDetails");

app.Run();
