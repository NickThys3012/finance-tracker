namespace FinanceTracker.Domain.CsvProfileSub;

public class ColumnSelector
{
    private ColumnSelector()
    {
    }

    // If Strategy=ByColumnName, use Name.
    public ColumnSelector(string? name, int? index, bool trim)
    {
        Name = name;
        Index = index;
        Trim = trim;
    }

    public string? Name { get; set; }

    // If Strategy=ByColumnIndex, use Index (0-based).
    public int? Index { get; set; }

    // Optional: trim, remove quotes, etc.
    public bool Trim { get; set; } = true;
}