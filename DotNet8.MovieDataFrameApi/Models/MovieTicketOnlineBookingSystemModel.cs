namespace DotNet8.MovieDataFrameApi.Models;

public class MovieTicketOnlineBookingSystemModel
{
    public List<Tbl_CinemaList> Tbl_CinemaList { get; set; }
    public List<Tbl_Cinemaroom> Tbl_CinemaRoom { get; set; }
    public List<Tbl_Movielist> Tbl_MovieList { get; set; }
    public List<Tbl_Roomseat> Tbl_RoomSeat { get; set; }
    public List<Tbl_Movieshowdate> Tbl_MovieShowDate { get; set; }
    public List<Tbl_Movieschedule> Tbl_MovieSchedule { get; set; }
    public List<Tbl_Seatprice> Tbl_SeatPrice { get; set; }
}