using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantValidPhotoInfo
{

	public record InsertApplicantValidPhotoInfo(Rms.Models.ApplicantValidPhotoInfo Model): IRequest<ResultViewModel>;

}
