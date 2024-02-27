using System;
using Rms.Models;
using System.Linq;
using System.Threading.Tasks;
using Commands.Beneficiary;
using Queries.Beneficiary;
using ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("Rms/api/[controller]/[action]")]
	[ApiController]

            public class BeneficiaryController : ControllerBase
            {
            private IMediator mediator;
            public BeneficiaryController(IMediator _mediator)
            {
                mediator = _mediator;
            }
            
            [HttpGet]            
         public async Task<IQueryable<Beneficiary>> GetAll()
        {
            var data = new GetAllBeneficiary();
            return await mediator.Send(data);
        }
            
            [HttpGet("{BranchCode}/{AGEXIDNO}/{SerialNo}")]
            public async Task<IQueryable<Beneficiary>> GetFilteredByKeysAsyn(string BranchCode,string AGEXIDNO,Int16 SerialNo)
            {
                var data = new GetBeneficiaryOnKeys(BranchCode,AGEXIDNO,SerialNo);
                return await mediator.Send(data);
            }

           [HttpGet("{BranchCode}/{AGEXIDNO}/{SerialNo}")]
            public async Task<IQueryable<Beneficiary>> GetOnConditionAsyn(string BranchCode,string AGEXIDNO,Int16 SerialNo)
            {
                var data = new GetBeneficiaryOnCondition(x=> x.BranchCode == BranchCode && x.AGEXIDNO == AGEXIDNO && x.SerialNo == SerialNo);
                return await mediator.Send(data);
            }

            [HttpPost]
            public async Task<ResultViewModel> SaveAsyn([FromBody] Beneficiary model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new InsertBeneficiary(model);
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
            public async Task<ResultViewModel> UpdateAsyn([FromBody] Beneficiary model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new UpdateBeneficiary(model);
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
            public async Task<ResultViewModel> SaveUpdateAsyn([FromBody] Beneficiary model)
            {
                ResultViewModel responses = new ResultViewModel();
                try
               {
                    var data = new SaveUpdateBeneficiary(x=>x.BranchCode == model.BranchCode && x.AGEXIDNO == model.AGEXIDNO && x.SerialNo == model.SerialNo,model);
                    responses = await mediator.Send(data);
                    HttpContext.Response.StatusCode = responses.StatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                return responses;
            }

            [HttpDelete("{BranchCode}/{AGEXIDNO}/{SerialNo}")]
            public async Task<ResultViewModel> DeleteAsyn(string BranchCode,string AGEXIDNO,Int16 SerialNo)
            {
                ResultViewModel responses = new ResultViewModel();
                try
                {
                    var data = new DeleteBeneficiary(BranchCode,AGEXIDNO,SerialNo);
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
    
