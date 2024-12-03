using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.Models
{
    public class EstadoRS
    {
        [Key] // Chave primária separada
        public int IDEstadoRS { get; set; }

        public int IDEstado { get; set; }
        public DateTime Data { get; set; }

        // Relacionamento com Estado
        public virtual Estado Estado { get; set; }

        public int IDReclamacaoSugestao { get; set; } // Chave estrangeira para ReclamacaoSugestao
        public virtual ReclamacaoSugestao ReclamacaoSugestao { get; set; } // Relacionamento com ReclamacaoSugestao
    }
}
    
