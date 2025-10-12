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
    public class OEMService:IOEMService
    {
        private readonly IMapper _mapper;
        private readonly IOEMRepository _oemrepository;
        public OEMService(IMapper mapper, IOEMRepository oemrepository)
        {
            _mapper = mapper;
            _oemrepository = oemrepository;

        }
        public async Task<IList<OEMModel>> GetOEMDataAsync(OEMFilter oemFilter)
        {
            var oem = await _oemrepository.GetOEMDataAsync(oemFilter);
            var oemmodel = _mapper.Map<List<OEMModel>>(oem.ToList());
            return oemmodel;
        }
        public async Task<string?> UpsertOEMAsync(int ServiceTicketID, string? OEM)
        {
            return await _oemrepository.UpsertOEMAsync(ServiceTicketID,OEM);
        }
    }
}
