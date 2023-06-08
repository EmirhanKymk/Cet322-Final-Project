using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class UserModel
    {
        [StringLength(60), Display(Name = "Ad Soyad")]
        public string Fullname { get; set; }

        [Required, StringLength(30), Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required, StringLength(60), EmailAddress, Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required, StringLength(16, MinimumLength = 6), Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required, StringLength(16, MinimumLength = 6), Display(Name = "Şifre(Tekrar)"), Compare(nameof(Password))]
        public string RePassword { get; set; }

        [Display(Name ="Aktif")]
        public bool IsActive { get; set; }

        [Display(Name = "Yönetici")]
        public bool IsAdmin { get; set; }
    }
}
