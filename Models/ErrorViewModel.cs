namespace IPVC_Escuta_Vs11.Models
{
    public class ErrorViewModel
    {
       
            public string RequestId { get; set; }
            public string Message { get; set; } // Adiciona esta propriedade para a mensagem de erro
            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


    }
}
