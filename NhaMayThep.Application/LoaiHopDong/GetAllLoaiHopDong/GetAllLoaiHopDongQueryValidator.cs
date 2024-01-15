using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.GetAllLoaiHopDong
{
    public class GetAllLoaiHopDongQueryValidator : AbstractValidator<GetAllLoaiHopDongQuery>
    {
        public GetAllLoaiHopDongQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
