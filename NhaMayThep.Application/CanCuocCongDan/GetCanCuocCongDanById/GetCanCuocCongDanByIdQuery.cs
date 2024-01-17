using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanById
{
    public class GetCanCuocCongDanByIdQuery : IRequest<CanCuocCongDanDto>, IQuery
    {
        public GetCanCuocCongDanByIdQuery()
        {

        }
        public GetCanCuocCongDanByIdQuery(string canCuocCongDan)
        {
            CanCuocCongDan = canCuocCongDan;
        }

        public string CanCuocCongDan { get; set; }
    }
}
