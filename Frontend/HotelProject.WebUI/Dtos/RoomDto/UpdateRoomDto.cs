namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomTitle { get; set; }
        public string RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public String RoomDescription { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
    }
}
