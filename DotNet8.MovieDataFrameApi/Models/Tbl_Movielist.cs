using System.ComponentModel.DataAnnotations;

namespace DotNet8.MovieDataFrameApi.Models;

public class Tbl_Movielist
{
    [Key]
    public int MovieId { get; set; }
    public string MovieTitle { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public string Duration { get; set; } = null!;
    public string MoviePhoto { get; set; } = null!;
}