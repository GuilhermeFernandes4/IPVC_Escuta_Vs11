using IPVC_Escuta_Vs11.Models;
using System;
using System.ComponentModel.DataAnnotations;
namespace IPVC_Escuta_Vs11.Models
{
    public class DenunciaR
    {
        [Key] // Define explicitamente a chave primária
        public int IDDenunciaR { get; set; } // Chave primária

        public int IDReclamacaoSugestao { get; set; } // Chave estrangeira para Reclamações/Sugestões
        public string Motivo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }

        // Relacionamento com Reclamações/Sugestões
        public virtual ReclamacaoSugestao ReclamacaoSugestao { get; set; }
    }
}
