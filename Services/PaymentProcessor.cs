public class CreditCardPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        // Logic to process credit card payment
        Console.WriteLine($"Processing credit card payment of {amount:C} using credit card.");
    }
}

public class PayPalPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        // Logic to process PayPal payment
        Console.WriteLine($"Processing PayPal payment of {amount:C} using PayPal.");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentMethod _paymentMethod;

    public PaymentProcessor(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void Process(decimal amount)
    {
        _paymentMethod.Pay(amount);
    }
}

// This file applies SOLID principles by structuring payment logic around 
// clean abstractions and focused responsibilities. Single Responsibility 
// is observed because each payment class—CreditCardPayment and 
// PayPalPayment—handles only its own payment logic, while PaymentProcessor 
// is responsible solely for coordinating a payment, not performing it. 
// The Open/Closed Principle is achieved through the IPaymentMethod interface, 
// allowing new payment types (e.g., Apple Pay, CashApp, or Bitcoin) to be 
// added without modifying existing classes. Liskov Substitution is supported 
// because any class implementing IPaymentMethod can be used by PaymentProcessor
// without altering how it functions. The design also reflects Interface 
// Segregation, since IPaymentMethod contains only what paying methods 
// need—no more, no less. Finally, Dependency Inversion is implemented 
// by having PaymentProcessor depend on the abstraction (IPaymentMethod) 
// rather than concrete payment classes, making the system highly modular, 
// extensible, and testable.