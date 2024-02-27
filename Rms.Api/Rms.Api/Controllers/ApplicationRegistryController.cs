using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.ApplicationRegistry;
using Queries.ApplicationRegistry;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class ApplicationRegistryController : ControllerBase
            {
            private IMediator mediator;
            public ApplicationRegistryController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<ApplicationRegistry>> GetAll()
        {
            var data = new GetAllApplicationRegistry();
            return await mediator.Send(data);
        }
            
            [HttpGet("{CountryCode}/{BankCode}/{RegistryKey}")]
            public async Task<IQueryable<ApplicationRegistry>> GetFilteredByKeysAsyn(string CountryCode,string BankCode,string RegistryKey)
            {
                var data = new GetApplicationRegistryOnKeys(CountryCode,BankCode,RegistryKey);
                return await mediator.Send(data);
            }

           [HttpGet("{CountryCode}/{BankCode}/{RegistryKey}")]
            public async Task<IQueryable<ApplicationRegistry>> GetOnConditionAsyn(string CountryCode,string BankCode,string RegistryKey)
            {
                var data = new GetApplicationRegistryOnCondition(x=> x.CountryCode == CountryCode && x.BankCode == BankCode && x.RegistryKey == RegistryKey);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] ApplicationRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertApplicationRegistry(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] ApplicationRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateApplicationRegistry(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] ApplicationRegistry model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateApplicationRegistry(x=>x.CountryCode == model.CountryCode && x.BankCode == model.BankCode && x.RegistryKey == model.RegistryKey,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{CountryCode}/{BankCode}/{RegistryKey}")]
            public async Task<ResultViewModel> DeleteAsyn(string CountryCode,string BankCode,string RegistryKey)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteApplicationRegistry(CountryCode,BankCode,RegistryKey);
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
    
