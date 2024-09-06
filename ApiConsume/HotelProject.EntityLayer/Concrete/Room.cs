using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomTitle { get; set; }
        public string RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public string RoomDescription { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
    }
}
