using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Movieschedule
{
    [Key]
    public int ShowId { get; set; }
    public int ShowDateId { get; set; }
    public DateTime ShowDateTime { get; set; }
}