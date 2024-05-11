using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Cinemaroom
{
    [Key]
    public int RoomId { get; set; }
    public int CinemaId { get; set; }
    public int RoomNumber { get; set; }
    public string RoomName { get; set; } = null!;
    public int SeatingCapacity { get; set; }
}