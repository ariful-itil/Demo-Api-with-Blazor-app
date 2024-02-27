using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.Computers;
using Queries.Computers;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class ComputersController : ControllerBase
            {
            private IMediator mediator;
            public ComputersController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<Computers>> GetAll()
        {
            var data = new GetAllComputers();
            return await mediator.Send(data);
        }
            
            [HttpGet("{SLNo}")]
            public async Task<IQueryable<Computers>> GetFilteredByKeysAsyn(Int32 SLNo)
            {
                var data = new GetComputersOnKeys(SLNo);
                return await mediator.Send(data);
            }

           [HttpGet("{SLNo}")]
            public async Task<IQueryable<Computers>> GetOnConditionAsyn(Int32 SLNo)
            {
                var data = new GetComputersOnCondition(x=> x.SLNo == SLNo);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] Computers model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertComputers(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] Computers model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateComputers(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] Computers model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateComputers(x=>x.SLNo == model.SLNo,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{SLNo}")]
            public async Task<ResultViewModel> DeleteAsyn(Int32 SLNo)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteComputers(SLNo);
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
    
