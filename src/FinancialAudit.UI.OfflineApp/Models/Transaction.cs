namespace FinancialAudit.UI.OfflineApp.Models;
public record Transaction(string Id, string Name, string Description, DateTime DateTimeUtc, double Amount);