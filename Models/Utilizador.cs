using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.Models
{
    public class Utilizador : IdentityUser
    {
        

        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
        public string? FirstName { get; set; }

        [StringLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        public string? LastName { get; set; }

        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        public string? Address { get; set; }

        [Display(Name = "Data de Registro")]
        public DateTime? Regist_Date { get; set; }

        // Propriedade calculada para obter o nome completo do usuário
        public string FullName => $"{FirstName} {LastName}"; 

        // Relação 1:N com Reclamações/Sugestões
        public virtual ICollection<ReclamacaoSugestao> ReclamacoesSugestoes { get; set; }
        public bool IsActive { get; internal set; }
    }
}
