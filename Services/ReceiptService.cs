public class ConsoleReceiptPrinter : IReceiptPrinter
{
    public void Print(Order order)
    {
        Console.WriteLine("----- Receipt -----");
        Console.WriteLine($"Item: {order.Item}");
        Console.WriteLine($"Price: {order.Price:C}");
        if (order.Customer != null)
        {
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"VIP Status: {(order.Customer.IsVip ? "Yes" : "No")}");
        }
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
            } : null
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