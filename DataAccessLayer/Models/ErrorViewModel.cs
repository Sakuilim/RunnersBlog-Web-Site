using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models;

[ExcludeFromCodeCoverage]
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}