using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Cinema;

[Route("api/[controller]")]
[ApiController]
public class CinemaRoomController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CinemaRoomController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<List<Tbl_Cinemaroom>> GetCinemaRoomAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        MovieTicketOnlineBookingSystemModel dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;

        return dataLst.Tbl_CinemaRoom;
    }

    [HttpGet]
    public async Task<IActionResult> GetCinemaRoom()
    {
        try
        {
            List<Tbl_Cinemaroom> lst = await GetCinemaRoomAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCinemaRoom()
    {
        try
        {
            List<Tbl_Cinemaroom> lst = await GetCinemaRoomAsync();
            await _appDbContext.Tbl_CinemaRoom.AddRangeAsync(lst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
