using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.BranchRegistry;
using Queries.BranchRegistry;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class BranchRegistryController : ControllerBase
            {
            private IMediator mediator;
            public BranchRegistryController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<BranchRegistry>> GetAll()
        {
            var data = new GetAllBranchRegistry();
            return await mediator.Send(data);
        }
            
            [HttpGet("{BranchCode}/{RegistryKey}")]
            public async Task<IQueryable<BranchRegistry>> GetFilteredByKeysAsyn(string BranchCode,string RegistryKey)
            {
                var data = new GetBranchRegistryOnKeys(BranchCode,RegistryKey);
                return await mediator.Send(data);
            }

           [HttpGet("{BranchCode}/{RegistryKey}")]
            public async Task<IQueryable<BranchRegistry>> GetOnConditionAsyn(string BranchCode,string RegistryKey)
            {
                var data = new GetBranchRegistryOnCondition(x=> x.BranchCode == BranchCode && x.RegistryKey == RegistryKey);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] BranchRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertBranchRegistry(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] BranchRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateBranchRegistry(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] BranchRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateBranchRegistry(x=>x.BranchCode == model.BranchCode && x.RegistryKey == model.RegistryKey,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{BranchCode}/{RegistryKey}")]
            public async Task<ResultViewModel> DeleteAsyn(string BranchCode,string RegistryKey)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteBranchRegistry(BranchCode,RegistryKey);
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
    
