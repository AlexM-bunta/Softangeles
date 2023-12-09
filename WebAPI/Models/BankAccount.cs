using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WebAPI.Models;

[Table("bank_accounts", Schema = "public")]
public class BankAccount
{
    [Key] 
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("type_id")] 
    public int TypeId { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("balance")] 
    public double Balance { get; set; }

    [Column("iban")] 
    public string IBAN { get; set; } = string.Empty;

    [Column("create_date")] 
    public DateTime CreateDate { get; set; }

    [Column("is_active")] 
    public bool IsActive { get; set; }
}