using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.ApplicantValidPhotoInfo;
using Queries.ApplicantValidPhotoInfo;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class ApplicantValidPhotoInfoController : ControllerBase
            {
            private IMediator mediator;
            public ApplicantValidPhotoInfoController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<ApplicantValidPhotoInfo>> GetAll()
        {
            var data = new GetAllApplicantValidPhotoInfo();
            return await mediator.Send(data);
        }
            
            [HttpGet("{SlNumber}")]
            public async Task<IQueryable<ApplicantValidPhotoInfo>> GetFilteredByKeysAsyn(Int32 SlNumber)
            {
                var data = new GetApplicantValidPhotoInfoOnKeys(SlNumber);
                return await mediator.Send(data);
            }

           [HttpGet("{SlNumber}")]
            public async Task<IQueryable<ApplicantValidPhotoInfo>> GetOnConditionAsyn(Int32 SlNumber)
            {
                var data = new GetApplicantValidPhotoInfoOnCondition(x=> x.SlNumber == SlNumber);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] ApplicantValidPhotoInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertApplicantValidPhotoInfo(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] ApplicantValidPhotoInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateApplicantValidPhotoInfo(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] ApplicantValidPhotoInfo model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateApplicantValidPhotoInfo(x=>x.SlNumber == model.SlNumber,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{SlNumber}")]
            public async Task<ResultViewModel> DeleteAsyn(Int32 SlNumber)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteApplicantValidPhotoInfo(SlNumber);
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
    
