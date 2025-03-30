namespace ReceiptProcessorApi.Models;

public class Receipt
{
    public Guid Id { get; set; } = Guid.Empty;
    public required string Retailer { get; set; }
    public DateOnly PurchaseDate { get; set; }
    public TimeOnly PurchaseTime { get; set; }
    public double Total { get; set; }
}