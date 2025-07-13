using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;



namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ASCDetailsRepository:IASCDetailsRepository
    {

        private readonly ISqlDbContext _ascdetailsRepository;
        public ASCDetailsRepository(ISqlDbContext ascdetailsRepository)
        {
            _ascdetailsRepository = ascdetailsRepository;
        }
        public async Task<IList<ASCDetailsEntity>> GetASCDetailsAsync(ASCDetailsFilter ascdetailsfilter)
        {
            
            
            var para = new DynamicParameters();

            //para.Add("@RegionCode", ascdetailsfilter.RegionCode);
            //para.Add("@BranchCode", ascdetailsfilter.BranchCode);
            //para.Add("@ProductDivisionCode", ascdetailsfilter.ProductDivisionCode);
            para.Add("@USerID", ascdetailsfilter.UserID);
            var lstRegion = await _ascdetailsRepository.GetAllAsync<ASCDetailsEntity>(ReportQueries.ASCDetails, para);

            return lstRegion.ToList();
        }
    }
}
