using MediatR;

namespace NhaMayThep.Application.TrinhDoHocVan.Create
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
