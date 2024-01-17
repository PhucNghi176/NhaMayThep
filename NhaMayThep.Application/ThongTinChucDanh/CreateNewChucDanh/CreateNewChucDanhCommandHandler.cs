using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh
{
    public class CreateNewChucDanhCommandHandler : IRequestHandler<CreateNewChucDanhCommand, int>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        public CreateNewChucDanhCommandHandler(IChucDanhRepository chucDanhRepository)
        {
            _chucDanhRepository = chucDanhRepository;
        }
        public async Task<int> Handle(CreateNewChucDanhCommand command, CancellationToken cancellationToken)
        {
            var add = new ThongTinChucDanhEntity()
            {
                Name = command.TenChucDanh
            };
            _chucDanhRepository.Add(add);
            await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.ID;
        }
    }
}
