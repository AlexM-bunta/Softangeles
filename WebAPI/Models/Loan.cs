using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("loans", Schema = "public")]
public class Loan
{
    [Key] [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("requested_amount")]
    public decimal RequestedAmount { get; set; }
    [Column("total_amount")]
    public decimal TotalAmount { get; set; }
    [Column("paid_amount")]
    public decimal PaidAmount { get; set; }
    [Column("no_months")]
    public int Months { get; set; }
    [Column("interest")]
    public float Interest { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }
}