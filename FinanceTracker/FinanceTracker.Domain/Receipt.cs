using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class Receipt : BaseClassWithId
{
    private Receipt()
    {
    }

    public Receipt(string fileName, string storedPath, string mimeType, decimal total, string notes)
    {
        FileName = fileName;
        StoredPath = storedPath;
        MimeType = mimeType;
        Total = total;
        Notes = notes;
    }

    public string FileName { get; private set; }
    public string StoredPath { get; private set; }
    public string MimeType { get; private set; }
    public decimal Total { get; private set; }
    public string Notes { get; private set; }
}