using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_CinemaList
{
    [Key]
    public int CinemaId { get; set; }
    public string CinemaName { get; set; } = null!;
    public string CinemaLocation { get; set; } = null!;
}