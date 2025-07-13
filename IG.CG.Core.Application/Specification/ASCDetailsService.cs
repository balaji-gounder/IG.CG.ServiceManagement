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
    public class ASCDetailsService:IASCDetailsService
    {
        private readonly IMapper _mapper;
        private readonly IASCDetailsRepository _aSCDetailsRepository;
        public ASCDetailsService(IMapper mapper, IASCDetailsRepository ascdetailsrepository)
        {
            _mapper = mapper;
            _aSCDetailsRepository = ascdetailsrepository;
        }
        public async Task<IList<ASCDetailsModel>> GetASCDetailsAsync(ASCDetailsFilter ascdetailsfilter)
        {
            var ascdetails = await _aSCDetailsRepository.GetASCDetailsAsync(ascdetailsfilter);
            var ascdetailsmodel = _mapper.Map<List<ASCDetailsModel>>(ascdetails.ToList());
            return ascdetailsmodel;
        }
    }
}
