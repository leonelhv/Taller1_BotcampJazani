using AutoFixture;
using AutoMapper;
using Jazani.Application.Mc.Services;
using Jazani.Application.Mc.Services.Implementations;
using Jazani.Application.Soc.Dtos.Holders.Profiles;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits.Profiles;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes.Profiles;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts.Profiles;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;
using Jazani.Taller.Aplication.Mc.Dtos.Investments.Profiles;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes.Profiles;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions.Profiles;
using Microsoft.Extensions.Logging;
using Moq;

namespace Jazani.UniTest.Application.Mc.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<ILogger<InvestmentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;


        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<InvestmentconceptProfile>();
                c.AddProfile<PeriodTypeProfile>();
                c.AddProfile<MeasureUnitProfile>();
                c.AddProfile<HolderProfile>();
                c.AddProfile<InvestmenttypeProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<ILogger<InvestmentService>>();
        }
        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {

            // Arrange
            Investment invesment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(invesment);


            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);


            InvestmentDto investmentDto = await investmentService.FindByIdAsync(invesment.Id);

            // Assert

            Assert.Equal(invesment.AmountInvested, investmentDto.AmountInvested);
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Investment> invesments = _fixture.CreateMany<Investment>(5)
                .ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(invesments);

            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

            // Assert
            Assert.Equal(invesments.Count, investmentDtos.Count);
        }

        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {

            // Arrage
            Investment investment = new()
            {
                Id = 1,
                AmountInvested = 1000,
                Description = "Inversion en exploracion",
                CurrencyTypeId = 1,
                DeclaredTypeId = 1,
                InvestmentconceptId = 1,
                State = true,
                MiningConcessionId = 1,
                HolderId = 1,
                InvestmentTypeId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto invesmentSaveDto = new()
            {
                AmountInvested = investment.AmountInvested,
                Description = investment.Description,
                CurrencyTypeId = investment.CurrencyTypeId,
                DeclaredTypeId = investment.DeclaredTypeId,
                InvestmentconceptId = (int)investment.InvestmentconceptId,
                MeasureunitId = (int)investment.MeasureunitId,
                MiningConcessionId = investment.MiningConcessionId,
                PeriodtypeId = (int)investment.PeriodtypeId,
                HolderId = investment.HolderId,
                InvestmentTypeId = investment.InvestmentTypeId
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);
            InvestmentDto investmentDto = await investmentService.CreateAsync(invesmentSaveDto);


            // Assert
            Assert.Equal(invesmentSaveDto.Description, investmentDto.Description);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = 1,
                AmountInvested = 1000,
                Description = "Inversion en exploracion",
                CurrencyTypeId = 1,
                DeclaredTypeId = 1,
                InvestmentconceptId = 1,
                State = true,
                MiningConcessionId = 1,
                HolderId = 1,
                InvestmentTypeId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act
            InvestmentSaveDto invesmentSaveDto = new()
            {
                AmountInvested = investment.AmountInvested,
                Description = investment.Description,
                CurrencyTypeId = investment.CurrencyTypeId,
                DeclaredTypeId = investment.DeclaredTypeId,
                InvestmentconceptId = (int)investment.InvestmentconceptId,
                MeasureunitId = (int)investment.MeasureunitId,
                MiningConcessionId = investment.MiningConcessionId,
                PeriodtypeId = (int)investment.PeriodtypeId,
                HolderId = investment.HolderId,
                InvestmentTypeId = investment.InvestmentTypeId
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.EditAsync(id, invesmentSaveDto);


            // Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = 1,
                AmountInvested = 1000,
                Description = "Inversion en exploracion",
                CurrencyTypeId = 1,
                DeclaredTypeId = 1,
                InvestmentconceptId = 1,
                State = true,
                MiningConcessionId = 1,
                HolderId = 1,
                InvestmentTypeId = 1,
                MeasureunitId = 1,
                PeriodtypeId = 1,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act


            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentTypeDto = await investmentService.DisabledAsync(id);


            // Assert
            Assert.Equal(investment.State, investmentTypeDto.State);
        }

    }
}
