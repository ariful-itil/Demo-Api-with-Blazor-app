using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.CommonCode;
using Queries.CommonCode;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class CommonCodeController : ControllerBase
            {
            private IMediator mediator;
            public CommonCodeController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<CommonCode>> GetAll()
        {
            var data = new GetAllCommonCode();
            return await mediator.Send(data);
        }
            
            [HttpGet("{BankCode}/{Code}")]
            public async Task<IQueryable<CommonCode>> GetFilteredByKeysAsyn(string BankCode,string Code)
            {
                var data = new GetCommonCodeOnKeys(BankCode,Code);
                return await mediator.Send(data);
            }

           [HttpGet("{BankCode}/{Code}")]
            public async Task<IQueryable<CommonCode>> GetOnConditionAsyn(string BankCode,string Code)
            {
                var data = new GetCommonCodeOnCondition(x=> x.BankCode == BankCode && x.Code == Code);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] CommonCode model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertCommonCode(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] CommonCode model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateCommonCode(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] CommonCode model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateCommonCode(x=>x.BankCode == model.BankCode && x.Code == model.Code,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{BankCode}/{Code}")]
            public async Task<ResultViewModel> DeleteAsyn(string BankCode,string Code)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteCommonCode(BankCode,Code);
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
    
