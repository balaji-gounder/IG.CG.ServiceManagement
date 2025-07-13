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
    public class CostingReportService:ICostingReportService
    {
        private readonly IMapper _mapper;
        private readonly ICostingReportRepository _costingReportRepository;
        public CostingReportService(IMapper mapper, ICostingReportRepository costingreportrepository)
        {
            _mapper = mapper;
            _costingReportRepository = costingreportrepository;

        }

        public async Task<IList<CostingReportModel>> GetCostingReportAsync(CostingReportFilter costingReportFilter)
        {
            var costing = await _costingReportRepository.GetCostingReportAsync(costingReportFilter);
            var costingreportmodel = _mapper.Map<List<CostingReportModel>>(costing.ToList());
            return costingreportmodel;
        }
    }
}
