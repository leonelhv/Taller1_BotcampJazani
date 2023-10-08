﻿using Jazani.Application.Mc.Services;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvestmentconceptController : ControllerBase
    {
        private readonly IInvestmentconceptService _investmentconceptService;

        public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
        {
            _investmentconceptService = investmentconceptService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvestmentconceptDto>> Get()
        {
            return await _investmentconceptService.FindAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<InvestmentconceptDto?> Get(int id)
        {
            return await _investmentconceptService.FindByIdAsync(id);
        }

        [HttpPost]
        public async Task<InvestmentconceptDto> Post([FromBody] InvestmentconceptSaveDto investmentconceptSave)
        {
            return await _investmentconceptService.CreateAsync(investmentconceptSave);
        }

        [HttpPut("{id}")]
        public async Task<InvestmentconceptDto> Put(int id, [FromBody] InvestmentconceptSaveDto investmentconceptSave)
        {
            return await _investmentconceptService.EditAsync(id, investmentconceptSave);
        }

        [HttpDelete("{id}")]
        public async Task<InvestmentconceptDto> Disabled(int id)
        {
            return await _investmentconceptService.DisabledAsync(id);
        }
    }
}