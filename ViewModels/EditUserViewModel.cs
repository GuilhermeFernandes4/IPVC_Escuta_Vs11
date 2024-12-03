namespace IPVC_Escuta_Vs11.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }  // Certifique-se de que o tipo é o mesmo usado para o ID do usuário
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
