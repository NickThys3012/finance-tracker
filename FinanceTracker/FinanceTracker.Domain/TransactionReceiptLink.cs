namespace FinanceTracker.Domain;

public class TransactionReceiptLink
{
    private TransactionReceiptLink()
    {
    }

    public TransactionReceiptLink(int transactionId, Transaction transaction, int receiptId, Receipt receipt,
        MatchType type)
    {
        TransactionId = transactionId;
        Transaction = transaction;
        ReceiptId = receiptId;
        Receipt = receipt;
        Type = type;
    }

    public int TransactionId { get; private set; }
    public Transaction Transaction { get; private set; }
    public int ReceiptId { get; private set; }
    public Receipt Receipt { get; private set; }
    public MatchType Type { get; set; }
}