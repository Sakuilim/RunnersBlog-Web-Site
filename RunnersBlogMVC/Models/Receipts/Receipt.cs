using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Models.Receipts
{
    [ExcludeFromCodeCoverage]
    public class Receipt
    {
        public int ReceiptID { get; init; }

        public string? Description { get; init; }
    }
}
