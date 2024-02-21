namespace GerenciadorDeViagemApi.Core.Services
{
    public interface IHashPasswordServices
    {
      string ComputerHash256(string password);
    }
}
