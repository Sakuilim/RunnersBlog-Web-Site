using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models.Receipts;

[ExcludeFromCodeCoverage]
public class Receipt
{
    public int ReceiptID { get; init; }

    public string Description { get; init; }
}
