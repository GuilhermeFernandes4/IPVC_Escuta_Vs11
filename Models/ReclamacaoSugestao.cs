using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IPVC_Escuta_Vs11.Enums;

namespace IPVC_Escuta_Vs11.Models
{
    public class ReclamacaoSugestao
    {
        [Key]   
        public int IDReclamacaoSugestao { get; set; }

        public TipoFormulario TipoFormulario { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public TimeSpan Hora { get; set; }

        [Required]
        [StringLength(200)]
        public string Motivo { get; set; }

        [Required]
        public string DescricaoRec { get; set; }

        public Categoria Categoria { get; set; }
        public Escola Escola { get; set; }

        // Alterar o tipo da chave estrangeira
        public string UtilizadorId { get; set; } // Agora é do tipo string
        public Utilizador Utilizador { get; set; }

        // Coleções associadas à reclamação/sugestão
        public virtual ICollection<Elogios> Elogios { get; set; } = new List<Elogios>();
        public virtual ICollection<ComentarioS> Comentarios { get; set; } = new List<ComentarioS>();
        public virtual ICollection<DenunciaR> Denuncias { get; set; } = new List<DenunciaR>();
    }
}
