using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {
        public string AppUserName { get; set; }
        public string AppUserSurname { get; set; }
        public string? AppUserCity { get; set; }
        public string AppUserImageUrl { get; set; }
        public string? AppUserWorkDepartment { get; set; }
        public int WorkLocationID { get; set; }
        public virtual WorkLocation WorkLocation { get; set; }
    }
}