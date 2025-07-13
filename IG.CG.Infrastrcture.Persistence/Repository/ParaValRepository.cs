using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ParaValRepository : IParaValRepository
    {
        private readonly ISqlDbContext _paraValRepository;
        public ParaValRepository(ISqlDbContext paraValRepository)
        {
            _paraValRepository = paraValRepository;
        }


        public async Task<string?> DeleteParaTypeParaVal(int? ParameterTypeId)
        {
            var para = new DynamicParameters();
            para.Add("@ParameterTypeId", ParameterTypeId);
            var result = await _paraValRepository.ExecuteScalarAsync<string?>(ParaValQueries.DeleteParaByType, para);
            return result;
        }



        public async Task<int?> DeleteParaValAsync(int ParameterValId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ParameterValId", ParameterValId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _paraValRepository.ExecuteScalarAsync<int?>(ParaValQueries.DeleteParaVal, para);
        }
        public async Task<IList<ParaValDispEntity>> GetAllParaValAsync(ParaValFilter paraValFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ParameterTypeId", paraValFilter.ParameterTypeId);
            para.Add("@PageSize", paraValFilter.PageSize);
            para.Add("@PageNumber", paraValFilter.PageNumber);
            var lstParaVal = await _paraValRepository.GetAllAsync<ParaValDispEntity>(ParaValQueries.AllParaVal, para);

            List<ParaValDispEntity> Paralist = new List<ParaValDispEntity>();
            ParaValDispEntity ObjPar = null;
            foreach (var item in lstParaVal)
            {
                ObjPar = new ParaValDispEntity();
                ObjPar.ParameterType = item.ParameterType;
                ObjPar.ParameterTypeId = item.ParameterTypeId;
                ObjPar.NoOfParameterValues = item.NoOfParameterValues;
                ObjPar.TotalRows = item.TotalRows;
                ObjPar.IsActive = item.IsActive;

                var paraL = new DynamicParameters();
                paraL.Add("@ParameterTypeId", item.ParameterTypeId);
                var lstParaValTyp = await _paraValRepository.GetAllAsync<ParaValEntity>(ParaValQueries.GetAllParameterValuesByParameterType, paraL);


                List<ParaValEntity> ParTypelist = new List<ParaValEntity>();
                ParaValEntity ObjParT = null;

                if (lstParaValTyp != null)
                {
                    foreach (var itemlPar in lstParaValTyp)
                    {
                        ObjParT = new ParaValEntity();
                        ObjParT.ParameterText = itemlPar.ParameterText;
                        //ObjleadDiv.ProductGroupCode = itemldp.ProductGroupCode;
                        ObjParT.ParameterValId = itemlPar.ParameterTypeId;
                        ObjParT.ParameterCode = itemlPar.ParameterCode;
                        ObjParT.SequenceNo = itemlPar.SequenceNo;
                        ParTypelist.Add(ObjParT);
                    }
                }

                ObjPar.ParaValList = ParTypelist;

                Paralist.Add(ObjPar);
            }

            return Paralist.ToList();
        }
        public async Task<IList<ParaValEntity>?> GetAllParaByTypeAsync(string paraType)
        {
            var para = new DynamicParameters();
            para.Add("@ParameterType", paraType);
            var lstParaVal = await _paraValRepository.GetAllAsync<ParaValEntity>(ParaValQueries.GetAllParaByType, para);
            return lstParaVal?.ToList();
        }
        public async Task<IList<ParaValEntity>> GetParaValByIdAsync(int ParameterValId)
        {
            //var sp_params = new DynamicParameters();
            //sp_params.Add("@ParameterValId", ParameterValId);
            //return await _paraValRepository.GetAsync<ParaValEntity>(ParaValQueries.GetParaValById, sp_params); 


            var para = new DynamicParameters();
            para.Add("@ParameterTypeId", ParameterValId);

            var lstParaVal = await _paraValRepository.GetAllAsync<ParaValEntity>(ParaValQueries.GetAllParameterValuesByParameterType, para);

            List<ParaValEntity> ParTypelist = new List<ParaValEntity>();
            ParaValEntity ObjParT = null;

            if (lstParaVal != null)
            {
                foreach (var itemlPar in lstParaVal)
                {
                    ObjParT = new ParaValEntity();
                    ObjParT.ParameterText = itemlPar.ParameterText;
                    ObjParT.ParameterTypeId = itemlPar.ParameterTypeId;
                    //ObjleadDiv.ProductGroupCode = itemldp.ProductGroupCode;
                    // ObjParT.ParameterValId = itemlPar.ParameterTypeId;
                    ObjParT.ParameterCode = itemlPar.ParameterCode;
                    ObjParT.SequenceNo = itemlPar.SequenceNo;
                    ObjParT.IsActive = itemlPar.IsActive;
                    ParTypelist.Add(ObjParT);
                }
            }


            return ParTypelist?.ToList();
        }

        public async Task<string?> UpsertParaValAsync(int? ParameterTypeId, string? userId, ParaValEntity paraValObj)
        {
            var para = new DynamicParameters();
            para.Add("@ParameterValId", paraValObj.ParameterValId);
            para.Add("@ParameterTypeId", ParameterTypeId);
            para.Add("@ParameterText", paraValObj.ParameterText);
            para.Add("@ParameterCode", paraValObj.ParameterCode);
            para.Add("@SequenceNo", paraValObj.SequenceNo);
            para.Add("@IsActive", paraValObj.IsActive);
            para.Add("@UserId", userId);
            return await _paraValRepository.ExecuteScalarAsync<string?>(ParaValQueries.UpsertParaVal, para);
        }
        public async Task<IList<ParaTypeEntity>> GetAllParaTypeAsync(int mode)
        {
            var para = new DynamicParameters();
            para.Add("@Mode", mode);
            var lstType = await _paraValRepository.GetAllAsync<ParaTypeEntity>(ParaValQueries.GetAllParaType, para);
            return lstType.ToList();
        }
    }
}
