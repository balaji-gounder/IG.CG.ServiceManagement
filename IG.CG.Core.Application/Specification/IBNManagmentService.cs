using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class IBNManagmentService:IIBNManagmentService
    {
        private readonly IMapper _mapper;
        private readonly IIBNManagmentRepository _ibnRepository;
        public IBNManagmentService(IMapper mapper, IIBNManagmentRepository IBNrepository)
        {
            _mapper = mapper;
            _ibnRepository = IBNrepository;

        }
        public async Task<IList<IBNManagmentModel>> GetIBNManagmentAsync(IBNManagmentFilter IbnFilter,string? userid)
        {
            var ibn = await _ibnRepository.GetIBNManagmentAsync(IbnFilter, userid);
            var ibnmodel = _mapper.Map<List<IBNManagmentModel>>(ibn.ToList());
            return ibnmodel;
        }
    }
}
