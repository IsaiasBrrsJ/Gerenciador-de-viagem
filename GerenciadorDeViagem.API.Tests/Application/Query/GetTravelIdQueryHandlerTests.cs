using GerenciadorDeViagemApi.Application.Querie.GetTravelId;
using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Repositories;
using Moq;

namespace GerenciadorDeViagem.API.Tests.Application.Query
{
    public class GetTravelIdQueryHandlerTests
    {
        [Fact]

        public async Task InputDataIsOk_Return_Travel()
        {
            //Arrange
            var travelRepository = new Mock<ITravelRepository>();

            var GetTravelIdQuery = new GetTravelIdQuery(1223123);

            var GetTravelIdQueryHandler = new GetTravelIdQueryHandler(travelRepository.Object);
            //Act

            var travel = await GetTravelIdQueryHandler.Handle(GetTravelIdQuery, CancellationToken.None);
            //Assert

            //Assert.Fail(travel.mensagemErro);
            Assert.IsType<TravelDTO>(travel.viagens);


        }
    }
}
