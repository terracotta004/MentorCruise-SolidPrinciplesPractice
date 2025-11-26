# MentorCruise-SolidPrinciplesPractice
Assignment: Invoice Generator (SOLID Principles Practice)

### 🎯 **Goal**

Create a **very small console app** that simulates paying for an order and printing a simple receipt.

The focus is **clean code and SOLID design**, not full functionality.

---

### 🧱 **Scenario**

A user buys something → chooses a payment method → pays → gets a receipt printed.

Example console output:

```
Customer: Ben Underwood
Item: Coffee - 2.50€
Paid 2.50€ using Credit Card
--- Receipt printed on screen ---

```

---

### 📦 **Minimal Requirements**

1. The app supports **two payment methods** (e.g., CreditCard, PayPal).
2. The app supports **two receipt types** (e.g., ConsoleReceipt, JsonReceipt).
3. The app can **add a simple discount** (e.g., 10% off for VIP customers).
4. Everything should follow SOLID principles.

---

### ⚙️ **Suggested Structure**

```
/Interfaces
  IPaymentMethod.cs
  IReceiptPrinter.cs

/Models
  Order.cs
  Customer.cs

/Services
  PaymentProcessor.cs
  ReceiptService.cs
  DiscountService.cs

/Program.cs

```

---

### 🧩 **How SOLID applies**

| Principle | Example |
| --- | --- |
| **S** | `PaymentProcessor` only handles payments, `ReceiptService` only prints receipts, `DiscountService` only calculates discounts. |
| **O** | You can add new payment or receipt types without changing existing logic. |
| **L** | All `IPaymentMethod` implementations can replace each other safely. |
| **I** | Two small interfaces: `IPaymentMethod`, `IReceiptPrinter` — no fat interfaces. |
| **D** | `PaymentProcessor` and `ReceiptService` depend on abstractions (interfaces) injected via constructor. |

---

### 🧠 **Example Implementation**

### Interfaces

```csharp
public interface IPaymentMethod
{
    void Pay(decimal amount);
}

public interface IReceiptPrinter
{
    void Print(Order order);
}

```

### Models

```csharp
public class Customer
{
    public string Name { get; set; }
    public bool IsVip { get; set; }
}

public class Order
{
    public Customer Customer { get; set; }
    public string Item { get; set; }
    public decimal Price { get; set; }
}

```

### 

```csharp
class Program
{
    static void Main()
    {
        var customer = new Customer { Name = "Saeed", IsVip = true };
        var order = new Order { Customer = customer, Item = "Coffee", Price = 2.50m };

        var discountService = new DiscountService();
        var finalAmount = discountService.ApplyDiscount(customer, order.Price);

        IPaymentMethod paymentMethod = new CreditCardPayment();
        IReceiptPrinter receiptPrinter = new ConsoleReceiptPrinter();

        var paymentProcessor = new PaymentProcessor(paymentMethod);
        var receiptService = new ReceiptService(receiptPrinter);

        paymentProcessor.Process(finalAmount);
        receiptService.PrintReceipt(order);
    }
}

```

---

### ✅ **Deliverables**

- Code in a single small console app.
- A short explanation (1–2 paragraphs) of **how each SOLID principle was applied**.