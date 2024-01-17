using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan
{
    public class DeleteCanCuocCongDanCommand : IRequest<string>, ICommand
    {
        public DeleteCanCuocCongDanCommand()
        {

        }
        public DeleteCanCuocCongDanCommand(string canCuocCongDan)
        {
            CanCuocCongDan = canCuocCongDan;
        }

        public string CanCuocCongDan { get; set; }
    }

}

