using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Cinema;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CinemaController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<List<Tbl_CinemaList>> GetCinemaListAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        var dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;
        return dataLst.Tbl_CinemaList;
    }

    [HttpGet]
    public async Task<IActionResult> GetCinemaList()
    {
        var model = await GetCinemaListAsync();
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCinemaList()
    {
        try
        {
            List<Tbl_CinemaList> dataLst = await GetCinemaListAsync();
            await _appDbContext.Tbl_CinemaList.AddRangeAsync(dataLst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}