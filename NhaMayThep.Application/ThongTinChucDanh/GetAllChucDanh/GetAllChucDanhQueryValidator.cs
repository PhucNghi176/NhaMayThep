using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh
{
    public class GetAllChucDanhQueryValidator : AbstractValidator<GetAllChucDanhQuery>
    {
        public GetAllChucDanhQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
