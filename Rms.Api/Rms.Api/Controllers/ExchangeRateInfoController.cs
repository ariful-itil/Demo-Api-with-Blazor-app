using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.ExchangeRateInfo;
using Queries.ExchangeRateInfo;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("Rms/api/[controller]/[action]")]
    [ApiController]

    public class ExchangeRateInfoController : ControllerBase
    {
        private IMediator mediator;
        public ExchangeRateInfoController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IQueryable<ExchangeRateInfo>> GetAll()
        {
            var data = new GetAllExchangeRateInfo();
            return await mediator.Send(data);
        }

        [HttpGet("{BranchCode}/{TransDate}/{CurrencyCode}/{SLNO}/{ExchangeRateType}")]
        public async Task<IQueryable<ExchangeRateInfo>> GetFilteredByKeysAsyn(string BranchCode, DateOnly TransDate, string CurrencyCode, byte SLNO, string ExchangeRateType)
        {
            var data = new GetExchangeRateInfoOnKeys(BranchCode, TransDate, CurrencyCode, SLNO, ExchangeRateType);
            return await mediator.Send(data);
        }

        [HttpGet("{BranchCode}/{TransDate}/{CurrencyCode}/{SLNO}/{ExchangeRateType}")]
        public async Task<IQueryable<ExchangeRateInfo>> GetOnConditionAsyn(string BranchCode, DateOnly TransDate, string CurrencyCode, byte SLNO, string ExchangeRateType)
        {
            var data = new GetExchangeRateInfoOnCondition(x => x.BranchCode == BranchCode && x.TransDate == TransDate && x.CurrencyCode == CurrencyCode && x.SLNO == SLNO && x.ExchangeRateType == ExchangeRateType);
            return await mediator.Send(data);
        }

        [HttpPost]
        public async Task<ResultViewModel> SaveAsyn([FromBody] ExchangeRateInfo model)
        {
            ResultViewModel responses = new ResultViewModel();
            try
            {
                var data = new InsertExchangeRateInfo(model);
                responses = await mediator.Send(data);
                HttpContext.Response.StatusCode = responses.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
            return responses;
        }

        [HttpPost]
        public async Task<ResultViewModel> UpdateAsyn([FromBody] ExchangeRateInfo model)
        {
            ResultViewModel responses = new ResultViewModel();
            try
            {
                var data = new UpdateExchangeRateInfo(model);
                responses = await mediator.Send(data);
                HttpContext.Response.StatusCode = responses.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
            return responses;
        }

        [HttpPost]
        public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] ExchangeRateInfo model)
        {
            ResultViewModel responses = new ResultViewModel();
            try
            {
                var data = new SaveUpdateExchangeRateInfo(x => x.BranchCode == model.BranchCode && x.TransDate == model.TransDate && x.CurrencyCode == model.CurrencyCode && x.SLNO == model.SLNO && x.ExchangeRateType == model.ExchangeRateType, model);
                responses = await mediator.Send(data);
                HttpContext.Response.StatusCode = responses.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
            return responses;
        }

        [HttpDelete("{BranchCode}/{TransDate}/{CurrencyCode}/{SLNO}/{ExchangeRateType}")]
        public async Task<ResultViewModel> DeleteAsyn(string BranchCode, DateOnly TransDate, string CurrencyCode, byte SLNO, string ExchangeRateType)
        {
            ResultViewModel responses = new ResultViewModel();
            try
            {
                var data = new DeleteExchangeRateInfo(BranchCode, TransDate, CurrencyCode, SLNO, ExchangeRateType);
                responses = await mediator.Send(data);
                HttpContext.Response.StatusCode = responses.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
            return responses;
        }
    }
}
    
