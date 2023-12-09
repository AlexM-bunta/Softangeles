using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("users", Schema = "public")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("username")]
    public string Username { get; set; } = string.Empty;
    
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("eco_points")]
    public int EcoPoints { get; set; }

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("registered_date")]
    public DateTime RegisteredDate { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
}