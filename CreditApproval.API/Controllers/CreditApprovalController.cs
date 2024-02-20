using CreditApproval.API.Models;
using CreditApproval.Domain.Dto;
using CreditApproval.Domain.Entities;
using CreditApproval.Domain.Interfaces;
using CreditApproval.Service.Services;
using CreditApproval.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CreditApproval.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApprovalController : ControllerBase
    {
        private readonly IProcessamentoCreditoService _processamentoCréditoService;

        public CreditApprovalController(IProcessamentoCreditoService processamentoCreditoService)
        {
            _processamentoCréditoService = processamentoCreditoService;
        }

        [HttpPost()]        
        public async Task<IActionResult> PostAsync([FromBody] CreditoDto credit)
        {
            try
            {
                if (credit == null)
                    return NotFound();                

                var resultado = await _processamentoCréditoService.ProcessarCredito(credit);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
