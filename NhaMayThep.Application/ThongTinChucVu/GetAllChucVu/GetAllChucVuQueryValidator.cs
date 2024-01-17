using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetAllChucVu
{
    public class GetAllChucVuQueryValidator : AbstractValidator<GetAllChucVuQuery>
    {
        public GetAllChucVuQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
