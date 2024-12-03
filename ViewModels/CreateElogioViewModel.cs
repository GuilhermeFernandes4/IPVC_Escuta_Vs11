using IPVC_Escuta_Vs11.Enums;
using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.ViewModels
{
    public class CreateElogioViewModel
    {
        public int Id { get; set; } // Propriedade Id para a identificação do elogio

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A opinião é obrigatória.")]
        [StringLength(1000, ErrorMessage = "A opinião não pode exceder 1000 caracteres.")]
        public string Opiniao { get; set; }

        [Range(1, 5, ErrorMessage = "A avaliação deve estar entre 1 e 5.")]
        public int Avaliacao { get; set; }

        [Required(ErrorMessage = "O tipo de visualização é obrigatório.")]
        public TipoVisualizacao TipoVisualizacao { get; set; }

        // Propriedade opcional de chave estrangeira para ReclamacaoSugestao
        public int? IDReclamacaoSugestao { get; set; }
    }
}
