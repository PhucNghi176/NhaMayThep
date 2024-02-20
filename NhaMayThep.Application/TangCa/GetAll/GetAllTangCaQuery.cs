using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TangCa;
using NhaMayThep.Application.TangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.GetAll
{
    public class GetAllTangCaQuery : IRequest<List<TangCaDto>>, IQuery
    {
        public GetAllTangCaQuery()
        {

        }
    }
}
