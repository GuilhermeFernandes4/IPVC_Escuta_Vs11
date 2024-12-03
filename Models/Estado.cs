using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace IPVC_Escuta_Vs11.Models
{
    public class Estado
    {
        [Key] // Define explicitamente a chave primária
        public int IDEstado { get; set; } // Chave primária

        public string Descricao { get; set; }

        // Relacionamento com Estado_R_S
        public virtual ICollection<EstadoRS> EstadoRS { get; set; }
    }
}
