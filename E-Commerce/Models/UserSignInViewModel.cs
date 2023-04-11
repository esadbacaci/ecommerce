using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage="Lütfen Kullanıcı Adı Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string password { get; set; }
    }
}
