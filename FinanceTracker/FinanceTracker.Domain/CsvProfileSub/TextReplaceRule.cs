namespace FinanceTracker.Domain.CsvProfileSub;

public class TextReplaceRule
{
    public TextReplaceRule(string pattern, string replacement, bool useRegex)
    {
        Pattern = pattern;
        Replacement = replacement;
        UseRegex = useRegex;
    }

    public required string Pattern { get; set; } // can be plain text or regex, up to you
    public required string Replacement { get; set; }
    public bool UseRegex { get; set; }
}