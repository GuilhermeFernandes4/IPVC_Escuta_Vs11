using IPVC_Escuta_Vs11.Enums;
using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.Models
{
    public class Elogios
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "O campo Email precisa estar em um formato válido.")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Opinião é obrigatório.")]
        [StringLength(500, ErrorMessage = "A Opinião não pode ter mais do que 500 caracteres.")]
        public string Opiniao { get; set; }

        [Range(1, 5, ErrorMessage = "A Avaliação deve estar entre 1 e 5.")]
        public int Avaliacao { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Visualização é obrigatório.")]
        public TipoVisualizacao TipoVisualizacao { get; set; }

        public int? IDReclamacaoSugestao { get; set; }

        // Alterado para permitir nulo
        public string? UtilizadorId { get; set; } // A propriedade que referencia o usuário
    }
}
