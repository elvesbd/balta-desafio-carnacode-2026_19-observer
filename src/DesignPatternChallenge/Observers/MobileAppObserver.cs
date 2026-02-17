using DesignPatternChallenge.Models;
using DesignPatternChallenge.Abstractions;

namespace DesignPatternChallenge.Observers;

public class MobileAppObserver(string userId) : IStockObserver
{
    public string UserId { get; } = userId;

    public void Update(StockPriceChange priceChange)
    {
        Console.WriteLine($"  → [App Mobile {UserId}] Push: {priceChange.Symbol} agora em R$ {priceChange.NewPrice:N2} ({priceChange.ChangePercent:+0.00;-0.00}%)");
    }
}