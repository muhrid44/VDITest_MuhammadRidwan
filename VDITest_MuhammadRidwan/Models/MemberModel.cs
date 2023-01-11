using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VDITest_MuhammadRidwan.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address {get; set; }
        public string Phone { get; set; }
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Birth Date")]
        public string StringBirthDate { get; set; }
        public string NIK { get; set; }
        public string AvatarUrl { get; set; }
        public IFormFile avatarFile { get; set; }

    }
}
