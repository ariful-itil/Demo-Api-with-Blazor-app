using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.ApplicantInfo;
using Queries.ApplicantInfo;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class ApplicantInfoController : ControllerBase
            {
            private IMediator mediator;
            public ApplicantInfoController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<ApplicantInfo>> GetAll()
        {
            var data = new GetAllApplicantInfo();
            return await mediator.Send(data);
        }
            
            [HttpGet("{SerialNo}")]
            public async Task<IQueryable<ApplicantInfo>> GetFilteredByKeysAsyn(Int64 SerialNo)
            {
                var data = new GetApplicantInfoOnKeys(SerialNo);
                return await mediator.Send(data);
            }

           [HttpGet("{SerialNo}")]
            public async Task<IQueryable<ApplicantInfo>> GetOnConditionAsyn(Int64 SerialNo)
            {
                var data = new GetApplicantInfoOnCondition(x=> x.SerialNo == SerialNo);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] ApplicantInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertApplicantInfo(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] ApplicantInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateApplicantInfo(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] ApplicantInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateApplicantInfo(x=>x.SerialNo == model.SerialNo,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{SerialNo}")]
            public async Task<ResultViewModel> DeleteAsyn(Int64 SerialNo)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteApplicantInfo(SerialNo);
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
    
