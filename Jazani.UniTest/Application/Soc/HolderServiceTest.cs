using AutoFixture;
using AutoMapper;
using Jazani.Application.Soc.Dtos.Holders;
using Jazani.Application.Soc.Dtos.Holders.Profiles;
using Jazani.Application.Soc.Services;
using Jazani.Application.Soc.Services.Implementations;
using Jazani.Domain.Soc.Models;
using Jazani.Domain.Soc.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UniTest.Application.Soc
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        Mock<ILogger<HolderService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockHolderRepository = new Mock<IHolderRepository>();

            _mockILogger = new Mock<ILogger<HolderService>>();
        }

        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {

            // Arrange
            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);


            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);


            HolderDto holderDto = await holderService.FindByIdAsync(holder.Id);

            // Assert

            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5)
                .ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);

            // Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);

            IReadOnlyList<HolderDto> investmentDtos = await holderService.FindAllAsync();

            // Assert
            Assert.Equal(holders.Count, investmentDtos.Count);
        }
    }
}
