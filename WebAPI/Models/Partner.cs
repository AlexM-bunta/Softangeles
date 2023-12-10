using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("partners", Schema = "public")]
public class Partner
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("is_eco")] public bool IsEco { get; set; }
    [Column("bank_account_id")] public int BankAccountId { get; set; }
}