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
    public class PartConsumptionReportService:IPartCosnumptionReportService
    {
        private readonly IMapper _mapper;
        private readonly IPartConsumptionReportRepository _partConsumptionReportRepository;
        public PartConsumptionReportService(IMapper mapper, IPartConsumptionReportRepository partconsumptionreportrepository)
        {
            _mapper = mapper;
            _partConsumptionReportRepository = partconsumptionreportrepository;

        }
        public async Task<IList<PartConsumptionReportModel>> GetPartConsumptionReportAsync(PartConsumptionReportFilter PartConsumptionReportFilter)
        {
            var PartConsumption = await _partConsumptionReportRepository.GetPartConsumptionReportAsync(PartConsumptionReportFilter);
            var PartConsumptionModel = _mapper.Map<List<PartConsumptionReportModel>>(PartConsumption.ToList());
            return PartConsumptionModel;
        }
    }
}
