using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class RegisterModel
    {
        [Required, StringLength(30), Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required, StringLength(60), EmailAddress, Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required, StringLength(16, MinimumLength =6), Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required, StringLength(16, MinimumLength = 6), Display(Name = "Şifre(Tekrar)"), Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
