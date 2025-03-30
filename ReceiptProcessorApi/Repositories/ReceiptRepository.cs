using Microsoft.EntityFrameworkCore;
using ReceiptProcessorApi.Models;

namespace ReceiptProcessorApi.Repositories;

public interface IReceiptRepository : IDisposable
{
    Task InsertReceipt(Receipt receipt);
    Task InsertReceiptLines(List<ReceiptLineItem> receiptLines);
    Task<Receipt> GetReceiptById(Guid receiptId);
    Task<List<ReceiptLineItem>> GetReceiptLinesByReceiptId(Guid receiptId);
    Task Save();
}

public class ReceiptRepository : IReceiptRepository, IDisposable
{
    private ReceiptContext _context;
    private bool _disposed = false;

    public ReceiptRepository(ReceiptContext context)
    {
        _context = context;
    }

#region Disposable implementation
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool shouldDispose)
    {
        if (!_disposed)
            {
                if (shouldDispose)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
    }
#endregion Disposable implementation


    public async Task<Receipt> GetReceiptById(Guid receiptId)
    {
        var receipt = await _context.Receipts.FindAsync(receiptId);
        return receipt;
    }
    public async Task<List<ReceiptLineItem>> GetReceiptLinesByReceiptId(Guid receiptId)
    {
        var receiptLines = _context.ReceiptLines.Where(receiptLine =>
            receiptLine.ReceiptId == receiptId).ToList();
        return receiptLines;
    }

    public async Task InsertReceipt(Receipt receipt)
    {
        await _context.AddAsync(receipt);
    }
    public async Task InsertReceiptLines(List<ReceiptLineItem> receiptLines)
    {
        await _context.ReceiptLines.AddRangeAsync(receiptLines);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}

public class ReceiptContext : DbContext
{
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptLineItem> ReceiptLines { get; set; }
    public ReceiptContext(DbContextOptions<ReceiptContext> options) : base(options)
    {

    }
}