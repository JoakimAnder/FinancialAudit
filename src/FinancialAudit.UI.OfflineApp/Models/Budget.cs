namespace FinancialAudit.UI.OfflineApp.Models;
public record Budget(string Id, string Name, double TotalAmount, IEnumerable<TargetPart> Percentages);

public record TargetPart(string CategoryId, double Amount);