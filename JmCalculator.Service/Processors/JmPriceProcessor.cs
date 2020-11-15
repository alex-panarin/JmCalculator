using JmCalculator.Shared.Domain;
using JmCalculator.Service.Repositories;
using JmCalculator.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using JmCalculator.Shared.Validation;
using System.Collections.Generic;
using JmCalculator.Shared.Extensions;

namespace JmCalculator.Service.Processors
{
    public class JmPriceProcessor : IJmPriceProcessor
    {
        private readonly IJmPriceRepository _priceRepository;
        private readonly IJmOptionsRepository _optionsRepository;
        private readonly IJmPriceValidator _validator;

        public JmPriceProcessor(
            IJmPriceRepository priceRepository,
            IJmOptionsRepository optionsRepository,
            IJmPriceValidator validator)
        {
            _priceRepository = priceRepository;
            _optionsRepository = optionsRepository;
            _validator = validator;
        }

        public async Task<JmPriceRequest> GetPriceRequest()
        {
            return await Task.FromResult( new JmPriceRequest());

        }

        public async Task<JmOptionResponse> GetOptionResponse(JmPriceRequest priceRequest)
        {
            _validator.Validate(priceRequest);

            var options = await _optionsRepository.GetAsync(priceRequest.CreateOptionRequest());

            return new JmOptionResponse(options.Select(o => o.CreateDomain()));
        }

        public async Task<JmPriceResponse> CalculatePrice(JmPriceRequest priceRequest)
        {
            _validator.Validate(priceRequest);

            var price = await _priceRepository.GetAsync(priceRequest);

            if (price == null)
                throw new NullReferenceException(nameof(price));

            if (price.Values.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(price.Values), "Cann't find price for specified height");
            
            var priceResponse = new JmPriceResponse()
            {
                PricePerUnit = price.Values[(priceRequest.Width - 500)/100]
            };

            return await CalculateOptions(priceResponse, priceRequest);
        }

        private async Task<JmPriceResponse> CalculateOptions(JmPriceResponse priceResponse, JmPriceRequest priceRequest)
        {
            var options = await _optionsRepository.GetAsync(priceRequest.CreateOptionRequest());

            if (options == null)
                throw new NullReferenceException(nameof(options));

            foreach (var option in options.Where ( op => 
                   op == priceRequest.GuidingRailBracket
                || op == priceRequest.HeadRailBraket
                || op == priceRequest.OperationControl
                || op == priceRequest.LeftGuidingRail
                || op == priceRequest.RightGuidingRail ))
            {
                var optionQuantity = 1;

                if(option.Type == typeof(JmHeadrailBracketTypes).FullName)
                {
                    var quantity = (priceRequest.Width - 400) / 800;
                    optionQuantity = quantity < 2 ? 2 : quantity;
                }
                else if (option.Type == typeof(JmWireBracketTypes).FullName)
                {
                    optionQuantity = 2;
                }
                else if (option.Type == typeof(JmGuidingRailTypes).FullName)
                {
                    var quantity = (priceRequest.Height - 400) / 800;
                    optionQuantity = quantity < 1 ? 2 : quantity * 2;
                }

                priceResponse.PricePerUnit += option.Price * optionQuantity;
            }

            priceResponse.TotalPrice = priceRequest.Quantity * priceResponse.PricePerUnit;

            return priceResponse;
        }
    }
}
