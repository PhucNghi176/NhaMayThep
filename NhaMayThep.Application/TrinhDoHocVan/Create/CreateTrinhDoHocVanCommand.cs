using MediatR;
using System;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class CreateTrinhDoHocVanCommand : IRequest<string>
    {
        public string TenTrinhDo { get; set; }
        public string NguoiTaoID { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public static CreateTrinhDoHocVanCommand Create(string tenTrinhDo, string nguoiTaoId)
        {
            return new CreateTrinhDoHocVanCommand
            {
                TenTrinhDo = tenTrinhDo,
                NguoiTaoID = nguoiTaoId
            };
        }
    }
}
