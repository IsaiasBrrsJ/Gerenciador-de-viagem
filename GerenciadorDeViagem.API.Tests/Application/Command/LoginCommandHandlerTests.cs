using GerenciadorDeViagemApi.Application.Command.LoginCommand;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using Moq;

namespace GerenciadorDeViagem.API.Tests.Application.Command
{
    public class LoginCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnToken()
        {
            //Arrange
            var usuarioRepository = new Mock<IUserRepository>();
            var hashPassword = new Mock<IHashPasswordServices>();
            var authService = new Mock<IAuthServices>();

            var loginCommand = new LoginCommand()
            {
                Matricula = 1234,
                Password = "asdasdasd@asd"
            };

            var loginCommandHandler = new LoginCommandHandler(
                usuarioRepository.Object,
                hashPassword.Object,
                authService.Object
                );

            //Act
            var acesso = await loginCommandHandler.Handle(loginCommand,  CancellationToken.None);

            //Assert

            Assert.Empty(acesso.token);

        }
    }
}
