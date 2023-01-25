using System.ComponentModel.DataAnnotations;

namespace Layihe_Task_.ViewModels.User
{
    public class UserLoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsParsistance { get; set; }

    }
}
