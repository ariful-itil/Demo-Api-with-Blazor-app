using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.FeesInfo;
using Queries.FeesInfo;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class FeesInfoController : ControllerBase
            {
            private IMediator mediator;
            public FeesInfoController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<FeesInfo>> GetAll()
        {
            var data = new GetAllFeesInfo();
            return await mediator.Send(data);
        }
            
            [HttpGet("{BranchCode}/{AccountType}/{TransType}/{SLNO}")]
            public async Task<IQueryable<FeesInfo>> GetFilteredByKeysAsyn(string BranchCode,string AccountType,string TransType,byte SLNO)
            {
                var data = new GetFeesInfoOnKeys(BranchCode,AccountType,TransType,SLNO);
                return await mediator.Send(data);
            }

           [HttpGet("{BranchCode}/{AccountType}/{TransType}/{SLNO}")]
            public async Task<IQueryable<FeesInfo>> GetOnConditionAsyn(string BranchCode,string AccountType,string TransType,byte SLNO)
            {
                var data = new GetFeesInfoOnCondition(x=> x.BranchCode == BranchCode && x.AccountType == AccountType && x.TransType == TransType && x.SLNO == SLNO);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] FeesInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertFeesInfo(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] FeesInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateFeesInfo(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] FeesInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateFeesInfo(x=>x.BranchCode == model.BranchCode && x.AccountType == model.AccountType && x.TransType == model.TransType && x.SLNO == model.SLNO,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{BranchCode}/{AccountType}/{TransType}/{SLNO}")]
            public async Task<ResultViewModel> DeleteAsyn(string BranchCode,string AccountType,string TransType,byte SLNO)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteFeesInfo(BranchCode,AccountType,TransType,SLNO);
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
    
