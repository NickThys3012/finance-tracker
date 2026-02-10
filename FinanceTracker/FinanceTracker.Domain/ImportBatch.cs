using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class ImportBatch : BaseClassWithId
{
    private ImportBatch()
    {
    }

    public ImportBatch(string fileName, int cvsProfileId, CsvProfile csvProfile, int rowCount, int importCount,
        int skippedCount)
    {
        FileName = fileName;
        CvsProfileId = cvsProfileId;
        CsvProfile = csvProfile;
        RowCount = rowCount;
        ImportCount = importCount;
        SkippedCount = skippedCount;
    }

    public string FileName { get; private set; }
    public int CvsProfileId { get; private set; }
    public CsvProfile CsvProfile { get; private set; }
    public int RowCount { get; private set; }
    public int ImportCount { get; private set; }
    public int SkippedCount { get; private set; }
}