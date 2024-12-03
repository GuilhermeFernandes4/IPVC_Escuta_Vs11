using IPVC_Escuta_Vs11.Models;

namespace IPVC_Escuta_Vs11.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<ReclamacaoSugestao> ReclamacoesSugestoes { get; set; }
        public IEnumerable<Elogios> Elogios { get; set; }
    }
}
