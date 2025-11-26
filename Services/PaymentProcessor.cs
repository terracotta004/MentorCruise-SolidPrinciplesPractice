public class CreditCardPayment : IPaymentMethod
{

    public CreditCardPayment()
    {

    }

    public void Pay(decimal amount)
    {
        // Logic to process credit card payment
        Console.WriteLine($"Processing credit card payment of {amount:C} using credit card.");
    }
}

public class PayPalPayment : IPaymentMethod
{
    public PayPalPayment()
    {

    }

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