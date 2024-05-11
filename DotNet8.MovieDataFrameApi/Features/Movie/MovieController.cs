using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Movie;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public MovieController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<List<Tbl_Movielist>> GetMovieListAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        MovieTicketOnlineBookingSystemModel dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;

        return dataLst.Tbl_MovieList;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovieList()
    {
        try
        {
            var lst = await GetMovieListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovieList()
    {
        try
        {
            var lst = await GetMovieListAsync();
            await _appDbContext.Tbl_Movielist.AddRangeAsync(lst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
