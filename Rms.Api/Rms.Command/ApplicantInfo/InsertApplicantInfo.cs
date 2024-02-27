using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantInfo
{

	public record InsertApplicantInfo(Rms.Models.ApplicantInfo Model): IRequest<ResultViewModel>;

}
