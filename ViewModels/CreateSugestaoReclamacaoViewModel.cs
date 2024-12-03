using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IPVC_Escuta_Vs11.Enums;
using IPVC_Escuta_Vs11.Models;

namespace IPVC_Escuta_Vs11.ViewModels
{
    public class CreateSugestaoReclamacaoViewModel
    {
        public int IDReclamacaoSugestao { get; set; } // Adicionar este campo

        // Outros campos já existentes...
        public TipoFormulario TipoFormulario { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Motivo { get; set; }
        public string DescricaoRec { get; set; }
        public Categoria Categoria { get; set; }
        public Escola Escola { get; set; }
        public int ID_Utilizador { get; set; }

        // Coleções
        public ICollection<Elogios> Elogios { get; set; } = new List<Elogios>();
        public ICollection<ComentarioS> Comentarios { get; set; } = new List<ComentarioS>();
        public ICollection<DenunciaR> Denuncias { get; set; } = new List<DenunciaR>();
    }
}
