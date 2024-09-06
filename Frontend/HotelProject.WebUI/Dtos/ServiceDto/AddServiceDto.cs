using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class AddServiceDto
    {
        [Required(ErrorMessage ="Servis İkon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Servis Başlığı giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı en fazla 100 karakter olabilir")]
        public string ServiceTitle { get; set; }

        [Required(ErrorMessage = "Servis Açıklaması giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması en fazla 100 karakter olabilir")]
        public string ServiceDescriptiom { get; set; }
    }
}
