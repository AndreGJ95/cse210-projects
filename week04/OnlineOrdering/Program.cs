using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("Av. Victor Emilio Estrada 412", "Guayaquil", "Guayas", "Ecuador");
        Customer customer1 = new Customer("Juan Carlos Mendoza", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Lojan Gourmet Coffee Beans 500g", "EC-CAF-01", 12.50, 3));
        order1.AddProduct(new Product("Authentic Toquilla Straw Hat", "EC-HAT-99", 65.00, 1));
        order1.AddProduct(new Product("Fine Aroma Chocolate Box (70% Cacao)", "EC-CHOC-05", 8.00, 2));

        
        Address address2 = new Address("710 N 2nd E", "Rexburg", "ID", "USA");
        Customer customer2 = new Customer("Alex Rivera", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Ergonomic Keyboard", "KB-902", 45.00, 1));
        order2.AddProduct(new Product("Wireless Mouse", "MS-104", 18.50, 2));
        order2.AddProduct(new Product("USB-C Desk Cable", "CB-301", 8.99, 3));

        
        Console.WriteLine("==================================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("==================================================\n");

        
        Console.WriteLine("==================================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("==================================================\n");
    }
}