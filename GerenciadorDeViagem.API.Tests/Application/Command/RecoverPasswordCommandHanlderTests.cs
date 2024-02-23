using GerenciadorDeViagemApi.Application.Command.RecoverPasswordCommand;
using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using Moq;

namespace GerenciadorDeViagem.API.Tests.Application.Command
{
    public class RecoverPasswordCommandHanlderTests
    {

        [Fact]
        public async Task InputDataIsOK_Executed_ReturnTrue()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var emailService = new Mock<IEmailService>();
            var emailServiceFactory = new Mock<IEmailServiceFactory>();

            var recoverPasswordCommand = new RecoverPasswordCommand()
            {
                Email = "testedoemail@gmail.com"
            };

            var recoverPasswordCommandHandler = new RecoverPasswordCommandHandler(
                 emailService.Object,
                 userRepository.Object,
                 emailServiceFactory.Object
                );

            //Act
            var recoverPasswordIsTrue = await recoverPasswordCommandHandler.Handle(recoverPasswordCommand, CancellationToken.None);

            //Assert

            Assert.False(recoverPasswordIsTrue);
            userRepository.Verify(_ => _.GetUserByEmail(recoverPasswordCommand.Email), Times.Once);
        }
    }
}
