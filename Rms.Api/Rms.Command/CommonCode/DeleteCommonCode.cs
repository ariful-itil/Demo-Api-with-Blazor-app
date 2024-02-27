using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.CommonCode
{

	public record DeleteCommonCode(string BankCode,string Code): IRequest<ResultViewModel>;

}
