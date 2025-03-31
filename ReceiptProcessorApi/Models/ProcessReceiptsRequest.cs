
namespace ReceiptProcessorApi.Models;
public class ReceiptPayload
{
    public required string Retailer { get; set; }
    public required DateOnly PurchaseDate { get; set; }
    public required TimeOnly PurchaseTime { get; set; }
    public required List<ReceiptPayloadLineItem> Items { get; set; } = [];
    public required double Total { get; set; }
}


public class ReceiptPayloadLineItem
{
    public required string ShortDescription { get; set; }
    public required double Price { get; set; }
}