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

      
        Address address2 = new Address("Av. Republica de El Salvador N36-140", "Quito", "Pichincha", "Ecuador");
        Customer customer2 = new Customer("Maria Elena Jacome", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Architectural Rendering Software License", "SW-880", 120.00, 1));
        order2.AddProduct(new Product("Precision Digital Drawing Stylus", "ST-202", 35.00, 2));

        
        Address address3 = new Address("Av. Fray Vicente Solano 120", "Cuenca", "Azuay", "Ecuador");
        Customer customer3 = new Customer("Carlos Andrade", address3);
        Order order3 = new Order(customer3);

        order3.AddProduct(new Product("Handcrafted Cuencan Ceramic Set", "CER-CUEN-04", 28.00, 2));
        order3.AddProduct(new Product("Professional Artist Brush Set", "ART-PN-12", 18.50, 1));

       
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

        
        Console.WriteLine("==================================================");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order3.CalculateTotalCost():F2}");
        Console.WriteLine("==================================================\n");
    }
}