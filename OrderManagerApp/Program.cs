using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        OrderManager manager = new OrderManager();
        manager.ProcOr("Ahmad", "P001", 3, 100.0, "Premium");
        manager.ProcOr("Lina", "P002", 1, 50.0, "Regular");

        manager.ShowOrders();
    }
}

public class OrderManager
{
    private List<string> orderList = new List<string>();

    public void ProcOr(string customerName, string productId, int quantity, double price, string
customerType)
    {
        if (customerName == "" || productId == "")
        {
            Console.WriteLine("Invalid order.");
            return;
        }

        // premium gets 10%, regular gets 5% 
        double discount = 0;
        if (customerType == "Premium")
        {
            discount = 0.1;
        }
        else if (customerType == "Regular")
        {
            discount = 0.05;
        }

        double total = price * quantity;
        total = total - (total * discount);

        Console.WriteLine("Order Summary:");
        Console.WriteLine("Customer: " + customerName);
        Console.WriteLine("Product: " + productId);
        Console.WriteLine("Total: " + total);

        orderList.Add(customerName + productId);
    }

    public void ShowOrders()
    {
        foreach (string x in orderList)
        {
            Console.WriteLine(x);
        }
    }
}