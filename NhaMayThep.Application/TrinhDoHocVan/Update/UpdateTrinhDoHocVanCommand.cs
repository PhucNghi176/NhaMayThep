using MediatR;

namespace NhaMayThep.Application.TrinhDoHocVan.Update
{
    public class UpdateTrinhDoHocVanCommand : IRequest
    {
        public int Id { get; set; }
        public string TenTrinhDo { get; set; }

        public static UpdateTrinhDoHocVanCommand Create(string tenTrinhDo, string nguoiCapNhatId)
        {
            return new UpdateTrinhDoHocVanCommand
            {
                TenTrinhDo = tenTrinhDo,
            };
        }
    }
}
