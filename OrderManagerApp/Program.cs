using System;
using System.Collections.Generic;

/// <summary> 
/// Type of customer used to determine applicable discount. 
/// </summary> 
public enum CustomerType
{
    Regular,
    Premium
}

/// <summary> 
/// Represents all data required to process an order. 
/// </summary> 
public class OrderData
{
    public string CustomerName { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public CustomerType CustomerType { get; set; }
}
/// <summary> 
/// Manages order processing and storage. 
/// </summary> 
public class OrderManager
{
    private List<string> orderList = new List<string>();
    const double PremiumDiscount = 0.1;
    const double RegularDiscount = 0.05;


    /// <summary> 
    /// Validates and processes an order, then prints summary and saves it. 
    /// </summary> 
    /// <param name="order">Order data object</param> 
    public void ProcessOrder(OrderData order)
    {
        if (!IsValid(order))
        {
            Console.WriteLine("Invalid order.");
            return;
        }

        double total = CalculateTotal(order);
        PrintSummary(order, total);
        SaveOrder(order);
    }

    /// <summary> 
    /// Checks whether the order data is valid. 
    /// </summary> 
    private bool IsValid(OrderData order)
    {
        return !string.IsNullOrEmpty(order.CustomerName) &&
        !string.IsNullOrEmpty(order.ProductId);
    }

    /// <summary> 
    /// Calculates total price after applying customer discount. 
    /// </summary> 
    private double CalculateTotal(OrderData order)
    {
        double discount = GetDiscount(order.CustomerType);
        double subtotal = order.UnitPrice * order.Quantity;
        return subtotal - (subtotal * discount);
    }

    /// <summary> 
    /// Gets discount percentage based on customer type. 
    /// </summary> 
    private double GetDiscount(CustomerType customerType)
    {
        switch (customerType)
        {
            case CustomerType.Premium:
                return PremiumDiscount;
            case CustomerType.Regular:
                return RegularDiscount;
            default:
                return 0;
        }
    }

    /// <summary> 
    /// Prints a summary of the order to the console. 
    /// </summary> 
    private void PrintSummary(OrderData order, double total)
    {
        Console.WriteLine("Order Summary:");
        Console.WriteLine($"Customer: {order.CustomerName}");
        Console.WriteLine($"Product: {order.ProductId}");
        Console.WriteLine($"Total: {total}");
    }
    /// <summary> 
    /// Saves the order in memory using a basic unique key. 
    /// </summary> 
    private void SaveOrder(OrderData order)
    {
        string key = order.CustomerName + order.ProductId;
        orderList.Add(key);
    }
    /// <summary> 
    /// Displays all saved orders. 
    /// </summary> 
    public void ShowOrders()
    {
        foreach (string order in orderList)
        {
            Console.WriteLine(order);
        }
    }
}