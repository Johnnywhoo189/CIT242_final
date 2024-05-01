The concept behind this project is an user interface that allows the user to place an order after selecting from a dropdown of products and inputting a desired quantity. It also allows them to view all orders that have been made, including those that have been entered using the PlaceOrder page. 

There are 3 pages to this project. The Index.cshtml.cs page that acts as a home page and allows the user to either place an order or view orders. The PlaceOrder.cshtml.cs page allows the user to select from a dropdown the product they wish to order, view the unit price of said order, and input a quantity to be ordered. Once the order is submitted, they are taken to the PlacedOrders.cshtml.cs page where they can view all orders that have been made, including the one just made. They can also access this page from the Index.cshtml.cs page. 

These pages and the inputs are all handled by the OrdersHandler.cs and the PrductsHandler.cs. 

The ProductsHandler.cs allows the products to be pulled and made into a list that will be a dropdown on the PlaceOrder page. 

The OrdersHandlers.cs page allows the Order Details table to be updated in the Northwind database and acts as a go between when the submit button is clicked and a valid entry is received. 

All data is pulled from the Northwind.db database stored in the FinalApi folder. 
This 

This code has some errors that I have not been able to resolve on my personal machine, preventing it from building properly because it does not recognize the classes I have stored in my Models folder. As you can see in the repository, it is stored in the Pages subfolder along with the pages that would be calling it. If you’re able to run this file and recognize what settings I may have screwed up, please let me know.
