using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Product.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen İsim Giriniz.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyisim Giriniz.")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz.")]
        [Compare("Password", ErrorMessage = "Şifrelerin Eşleştiğinden Emin Olun.")]
        public string ConfirmPassword { get; set; }
    }
}
