using DesignPatternChallenge.Subjects;
using DesignPatternChallenge.Observers;

Console.WriteLine("=== Sistema de Monitoramento de Ações - Observer ===\n");

// Cria as ações
var petr4 = new Stock("PETR4", 35.50m);
var vale3 = new Stock("VALE3", 68.00m);

// Cria os observadores
var joao = new InvestorObserver("João Silva", 3.0m);
var maria = new InvestorObserver("Maria Santos", 5.0m);
var app = new MobileAppObserver("user123");
var bot = new TradingBotObserver("AlgoTrader", 2.0m, 2.5m);

// Inscreve observadores — dinâmico e desacoplado
Console.WriteLine("--- Inscrevendo observadores ---\n");
petr4.Subscribe(joao);
petr4.Subscribe(maria);
petr4.Subscribe(app);
petr4.Subscribe(bot);

vale3.Subscribe(maria);
vale3.Subscribe(bot);

// Simulando movimentações
Console.WriteLine("\n=== Movimentações do Mercado ===");

petr4.UpdatePrice(36.20m);
Thread.Sleep(500);

petr4.UpdatePrice(37.50m);
Thread.Sleep(500);

petr4.UpdatePrice(35.00m);
Thread.Sleep(500);

vale3.UpdatePrice(70.50m);
Thread.Sleep(500);

// Demonstra remoção dinâmica de observador
Console.WriteLine("\n--- João cancela inscrição em PETR4 ---\n");
petr4.Unsubscribe(joao);

petr4.UpdatePrice(34.00m);
Thread.Sleep(500);

// Demonstra adição dinâmica de novo observador
Console.WriteLine("\n--- Novo investidor entra no mercado ---\n");
var pedro = new InvestorObserver("Pedro Alves", 1.0m);
petr4.Subscribe(pedro);
vale3.Subscribe(pedro);

petr4.UpdatePrice(36.00m);
vale3.UpdatePrice(65.00m);