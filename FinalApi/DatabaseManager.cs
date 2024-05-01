using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public class DatabaseManager
{
    public static List<Product> GetProducts()
    {
        var products = new List<Product>();
        string connectionString = "Data Source=Northwind.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"SELECT ProductId, ProductName FROM Products;";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductId = reader["ProductId"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                    };
                    products.Add(product);
                }
            }
        }
        return products;
    }
    public static void CreateProduct(Product product)
    {
        string connectionString = "Data Source=Northwind.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"INSERT INTO Products (ProductId, ProductName) VALUES (@ProductId, @ProductName);";
            
            command.Parameters.AddWithValue("@ProductId", product.ProductId);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            
            command.ExecuteNonQuery();
        }
    }
}