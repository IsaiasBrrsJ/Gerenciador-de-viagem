using GerenciadorDeViagem.Model;
using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Application.Command.CreateUserCommand;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using Moq;

namespace GerenciadorDeViagem.API.Tests.Application.Command
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Return_ExecutedUserId()
        {
            //Arrange

            var userRepository = new Mock<IUserRepository>();
            var hashPassword = new Mock<IHashPasswordServices>();
            var emailService = new Mock<IEmailService>();
            var emailServiceFactory = new Mock<IEmailServiceFactory>();


        var createUserCommand = new CreateUserCommand()
            {
                Email = "teste@email.com",
                Matricula = 12344,
                NomeCompleto = "teste teste tete",
                TipoDeUsuario = TipoDeUsuario.Administrador
            };

            var createUserCommandHandler = new CreateUserCommandHandler(
                userRepository.Object,
                hashPassword.Object,
                emailService.Object,
                emailServiceFactory.Object
                );

            //Act
            var id = await createUserCommandHandler.Handle(createUserCommand, CancellationToken.None);

            //Assert
            userRepository.Verify(_ => _.AddUserAsync(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
