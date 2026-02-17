using DesignPatternChallenge.Models;
using DesignPatternChallenge.Abstractions;

namespace DesignPatternChallenge.Observers;

public class InvestorObserver(string name, decimal alertThreshold) : IStockObserver
{
    public string Name { get; }  = name;
    public decimal AlertThreshold { get; } = alertThreshold;
    
    public void Update(StockPriceChange priceChange)
    {
        Console.WriteLine($"  → [Investidor {Name}] Notificado sobre {priceChange.Symbol}");

        if (Math.Abs(priceChange.ChangePercent) >= AlertThreshold)
        {
            Console.WriteLine($"  → [Investidor {Name}] ALERTA! Mudança de {priceChange.ChangePercent:+0.00;-0.00}% excedeu limite de {AlertThreshold}%");
        }
    }
}