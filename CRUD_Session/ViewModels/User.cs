using System.ComponentModel.DataAnnotations;

namespace CRUD_Session.ViewModels
{
    public class User
    {
        [Required(ErrorMessage ="Le Login est obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage ="Le password est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime LastLogout { get; set; }
    }
}
