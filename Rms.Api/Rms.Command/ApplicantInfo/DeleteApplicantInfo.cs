using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantInfo
{

	public record DeleteApplicantInfo(Int64 SerialNo): IRequest<ResultViewModel>;

}
