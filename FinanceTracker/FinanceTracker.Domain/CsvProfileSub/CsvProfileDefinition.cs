namespace FinanceTracker.Domain.CsvProfileSub;

public class CsvProfileDefinition
{
    private CsvProfileDefinition()
    {
    }

    public CsvProfileDefinition(char delimiter, bool hasHeader, string? encodingName, string culture, string dateFormat,
        AmountParsingDefinition amountParsing, ColumnMappingDefinition mapping,
        List<TextReplaceRule> descriptionCleanupRules)
    {
        Delimiter = delimiter;
        HasHeader = hasHeader;
        EncodingName = encodingName;
        Culture = culture;
        DateFormat = dateFormat;
        AmountParsing = amountParsing;
        Mapping = mapping;
        DescriptionCleanupRules = descriptionCleanupRules;
    }


    // Parsing
    public char Delimiter { get; set; } = ';';
    public bool HasHeader { get; set; } = true;
    public string? EncodingName { get; set; } = "utf-8";

    // Culture affects decimal separators, dates, etc.
    // Example: "nl-BE", "fr-BE", "en-US"
    public string Culture { get; set; } = "nl-BE";

    // Date parsing strategy
    // You can support multiple formats from a bank export
    public string DateFormat { get; set; } = "yyyy-MM-dd";

    // Some banks have separate debit/credit columns, some have signed amount
    public AmountParsingDefinition AmountParsing { get; set; }

    // Map bank CSV columns -> canonical fields
    public ColumnMappingDefinition Mapping { get; set; }

    // Optional cleanup rules
    public List<TextReplaceRule> DescriptionCleanupRules { get; set; }
}