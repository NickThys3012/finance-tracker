using FinanceTracker.Enums.CvsProfile;

namespace FinanceTracker.Domain.CsvProfileSub;

public class AmountParsingDefinition
{
    private AmountParsingDefinition()
    {
    }

    public AmountParsingDefinition(AmountParsingMode mode, SignedAmountSignConvention signedConvention,
        DebitCreditSignConvention debitCreditConvention, string? defaultCurrency, string? decimalSeparator,
        string? thousandSeparator)
    {
        Mode = mode;
        SignedConvention = signedConvention;
        DebitCreditConvention = debitCreditConvention;
        DefaultCurrency = defaultCurrency;
        DecimalSeparator = decimalSeparator;
        ThousandSeparator = thousandSeparator;
    }

    // If the CSV has a single Amount column, set Mode=SignedAmount.
    // If it has Debit and Credit columns, set Mode=DebitCreditColumns.
    public AmountParsingMode Mode { get; set; } = AmountParsingMode.SignedAmount;

    // When Mode=SignedAmount:
    // Some banks output expenses as positive numbers. If so, flip sign here.
    public SignedAmountSignConvention SignedConvention { get; set; } = SignedAmountSignConvention.ExpensesNegative;

    // When Mode=DebitCreditColumns:
    public DebitCreditSignConvention DebitCreditConvention { get; set; } = DebitCreditSignConvention.DebitNegative;

    // Optional: force currency when CSV doesn’t contain it
    public string? DefaultCurrency { get; set; } = "EUR";

    // If bank includes thousand separators, you might want to control parsing explicitly
    public string? DecimalSeparator { get; set; } // null => culture default
    public string? ThousandSeparator { get; set; } // null => culture default
}