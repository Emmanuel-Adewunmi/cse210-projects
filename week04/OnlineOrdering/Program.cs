using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First Address, Customer, and Order
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("T-shirt", "TS001", 19.99, 2));
        order1.AddProduct(new Product("Jeans", "JN045", 39.99, 1));

        // Second Address, Customer, and Order
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alice Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Book", "BK007", 12.50, 3));
        order2.AddProduct(new Product("Notebook", "NB012", 4.75, 5));
        order2.AddProduct(new Product("Pen", "PN999", 1.20, 10));

        // Display Order 1 details
        Console.WriteLine("----- Order 1 -----");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine();

        // Display Order 2 details
        Console.WriteLine("----- Order 2 -----");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
    }
}
