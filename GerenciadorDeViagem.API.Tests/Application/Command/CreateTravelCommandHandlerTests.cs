using GerenciadorDeViagem.Model;
using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Application.Command.CreateTravelCommand;
using GerenciadorDeViagemApi.Core.Repositories;
using Moq;
using System.Diagnostics;

namespace GerenciadorDeViagem.API.Tests.CommandTests.CreateTravelCommandTests
{

    public class CreateTravelCommandHandlerTests
    {
        [Fact]

        public async Task InputDataIsOk_Executed_ReturnTravelId() //When Given Then
        {
            //AAA

            //Arrange
            var travelRepository = new Mock<ITravelRepository>();

            var createTravelCommand = new CreateTravelCommand()
            {
                DataIda = DateTime.Now.AddDays(5),
                DataVolta = DateTime.Now.AddDays(-30),
                Destino = "acre",
                MatriculaAprovador = 1234,
                TipoTransporte = TipoTransporte.Aviao,
                MatriculaSolicitante = 5531
            };

            var createTravelCommandHandler = new CreateTravelCommandHandler(travelRepository.Object);

            //Act
            var id =  await createTravelCommandHandler.Handle(createTravelCommand, new CancellationToken());

            //Assert

            travelRepository.Verify(_ => _.ScheduleTrip(It.IsAny<Viagem>()), Times.Once);
        }
    }
}
