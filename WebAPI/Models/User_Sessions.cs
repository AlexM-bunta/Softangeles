using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("users_sessions", Schema = "public")]
public class User_Sessions
{
    [Key] [Column("id")]
    public int Id { get; set; }
    
    [Column("session_table_id")]
    public int SessionTableId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

}