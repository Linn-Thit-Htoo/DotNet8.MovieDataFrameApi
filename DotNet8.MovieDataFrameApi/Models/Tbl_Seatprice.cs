using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Seatprice
{
    [Key]
    public int SeatPriceId { get; set; }
    public int RoomId { get; set; }
    public string RowName { get; set; } = null!;
    public int SeatPrice { get; set; }
}