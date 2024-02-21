using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Core.EmailTemplates;
using GerenciadorDeViagemApi.Core.Entities;

namespace GerenciadorDeViagem.Model
{
    public class Usuario : EntityBase
    {
        public Usuario(long matricula, string nomeCompleto, string email, TipoDeUsuario tipoDeUsuario) 
        {
            Matricula = matricula;
            NomeCompleto = nomeCompleto;
            Email = email;
            TipoDeUsuario = tipoDeUsuario;
            Ativo = true;
            PrimeiroAcesso = true;
            GerarSenha();
        }
        public long Matricula { get; private set; }
        public string Email { get; private set; }
        public string NomeCompleto { get; private set; } = String.Empty;
        public TipoDeUsuario TipoDeUsuario { get; private set; }
        public string Senha { get;  private set; } = String.Empty;
        public virtual ICollection<Viagem> ViagensSolicitadas { get; private set; } 
        public virtual ICollection<Viagem> ViagensAprovadas { get; private set; } 
        public DateTime? UltimoLogin { get; private set; }   
        public bool Ativo { get; private set; } 

        public bool PrimeiroAcesso { get; private set; }

        public void UpdateLastLoginUser()
        => UltimoLogin = DateTime.Now;

        public void RemoveFlagFirstLogin()
        => PrimeiroAcesso = false;

        public void ConvertPassToHash(string hashPassword)
        => Senha = hashPassword;

        private void GerarSenha()
        {
            var caracteresEspeciais = new[] { '@', '-', ')', '(', '%', '#', '*', '#', '_' };
            var alfabeto = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var numeros = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var todosOsCaracteres = new string(caracteresEspeciais) + new string(alfabeto) + new string(alfabeto).ToLower() + new string(numeros);

            int comprimentoDaSenha = 10;

            var senha = String.Empty;

            while (
                !senha.Any(char.IsNumber) || !senha.Any(char.IsUpper) || !senha.Any(char.IsLower) ||
                 senha.Intersect(caracteresEspeciais).Count() != 2
            )
            {
                senha = new string(Enumerable.Range(0, comprimentoDaSenha)
               .Select(_ => todosOsCaracteres[Random.Shared.Next(0, todosOsCaracteres.Length)]).ToArray());
            }

            Senha = senha;
        }

    }


}
