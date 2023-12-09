using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("sessions", Schema = "public")]
public class Session
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("session_id")] public Guid SessionId { get; set; }
    [Column("start_date")] public DateTime? StartDate { get; set; }
    [Column("end_date")] public DateTime? EndDate { get; set; }

    [Column("last_active_date")] public DateTime? LastActiveDate { get; set; }
}