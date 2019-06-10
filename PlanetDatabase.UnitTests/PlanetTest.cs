using Microsoft.AspNetCore.Mvc;
using Moq;
using PlanetDatabase.Controllers;
using PlanetDatabase.Core.Services.Planets;
using PlanetDatabase.Data.Entities;
using PlanetDatabase.Data.Models.Planet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PlanetDatabase.UnitTests
{
    public class PlanetTest : IDisposable
    {
        private readonly Mock<IPlanetService> _planetsServiceMock;
        private readonly PlanetsController _sut;

        public PlanetTest()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Planet, PlanetListDto>();
            });

            _planetsServiceMock = new Mock<IPlanetService>();
            _sut = new PlanetsController(_planetsServiceMock.Object);
        }

        [Fact]
        public async Task Should_Return_200_Result()
        {
            var planets = new List<Planet>
            {
                new Planet { Id = 1, PlanetName = "Mercury", DistFromSun = 57.9M },
                new Planet { Id = 2, PlanetName = "Venus", DistFromSun = 108.2M },
                new Planet { Id = 3, PlanetName = "Earth", DistFromSun = 149.6M }
            };

            _planetsServiceMock.Setup(x => x.GetAllPlanets()).ReturnsAsync(planets);
            var result = await _sut.GetAllPlanets();
            var okResult = result as OkObjectResult;

            Assert.IsType<List<PlanetListDto>>(okResult.Value);
            _planetsServiceMock.Verify(x => x.GetAllPlanets());
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task Should_Return_204_No_Content()
        {
            var planets = new List<Planet>();
            _planetsServiceMock.Setup(x => x.GetAllPlanets()).ReturnsAsync(planets);

            var result = await _sut.GetAllPlanets();
            var notContentResult = result as NoContentResult;

            Assert.Equal(204, notContentResult.StatusCode);
        }

        public void Dispose()
        {
            AutoMapper.Mapper.Reset();
        }
    }
}
