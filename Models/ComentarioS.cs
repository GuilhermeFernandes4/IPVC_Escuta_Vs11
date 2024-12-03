using System;
using System.ComponentModel.DataAnnotations;
namespace IPVC_Escuta_Vs11.Models
{
    public class ComentarioS
    {
        [Key] // Define explicitamente a chave primária
        public int IDComentarioS { get; set; } // ID da chave primária

        public int IDReclamacaoSugestao { get; set; } // Chave estrangeira
        public string Comentario { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }

        // Relacionamento com Reclamações/Sugestões
        public virtual ReclamacaoSugestao ReclamacaoSugestao { get; set; }
    }
}
