using JmCalculator.Service.Processors;
using JmCalculator.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JmCalculator.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JmPriceController : ControllerBase
    {
        private readonly IJmPriceProcessor _priceProcessor;
        public JmPriceController(IJmPriceProcessor priceProcessor)
        {
            _priceProcessor = priceProcessor;
        }

        [HttpGet()]
        public async Task<ActionResult> GetPrice()
        {
            try
            {
                var price = await _priceProcessor.GetPriceRequest();

                return Ok(price);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpGet("price")]
        public async Task<ActionResult> GetPrice([FromBody] JmPriceRequest priceRequest)
        {
            try
            {
                var price = await _priceProcessor.CalculatePrice(priceRequest);

                return Ok(price);
            }
            catch(Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpGet("options")]
        public async Task<ActionResult> GetOptions([FromBody] JmPriceRequest priceRequest)
        {
            try
            {
                var options = await _priceProcessor.GetOptionResponse(priceRequest);

                return Ok(options);
            }
            catch(Exception x)
            {
                return BadRequest(x.Message);
            }

        }
    }
}
