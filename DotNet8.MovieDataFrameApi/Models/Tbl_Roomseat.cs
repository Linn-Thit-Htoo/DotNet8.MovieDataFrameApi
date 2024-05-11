using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Roomseat
{
    [Key]
    public int SeatId { get; set; }
    public int RoomId { get; set; }
    public int? SeatNo { get; set; }
    public string RowName { get; set; } = null!;
    public string SeatType { get; set; } = null!;
}