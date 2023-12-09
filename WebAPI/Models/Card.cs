using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("cards", Schema = "public")]
public class Card
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("bank_account_id")] public int BankAccountId { get; set; }

    [Column("number")] public string Number { get; set; } = string.Empty;
    [Column("cvv")] public string CVV { get; set; } = string.Empty;
    [Column("pin")] public int PIN { get; set; }
    [Column("is_physical")] public bool IsPhysical { get; set; }
    [Column("create_date")] public DateTime CreateDate { get; set; }
    [Column("expiry_date")] public DateTime ExpiryDate { get; set; }
    [Column("is_active")] public bool IsActive { get; set; }
}