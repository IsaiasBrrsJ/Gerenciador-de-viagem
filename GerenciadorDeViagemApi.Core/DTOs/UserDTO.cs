namespace GerenciadorDeViagemApi.Core.DTOs
{
    public class UserDTO
    {
        public UserDTO(long matricula, string email, string nomeCompleto)
        {
            Matricula = matricula;
            Email = email;
            NomeCompleto = nomeCompleto;
        }

        public long Matricula { get; private set; }
        public string Email { get; private set; }
        public string NomeCompleto { get; private set; } = String.Empty;
    }
}
