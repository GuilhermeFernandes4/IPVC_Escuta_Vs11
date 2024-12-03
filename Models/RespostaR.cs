using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.Models
{
    public class RespostaR
    {
        [Key] // Define explicitamente a chave primária
        public int IDRespostaR { get; set; } // Chave primária

        public int IDReclamacaoSugestao { get; set; }
        public string Resposta { get; set; }

        // Relacionamento com Reclamação/Sugestão
        public virtual ReclamacaoSugestao ReclamacaoSugestao { get; set; }
    }
}
