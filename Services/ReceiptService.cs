public class ConsoleReceiptPrinter : IReceiptPrinter
{
    public void Print(Order order)
    {
        Console.WriteLine("----- Receipt -----");
        Console.WriteLine($"Item: {order.Item}");
        Console.WriteLine($"Original Price: {order.Price:C}");
        if (order.Customer != null)
        {
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"VIP Status: {(order.Customer.IsVip ? "Yes" : "No")}");
        }
        Console.WriteLine($"Final Amount: {order.FinalAmount:C}");
        Console.WriteLine("-------------------");
    }
}

public class JsonReceiptPrinter : IReceiptPrinter
{
    public void Print(Order order)
    {
        var receipt = new
        {
            Item = order.Item,
            Price = order.Price,
            Customer = order.Customer != null ? new
            {
                Name = order.Customer.Name,
                IsVip = order.Customer.IsVip
            } : null,
            FinalAmount = order.FinalAmount
        };

        string jsonReceipt = System.Text.Json.JsonSerializer.Serialize(receipt, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonReceipt);
    }
}

public class ReceiptService
{
    private readonly IReceiptPrinter _receiptPrinter;

    public ReceiptService(IReceiptPrinter receiptPrinter)
    {
        _receiptPrinter = receiptPrinter;
    }

    public void PrintReceipt(Order order)
    {
        _receiptPrinter.Print(order);
    }
}

// This file demonstrates SOLID principles by cleanly separating responsibilities
// and relying on flexible abstractions. Single Responsibility is followed 
// because each receipt printer class—ConsoleReceiptPrinter and 
// JsonReceiptPrinter—handles only its own formatting and output logic, 
// while ReceiptService is responsible solely for coordinating the printing
// process. The Open/Closed Principle is achieved through the shared 
// IReceiptPrinter interface, which allows new output formats (PDF, HTML, 
// email, etc.) to be added without modifying existing classes. 
// Liskov Substitution is honored because any implementation of IReceiptPrinter 
// can be injected into ReceiptService without breaking expected behavior. 
// Interface Segregation appears in keeping IReceiptPrinter small and 
// specific to printing, so implementations aren’t forced to support 
// irrelevant methods. Finally, Dependency Inversion is clearly implemented 
// because ReceiptService depends on the abstraction (IReceiptPrinter) rather 
// than any concrete printer, resulting in a highly modular, extensible, 
// and testable design.