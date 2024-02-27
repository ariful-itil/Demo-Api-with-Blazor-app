using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantValidPhotoInfo
{

	public record SaveUpdateApplicantValidPhotoInfo(Expression<Func<Rms.Models.ApplicantValidPhotoInfo,bool>>expression,Rms.Models.ApplicantValidPhotoInfo Model): IRequest<ResultViewModel>;

}
