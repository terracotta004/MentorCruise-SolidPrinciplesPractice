// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

var customer = new Customer { Name = "Saeed", IsVip = true };
var order = new Order { Customer = customer, Item = "Coffee", Price = 2.50m };

DiscountService discountService;

switch (customer.IsVip)
{
    case true:
        Console.WriteLine("Applying VIP discount.");
        discountService = new DiscountService(new PremiumDiscount());
        break;
    case false:
        Console.WriteLine("No discount applied.");
        discountService = new DiscountService(new RegularDiscount());
        break;
}

var finalAmount = discountService.ApplyDiscount(order.Price);

IPaymentMethod paymentMethod = new CreditCardPayment();
IReceiptPrinter receiptPrinter = new ConsoleReceiptPrinter();

var paymentProcessor = new PaymentProcessor(paymentMethod);
var receiptService = new ReceiptService(receiptPrinter);

paymentProcessor.Process(finalAmount);
receiptService.PrintReceipt(order);
