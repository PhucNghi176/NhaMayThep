using FluentValidation;
using NhaMayThep.Application.LoaiNghiPhep.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.GetAll
{
    public class GetAllValidator : AbstractValidator<GetAllLSNPQuery>
    {

        public GetAllValidator() { }
    }
}
