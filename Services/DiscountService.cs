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
