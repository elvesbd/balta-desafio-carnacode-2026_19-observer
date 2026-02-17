using DesignPatternChallenge.Models; 
using DesignPatternChallenge.Abstractions;

namespace DesignPatternChallenge.Observers;

public class TradingBotObserver(string botName, decimal buyThreshold, decimal sellThreshold) : IStockObserver
{
    public string BotName { get; } = botName;
    public decimal BuyThreshold { get; } = buyThreshold;
    public decimal SellThreshold { get; } =  sellThreshold;
    
    public void Update(StockPriceChange priceChange)
    {
        Console.WriteLine($"  → [Bot {BotName}] Analisando {priceChange.Symbol}...");

        if (priceChange.ChangePercent <= -BuyThreshold)
            Console.WriteLine($"→ [Bot {BotName}] COMPRANDO {priceChange.Symbol} por R$ {priceChange.NewPrice:N2}");
        else if (priceChange.ChangePercent >= SellThreshold)
            Console.WriteLine($"→ [Bot {BotName}] VENDENDO {priceChange.Symbol} por R$ {priceChange.NewPrice:N2}");
    }
}