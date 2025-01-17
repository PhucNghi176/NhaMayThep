﻿using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
namespace NhaMayThep.Infrastructure.Repositories;
public class LichSuNghiPhepRepository : RepositoryBase<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepNhanVienEntity, ApplicationDbContext>, ILichSuNghiPhepRepository
{
    public LichSuNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }



}
