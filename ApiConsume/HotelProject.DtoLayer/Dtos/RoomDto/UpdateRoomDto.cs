using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Numarası Giriniz")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığı Giriniz")]
        [StringLength(100,ErrorMessage ="Lütfen en fazla 100 karakter giriniz")]
        public string RoomTitle { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Fiyatı Giriniz")]
        public int RoomPrice { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Açıklaması Giriniz")]
        public String RoomDescription { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı Giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı Giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
    }
}
