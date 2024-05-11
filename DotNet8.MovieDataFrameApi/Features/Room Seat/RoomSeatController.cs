using DotNet8.MovieDataFrameApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MovieDataFrameApi.Features.Cinema;

[Route("api/[controller]")]
[ApiController]
public class RoomSeatController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public RoomSeatController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private async Task<List<Tbl_Roomseat>> GetRoomSeatListAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Data/MovieTicketOnlineBookingSystem.json");
        MovieTicketOnlineBookingSystemModel dataLst = JsonConvert.DeserializeObject<MovieTicketOnlineBookingSystemModel>(jsonStr)!;

        return dataLst.Tbl_RoomSeat;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoomSeat()
    {
        try
        {
            var lst = await GetRoomSeatListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomSeat()
    {
        try
        {
            var lst = await GetRoomSeatListAsync();
            await _appDbContext.Tbl_Roomseat.AddRangeAsync(lst);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? StatusCode(201, "Data Migration Successful!") : BadRequest("Fail!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
