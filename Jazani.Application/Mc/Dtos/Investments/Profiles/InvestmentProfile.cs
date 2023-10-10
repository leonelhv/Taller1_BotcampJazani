using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Core.Paginations;
using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Aplication.Mc.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<Investment, InvestmentDto>().ReverseMap();
            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();



            CreateMap<Investment, InvesmentFilterDto>().ReverseMap();


            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvesmentFilterDto>>()
                .ReverseMap();
        }
    }
}
