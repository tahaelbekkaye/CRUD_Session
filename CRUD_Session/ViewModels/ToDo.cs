using System.ComponentModel.DataAnnotations;

namespace CRUD_Session.ViewModels
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="le libelle est obligatoire")]
        public string Libelle { get; set; }
        public string Description { get; set; }
        public enum MyEnum
        {
            ToDo,
            Doing,
            Done,
        }
        public MyEnum State { get; set; }
        [Required(ErrorMessage = "la date est obligatoire")]
        [DataType(DataType.DateTime)]
        public DateTime DateLimite { get; set; }
        public DateTime LastLogout { get; set; }
    }
}
