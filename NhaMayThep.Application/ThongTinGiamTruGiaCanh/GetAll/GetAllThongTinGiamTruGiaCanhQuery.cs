﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAll
{
    public class GetAllThongTinGiamTruGiaCanhQuery : IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetAllThongTinGiamTruGiaCanhQuery() { }
    }
}
