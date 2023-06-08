using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class LoginModel
    {
        [Required, StringLength(30), Display(Name="Kullanıcı Adı")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
