using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário deve ter no máximo 50 caracteres.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
        public string? Password { get; set; }

        [Display(Name = "Lembrar de mim")]
        public bool RememberMe { get; set; }
    }
}
