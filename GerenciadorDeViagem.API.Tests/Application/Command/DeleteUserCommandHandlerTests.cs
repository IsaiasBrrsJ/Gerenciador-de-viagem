
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Application.Command.DeleteUserCommand;
using Moq;
using MediatR;

namespace GerenciadorDeViagem.API.Tests.Application.Command
{
    public class DeleteUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOK_Executed_DeleteAndReturnUnitValue()
        {
            //Arrange

            var userRepository = new Mock<IUserRepository>();

            var deleteUserCommand = new DeleteUserCommand(matricula: 1234);

            var deleteUserCommandHandler = new DeleteUserCommandHandler(userRepository.Object);
            //Act

            var empty = await  deleteUserCommandHandler.Handle(deleteUserCommand, new CancellationToken());

            //Assert
            Assert.True((empty) is Unit);

            userRepository.Verify(_ => _.Delete(It.IsAny<long>()), Times.Once);

        }
    }
}
