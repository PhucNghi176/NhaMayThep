using MediatR;
using System;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class CreateTrinhDoHocVanCommand : IRequest<string>
    {
        public string TenTrinhDo { get; set; }

        public static CreateTrinhDoHocVanCommand Create(string tenTrinhDo, string nguoiTaoId)
        {
            return new CreateTrinhDoHocVanCommand
            {
                TenTrinhDo = tenTrinhDo,
            };
        }
    }
}
