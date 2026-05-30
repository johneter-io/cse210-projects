using System;
class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("456 Helvit Road", "Montreal", "AAA", "Canada");

        Customer customer1 = new Customer("Avril Mars", addr1);
        Customer customer2 = new Customer("Josh Olivier", addr2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("JavaScript Programming Book", "B101", 12.99, 2));
        order1.AddProduct(new Product("Mechanical Pen", "P233", 1.99, 5));
        order1.AddProduct(new Product("Notebook", "N451", 8.99, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Wireless Mouse", "M978", 25.99, 1));
        order2.AddProduct(new Product("USB-C Hub", "U248", 34.99, 2));

        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal : ${order1.GetTotalCost():0.00}");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal : ${order2.GetTotalCost():0.00}");
        Console.WriteLine();
    }
}