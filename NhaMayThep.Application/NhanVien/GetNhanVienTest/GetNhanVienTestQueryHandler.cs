using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVienTest
{
    public class GetNhanVienTestQueryHandler : IRequestHandler<GetNhanVienTestQuery, List<NhanVienDto>>
    {

        private readonly INhanVienRepository _repository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        private readonly IMapper _mapper;

        public GetNhanVienTestQueryHandler(INhanVienRepository repository, IChucVuRepository chucVuRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository, IMapper mapper)
        {
            _repository = repository;
            _chucVuRepository = chucVuRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
            _mapper = mapper;
        }


        public async Task<List<NhanVienDto>> Handle(GetNhanVienTestQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.FindAllAsync(_ => _.NgayXoa == null, cancellationToken);
            var chucvu = await _chucVuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var tinhtranglamviec = await _tinhTrangLamViecRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var returnList = list.MapToNhanVienDtoList(_mapper, chucvu, tinhtranglamviec);
            return returnList;
        }
    }
}
