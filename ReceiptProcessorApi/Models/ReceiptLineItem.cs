namespace ReceiptProcessorApi.Models;

public class ReceiptLineItem
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid ReceiptId {get; set; } = Guid.Empty;
    public required string ShortDescription { get; set; }
    public double Price { get; set; }
}