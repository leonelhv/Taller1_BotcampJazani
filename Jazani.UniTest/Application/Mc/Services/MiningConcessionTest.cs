using AutoFixture;
using AutoMapper;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions.Profiles;
using Jazani.Taller.Aplication.Mc.Services;
using Jazani.Taller.Aplication.Mc.Services.Implemetations;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UniTest.Application.Mc.Services
{
    public class MiningConcessionTest
    {
        Mock<IMiningConcessionRepository> _mockMiningConcessionRepository;
        Mock<ILogger<MiningConcessionService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;


        public MiningConcessionTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MiningConcessionProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockMiningConcessionRepository = new Mock<IMiningConcessionRepository>();

            _mockILogger = new Mock<ILogger<MiningConcessionService>>();
        }
        [Fact]
        public async void returnMiningConcessionDtoWhenFindByIdAsync()
        {

            // Arrange
            MiningConcession mining = _fixture.Create<MiningConcession>();

            _mockMiningConcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mining);


            // Act
            IMiningConcessionService miningService = new MiningConcessionService(_mockMiningConcessionRepository.Object, _mapper, _mockILogger.Object);


            MiningConcessionDto miningConcessionDto = await miningService.FindByIdAsync(mining.Id);

            // Assert

            Assert.Equal(mining.Name, miningConcessionDto.Name);
        }

        [Fact]
        public async void returnMiningConcessionDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<MiningConcession> minings = _fixture.CreateMany<MiningConcession>(5)
                .ToList();

            _mockMiningConcessionRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(minings);

            // Act
            IMiningConcessionService miningService = new MiningConcessionService(_mockMiningConcessionRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<MiningConcessionDto> miningConcessionDtos = await miningService.FindAllAsync();

            // Assert
            Assert.Equal(minings.Count, miningConcessionDtos.Count);
        }

        [Fact]
        public async void returnMiningConcessionDtoWhenCreateAsync()
        {

            // Arrage
            MiningConcession mining = new()
            {
                Id = 1,
                Name = "Inversion en exploracion",
                Code = "Inversion en exploracion",
                MineralTypeId = 1,
                OriginId = 1,
                TypeId = 1,
                SituationId = 1,
                MiningUnitId = 1,
                ConditionId = 1,
                StateManagementId = 1,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMiningConcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<MiningConcession>()))
                .ReturnsAsync(mining);


            // Act
            MiningConcessionSaveDto miningSaveDto = new()
            {
                Name = mining.Name,
                Code = mining.Code,
                ConditionId = mining.ConditionId,
                MineralTypeId = mining.MineralTypeId,
                MiningUnitId = mining.MiningUnitId,
                OriginId = mining.OriginId,
                SituationId = mining.SituationId,
                StateManagementId = mining.StateManagementId,
                TypeId = mining.TypeId

            };

            IMiningConcessionService miningService = new MiningConcessionService(_mockMiningConcessionRepository.Object, _mapper, _mockILogger.Object);
            MiningConcessionDto miningDto = await miningService.CreateAsync(miningSaveDto);


            // Assert
            Assert.Equal(miningSaveDto.Name, miningDto.Name);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            MiningConcession mining = new()
            {
                Id = 1,
                Name = "Inversion en exploracion",
                Code = "Inversion en exploracion",
                MineralTypeId = 1,
                OriginId = 1,
                TypeId = 1,
                SituationId = 1,
                MiningUnitId = 1,
                ConditionId = 1,
                StateManagementId = 1,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMiningConcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mining);

            _mockMiningConcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<MiningConcession>()))
                .ReturnsAsync(mining);

            // Act
            MiningConcessionSaveDto miningSaveDto = new()
            {
                Name = mining.Name,
                Code = mining.Code,
                ConditionId = mining.ConditionId,
                MineralTypeId = mining.MineralTypeId,
                MiningUnitId = mining.MiningUnitId,
                OriginId = mining.OriginId,
                SituationId = mining.SituationId,
                StateManagementId = mining.StateManagementId,
                TypeId = mining.TypeId

            };

            IMiningConcessionService miningService = new MiningConcessionService(_mockMiningConcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningConcessionDto miningDto = await miningService.EditAsync(id, miningSaveDto);


            // Assert
            Assert.Equal(mining.Id, miningDto.Id);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            MiningConcession mining = new()
            {
                Id = 1,
                Name = "Inversion en exploracion",
                Code = "Inversion en exploracion",
                MineralTypeId = 1,
                OriginId = 1,
                TypeId = 1,
                SituationId = 1,
                MiningUnitId = 1,
                ConditionId = 1,
                StateManagementId = 1,
                State = true,
                RegistrationDate = DateTime.Now
            };


            _mockMiningConcessionRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mining);

            _mockMiningConcessionRepository
                .Setup(r => r.SaveAsync(It.IsAny<MiningConcession>()))
                .ReturnsAsync(mining);

            // Act


            IMiningConcessionService miningService = new MiningConcessionService(_mockMiningConcessionRepository.Object, _mapper, _mockILogger.Object);

            MiningConcessionDto miningDto = await miningService.DisabledAsync(id);


            // Assert
            Assert.Equal(mining.State, miningDto.State);
        }

    }
}
