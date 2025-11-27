public abstract class DiscountStrategy
{
    public abstract decimal ApplyDiscount(decimal total);
}

public class RegularDiscount : DiscountStrategy
{
    public override decimal ApplyDiscount(decimal total) => total;
}

public class PremiumDiscount : DiscountStrategy
{
    public override decimal ApplyDiscount(decimal total) => total * 0.90m;
}

public class DiscountService
{
    private readonly DiscountStrategy _discountStrategy;

    public DiscountService(DiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal ApplyDiscount(decimal total) =>
        _discountStrategy.ApplyDiscount(total);
}



// The discount strategies can be extended without modifying the DiscountService class,
// adhering to the Open/Closed Principle.

// This file demonstrates SOLID principles by cleanly separating responsibilities and relying on abstractions. 
// Single Responsibility is upheld because each class has exactly one job: the strategy classes focus only on calculating a discount, 
// while DiscountService simply applies whichever strategy it receives. Open/Closed Principle is met because new discount types—
// like a holiday discount or loyalty discount—can be added by creating new classes that inherit from DiscountStrategy, 
// without modifying any existing code. Liskov Substitution is maintained since any subclass of DiscountStrategy can be used 
// interchangeably by DiscountService without breaking behavior. Interface Segregation appears in the form of keeping the abstraction 
// (DiscountStrategy) small and focused, ensuring implementations aren’t forced to include unrelated logic. 
// Finally, Dependency Inversion is demonstrated through DiscountService depending on the abstract base class rather than 
// on any specific discount implementation, making the system flexible, testable, and easy to extend.