using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table($"transactions", Schema = "public")]
public class Transaction
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("bank_account_source_id")] public int SourceAccountId { get; set; }

    [Column("bank_account_destination_id")]
    public int DestinationAccountId { get; set; }

    [Column("amount")] public decimal Amount { get; set; }
    [Column("discount_id")] public int DiscountId { get; set; }
    [Column("create_date")] public DateTime CreateDate { get; set; }

    [Column("details")] public string Details { get; set; } = string.Empty;
    [Column("is_accepted")] public bool IsAccepted { get; set; }
}