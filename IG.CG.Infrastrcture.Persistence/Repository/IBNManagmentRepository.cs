using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class IBNManagmentRepository:IIBNManagmentRepository
    {
        private readonly ISqlDbContext _IBNRepository;
        public IBNManagmentRepository(ISqlDbContext IBNRepository)
        {
            _IBNRepository = IBNRepository;
        }

        public async Task<IList<IBNManagmentEntity>> GetIBNManagmentAsync(IBNManagmentFilter IBNFilter,string? UserId)
        {
            var para = new DynamicParameters();

            para.Add("@Region", IBNFilter.Region);
            para.Add("@Branch", IBNFilter.Branch);
            para.Add("@DivisionCode", IBNFilter.DivCode);
            para.Add("@ProductLine", IBNFilter.ProductLineCode);
            para.Add("@IBNNumber", IBNFilter.IBNNumber);
            para.Add("@BusinessCallID", IBNFilter.BusinessCallID);
            para.Add("@UserId", UserId);
            para.Add("@FromDate", IBNFilter.FromDate);
            para.Add("@ToDate", IBNFilter.ToDate);
            para.Add("@PageSize", IBNFilter.PageSize);
            para.Add("@PageNumber", IBNFilter.PageNumber);
            var lstRegion = await _IBNRepository.GetAllAsync<IBNManagmentEntity>(ReportQueries.IBNManagment, para, CommandType.StoredProcedure, 180);

            return lstRegion.ToList();
        }
    }
}
