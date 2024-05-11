using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Movieshowdate
{
    [Key]
    public int ShowDateId { get; set; }
    public int CinemaId { get; set; }
    public int RoomId { get; set; }
    public int MovieId { get; set; }
}
