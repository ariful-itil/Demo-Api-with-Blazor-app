using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicantValidPhotoInfo
{

	public record DeleteApplicantValidPhotoInfo(Int32 SlNumber): IRequest<ResultViewModel>;

}
