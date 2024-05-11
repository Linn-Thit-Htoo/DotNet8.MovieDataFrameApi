using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Cinema;

[Route("api/[controller]")]
[ApiController]
public class MovieShowDateController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public MovieShowDateController(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }

    private async Task<List<Tbl_Movieshowdate>> GetMovieShowDatesAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        MovieTicketOnlineBookingSystemModel dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;

        return dataLst.Tbl_MovieShowDate;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovieShowDate()
    {
        try
        {
            var lst = await GetMovieShowDatesAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovieShowDate()
    {
        try
        {
            var lst = await GetMovieShowDatesAsync();
            await _appDbContext.Tbl_Movieshowdate.AddRangeAsync(lst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
