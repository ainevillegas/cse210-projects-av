Console.WriteLine("ONLINE ORDERING PROGRAM");
Console.WriteLine("=======================");

// First customer lives in the USA.
Address address1 = new Address(
    "125 Oak Street",
    "Boise",
    "Idaho",
    "USA");

Customer customer1 = new Customer(
    "Emma Johnson",
    address1);

Product product1 = new Product(
    "Wireless Mouse",
    "WM-1001",
    24.99,
    2);

Product product2 = new Product(
    "Mechanical Keyboard",
    "MK-2035",
    59.99,
    1);

Product product3 = new Product(
    "USB-C Cable",
    "UC-3012",
    9.50,
    3);

Order order1 = new Order(customer1);

order1.AddProduct(product1);
order1.AddProduct(product2);
order1.AddProduct(product3);

// Second customer lives outside the USA.
Address address2 = new Address(
    "45 Sampaguita Street",
    "Makati City",
    "Metro Manila",
    "Philippines");

Customer customer2 = new Customer(
    "Juan Dela Cruz",
    address2);

Product product4 = new Product(
    "Laptop Stand",
    "LS-4050",
    32.75,
    1);

Product product5 = new Product(
    "Noise-Canceling Headphones",
    "NH-5075",
    89.99,
    2);

Order order2 = new Order(customer2);

order2.AddProduct(product4);
order2.AddProduct(product5);

// Display the first order.
Console.WriteLine();
Console.WriteLine("ORDER 1");
Console.WriteLine("-------");

Console.WriteLine("Packing Label:");
Console.WriteLine(order1.GetPackingLabel());

Console.WriteLine();
Console.WriteLine("Shipping Label:");
Console.WriteLine(order1.GetShippingLabel());

Console.WriteLine();
Console.WriteLine(
    $"Total Price: ${order1.CalculateTotalPrice():F2}");

// Display the second order.
Console.WriteLine();
Console.WriteLine("=======================");
Console.WriteLine("ORDER 2");
Console.WriteLine("-------");

Console.WriteLine("Packing Label:");
Console.WriteLine(order2.GetPackingLabel());

Console.WriteLine();
Console.WriteLine("Shipping Label:");
Console.WriteLine(order2.GetShippingLabel());

Console.WriteLine();
Console.WriteLine(
    $"Total Price: ${order2.CalculateTotalPrice():F2}");