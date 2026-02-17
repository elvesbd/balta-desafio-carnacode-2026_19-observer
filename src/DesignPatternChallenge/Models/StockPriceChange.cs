namespace DesignPatternChallenge.Models;

public class StockPriceChange(string symbol, decimal oldPrice, decimal newPrice)
{
    public string Symbol { get; } = symbol;
    public decimal OldPrice { get; } = oldPrice;
    public decimal NewPrice { get; } = newPrice;
    public decimal ChangePercent { get; } = ((newPrice - oldPrice) / oldPrice) * 100;
    public DateTime Timestamp { get; } = DateTime.Now;
}