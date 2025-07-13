using AutoMapper;
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ASCWisePinCodeRepository : IASCWisePinCodeRepository
    {

        private readonly IMapper _mapper;
        private readonly ISqlDbContext _ascPiccodeContext;
        public ASCWisePinCodeRepository(IMapper mapper, ISqlDbContext ascPiccodeContext)
        {
            _mapper = mapper;
            _ascPiccodeContext = ascPiccodeContext;
        }


        public async Task<string?> UpsertASCWisePinCodeAsync(ASCWisePinCodeEntity AscPinObj)
        {
            var ASCPincodeId = 0;


            if (AscPinObj.PincodeList.Count > 0)
            {


                var paraLDP = new DynamicParameters();
                paraLDP.Add("@ASCCode", AscPinObj.AscCode);
                paraLDP.Add("@UserId", "0");
                paraLDP.Add("@IsActive", "1");
                await _ascPiccodeContext.ExecuteScalarAsync<int?>(ASCWisePinCodeQueries.DeleteASCWisePinCodelist, paraLDP);

                for (int i = 0; i < AscPinObj.PincodeList.Count; i++)
                {
                    var para = new DynamicParameters();
                    para.Add("@AscCode", AscPinObj.AscCode);
                    para.Add("@DivisionCode", AscPinObj.DivisionCode);
                    para.Add("@ProductLineCode", AscPinObj.ProductLineCode);
                    para.Add("@PinCode", AscPinObj.PincodeList[i].ParameterTypeId);
                    para.Add("@IsActive", AscPinObj.IsActive);
                    para.Add("@UserId", AscPinObj.UserId);
                    ASCPincodeId = Convert.ToInt32(await _ascPiccodeContext.ExecuteScalarAsync<int?>(ASCWisePinCodeQueries.UpsertASCWisePinCode, para));

                }
            }


            return ASCPincodeId.ToString();
        }

        public async Task<IList<ASCWisePinCodeDisplayEntity>> GetAllASCWisePinCodeAsync(ASCWisePinCodeFilter ascFilter)
        {
            var para = new DynamicParameters();
            para.Add("@AscCode", ascFilter.AscCode);
            para.Add("@ProductLineCode", ascFilter.ProductLineCode);
            para.Add("@DivisionCode", ascFilter.DivisionCode);
            para.Add("@PageSize", ascFilter.PageSize);
            para.Add("@PageNumber", ascFilter.PageNumber);
            var lstAsc = await _ascPiccodeContext.GetAllAsync<ASCWisePinCodeDisplayEntity>(ASCWisePinCodeQueries.AllAscWisePinCode, para);
            return lstAsc.ToList();
        }




        public async Task<ASCWisePinCodeDisplayEntity?> GetASCWisePinCodeByIdAsync(string ascCode)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ascCode", ascCode);
            sp_params.Add("@Mode", "1");
            var lstASD = await _ascPiccodeContext.GetAsync<ASCWisePinCodeDisplayEntity>(ASCWisePinCodeQueries.GetAscWisePinCodeById, sp_params);


            ASCWisePinCodeDisplayEntity ObjASC = null;

            ObjASC = new ASCWisePinCodeDisplayEntity();

            ObjASC.AscCode = lstASD.AscCode;
            ObjASC.DivisionCode = lstASD.DivisionCode;


            // ----------------------------------------- Product Line --------------

            var paraPL = new DynamicParameters();
            paraPL.Add("@ascCode", ascCode);
            paraPL.Add("@Mode", "2");
            var lstProLineASC = await _ascPiccodeContext.GetAllAsync<ParaTypeEntity>(ASCWisePinCodeQueries.GetAscWisePinCodeById, paraPL);

            List<ParaTypeEntity> ProductLinelist = new List<ParaTypeEntity>();
            ParaTypeEntity ObjPL = null;
            if (lstProLineASC != null)
            {
                foreach (var itemlPL in lstProLineASC)
                {
                    ObjPL = new ParaTypeEntity();
                    ObjPL.ParameterTypeId = itemlPL.ParameterTypeId;
                    ObjPL.ParameterType = itemlPL.ParameterType;

                    ProductLinelist.Add(ObjPL);
                }
            }

            // ----------------------------------------- Product Line --------------

            var paraPin = new DynamicParameters();
            paraPin.Add("@ascCode", ascCode);
            paraPin.Add("@Mode", "3");
            var lstPincodeASC = await _ascPiccodeContext.GetAllAsync<ParaTypeEntity>(ASCWisePinCodeQueries.GetAscWisePinCodeById, paraPin);

            List<ParaTypeEntity> ProductPinCodelist = new List<ParaTypeEntity>();
            ParaTypeEntity Objpin = null;
            if (lstPincodeASC != null)
            {
                foreach (var itemlPL in lstPincodeASC)
                {
                    Objpin = new ParaTypeEntity();
                    Objpin.ParameterTypeId = itemlPL.ParameterTypeId;
                    Objpin.ParameterType = itemlPL.ParameterType;

                    ProductPinCodelist.Add(Objpin);
                }
            }


            ObjASC.ProductLineNameList = ProductLinelist;
            ObjASC.PincodeList = ProductPinCodelist;


            return ObjASC;
        }


        public async Task<string?> DeleteASCWisePinCodeAsync(string ascCode, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ascCode", ascCode);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _ascPiccodeContext.ExecuteScalarAsync<string?>(ASCWisePinCodeQueries.DeleteASCWisePinCodelist, para);
        }


    }
}
