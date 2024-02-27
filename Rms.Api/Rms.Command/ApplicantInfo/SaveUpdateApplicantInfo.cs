using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantInfo
{

	public record SaveUpdateApplicantInfo(Expression<Func<Rms.Models.ApplicantInfo,bool>>expression,Rms.Models.ApplicantInfo Model): IRequest<ResultViewModel>;

}
