using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.Remittance;
using Queries.Remittance;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class RemittanceController : ControllerBase
            {
            private IMediator mediator;
            public RemittanceController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<Remittance>> GetAll()
        {
            var data = new GetAllRemittance();
            return await mediator.Send(data);
        }
            
            [HttpGet("{IdentityNo}")]
            public async Task<IQueryable<Remittance>> GetFilteredByKeysAsyn(Int64 IdentityNo)
            {
                var data = new GetRemittanceOnKeys(IdentityNo);
                return await mediator.Send(data);
            }

           [HttpGet("{IdentityNo}")]
            public async Task<IQueryable<Remittance>> GetOnConditionAsyn(Int64 IdentityNo)
            {
                var data = new GetRemittanceOnCondition(x=> x.IdentityNo == IdentityNo);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] Remittance model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertRemittance(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] Remittance model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateRemittance(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] Remittance model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateRemittance(x=>x.IdentityNo == model.IdentityNo,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{IdentityNo}")]
            public async Task<ResultViewModel> DeleteAsyn(Int64 IdentityNo)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteRemittance(IdentityNo);
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
    
