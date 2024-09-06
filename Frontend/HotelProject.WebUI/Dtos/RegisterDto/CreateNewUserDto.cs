using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Gereklidir")]
        public string AppUserName { get; set; }

        [Required(ErrorMessage ="Soyad Gereklidir")]
        public string AppUserSurname { get; set; }

        [Required(ErrorMessage ="Kullanıcı Adı Gereklidir")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Mail Gereklidir")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Şifre Gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı Gereklidir")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

    }
}
