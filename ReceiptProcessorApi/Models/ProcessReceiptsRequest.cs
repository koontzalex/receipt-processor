
namespace ReceiptProcessorApi.Models;
public class ReceiptPayload
{
    public required string Retailer { get; set; }
    public DateOnly PurchaseDate { get; set; }
    public TimeOnly PurchaseTime { get; set; }
    public List<ReceiptPayloadLineItem> Items { get; set; } = [];
    public double Total { get; set; }
}


public class ReceiptPayloadLineItem
{
    public required string ShortDescription { get; set; }
    public double Price { get; set; }
}