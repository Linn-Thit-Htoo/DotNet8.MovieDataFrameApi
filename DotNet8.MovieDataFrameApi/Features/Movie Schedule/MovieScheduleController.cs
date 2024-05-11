using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Cinema;

[Route("api/[controller]")]
[ApiController]
public class MovieScheduleController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public MovieScheduleController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<List<Tbl_Movieschedule>> GetMovieScheduleListAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        MovieTicketOnlineBookingSystemModel dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;

        return dataLst.Tbl_MovieSchedule;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovieScheduleList()
    {
        try
        {
            var lst = await GetMovieScheduleListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovieSchedule()
    {
        try
        {
            var lst = await GetMovieScheduleListAsync();
            await _appDbContext.Tbl_Movieschedule.AddRangeAsync(lst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}