using GerenciadorDeViagem.Model.Enum;

namespace GerenciadorDeViagemApi.Core.DTOs
{
    public class EmailDTO
    {
        public EmailDTO(string nomeCompleto, string email, TipoDeUsuario tipoDeUsuario)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            TipoDeUsuario = tipoDeUsuario;
        }

        public EmailDTO(string nomeCompleto, string email, TipoDeUsuario tipoDeUsuario,  string emailSubject, long matricula, string senha)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            TipoDeUsuario = tipoDeUsuario;
            EmailSubject = emailSubject;
            Matricula = matricula;
            Senha = senha;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public TipoDeUsuario TipoDeUsuario { get; private set; }
        public string EmailTemplate { get;  set; }
        public string EmailSubject { get;  set; }
        public long Matricula { get; private set; } 
        public string Senha { get; private set; }
    }
}
