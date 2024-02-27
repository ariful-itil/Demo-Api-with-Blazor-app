using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.BranchInfo;
using Queries.BranchInfo;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class BranchInfoController : ControllerBase
            {
            private IMediator mediator;
            public BranchInfoController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<BranchInfo>> GetAll()
        {
            var data = new GetAllBranchInfo();
            return await mediator.Send(data);
        }
            
            [HttpGet("{BranchCode}")]
            public async Task<IQueryable<BranchInfo>> GetFilteredByKeysAsyn(string BranchCode)
            {
                var data = new GetBranchInfoOnKeys(BranchCode);
                return await mediator.Send(data);
            }

           [HttpGet("{BranchCode}")]
            public async Task<IQueryable<BranchInfo>> GetOnConditionAsyn(string BranchCode)
            {
                var data = new GetBranchInfoOnCondition(x=> x.BranchCode == BranchCode);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] BranchInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertBranchInfo(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] BranchInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateBranchInfo(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] BranchInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateBranchInfo(x=>x.BranchCode == model.BranchCode,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{BranchCode}")]
            public async Task<ResultViewModel> DeleteAsyn(string BranchCode)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteBranchInfo(BranchCode);
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
    
