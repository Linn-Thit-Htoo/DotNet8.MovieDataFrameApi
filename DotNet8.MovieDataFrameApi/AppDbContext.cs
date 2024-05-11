using DotNet8.MovieDataFrameApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MovieDataFrameApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Tbl_CinemaList> Tbl_CinemaList { get; set; }
    public DbSet<Tbl_Cinemaroom> Tbl_CinemaRoom { get; set; }
    public DbSet<Tbl_Movielist> Tbl_Movielist { get; set; }
    public DbSet<Tbl_Roomseat> Tbl_Roomseat { get; set; }
    public DbSet<Tbl_Movieshowdate> Tbl_Movieshowdate { get; set; }
    public DbSet<Tbl_Movieschedule> Tbl_Movieschedule { get; set; }
    public DbSet<Tbl_Seatprice> Tbl_Seatprice { get; set; }
}