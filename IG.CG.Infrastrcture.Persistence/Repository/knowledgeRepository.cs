using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class knowledgeRepository : IknowledgeRepository
    {
        private readonly ISqlDbContext _SqlRepository;
        private readonly ICommunication _CommunicationRepository;
        private readonly IConfiguration _config;
        public knowledgeRepository(ISqlDbContext SqlRepository, IConfiguration config)
        {
            _SqlRepository = SqlRepository;
            _config = config;
        }


        public async Task<string?> UpsertknowledgeAsync(knowledgeInfoDetailslistEntity KwObj, string knowledgeFile)
        {


            //List<IFormFile>? InvoiceFile1 = KwObj.InvoiceFile;
            //DocumentTypes documentType = DocumentTypes.InvoiceDocument;
            //bool ifSuccess;
            //string dbPath = "";
            //if (InvoiceFile1.Count > 0)
            //{
            //    List<Tuple<bool, string>> result = await _CommunicationRepository.UploadDocument(InvoiceFile1, documentType);
            //    foreach (var item in result)
            //    {
            //        ifSuccess = item.Item1;
            //        if (ifSuccess == true)
            //        {
            //            dbPath = item.Item2;

            //        }

            //    }
            //}



            var para = new DynamicParameters();
            para.Add("@knowledgeId", KwObj.knowledgeId);
            para.Add("@CategoryId", KwObj.CategoryId);
            para.Add("@knowledgeTitle", KwObj.knowledgeTitle);
            para.Add("@knowledgeFile", knowledgeFile);
            para.Add("@Description", KwObj.Description);
            para.Add("@UserId", KwObj.UserId);
            para.Add("@DivisionCode", KwObj.Division);
            para.Add("@ProductLineCode", KwObj.ProductLine);
            para.Add("@ValidFrom", KwObj.ValidFrom);
            para.Add("@ValidTill", KwObj.ValidTill);
            return await _SqlRepository.ExecuteScalarAsync<string?>(knowledgeQueries.UpsertKnowledge, para);
        }


        public async Task<string?> DeleteknowledgeAsync(string? knowledgeId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@knowledgeId", knowledgeId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _SqlRepository.ExecuteScalarAsync<string?>(knowledgeQueries.DeleteKnowledge, para);
        }

        public async Task<IList<knowledgelistEntity>> GetAllknowledgeAsync(string userId)
        {
            var para = new DynamicParameters();
            para.Add("@knowledgeId", "0");
            para.Add("@UserId", userId);
            para.Add("@Mode", "1");
            var lstKw = await _SqlRepository.GetAllAsync<knowledgelistEntity>(knowledgeQueries.AllKnowledge, para);


            List<knowledgelistEntity> kwlist = new List<knowledgelistEntity>();
            knowledgelistEntity ObjSTC = null;

            if (lstKw != null)
            {
                foreach (var itemldp in lstKw)
                {
                    string? _downloadDirectory = "";
                    _downloadDirectory = _config.GetSection("Development:urlName")?.Value;


                    ObjSTC = new knowledgelistEntity();
                    ObjSTC.knowledgeId = itemldp.knowledgeId;
                    ObjSTC.CategoryId = itemldp.CategoryId;
                    ObjSTC.CategoryName = itemldp.CategoryName;
                    ObjSTC.knowledgeTitle = itemldp.knowledgeTitle;
                    ObjSTC.knowledgeFile = Path.Combine(_downloadDirectory, itemldp.knowledgeFile);
                    ObjSTC.Description = itemldp.Description;
                    ObjSTC.knowledgeDate = itemldp.knowledgeDate;
                    ObjSTC.DivisionCode = itemldp.DivisionCode;
                    ObjSTC.ProductLineCode = itemldp.ProductLineCode;
                    ObjSTC.ValidFrom = itemldp.ValidFrom;
                    ObjSTC.ValidTill = itemldp.ValidTill;
                    ObjSTC.DivisionName = itemldp.DivisionName;
                    ObjSTC.ProductLineName = itemldp.ProductLineName;
                    ObjSTC.ValidFromDate = itemldp.ValidFromDate;
                    ObjSTC.ValidTillDate = itemldp.ValidTillDate;

                    kwlist.Add(ObjSTC);
                }
            }

            return kwlist.ToList();
        }


        public async Task<knowledgelistEntity?> GetknowledgeByIdAsync(string? knowledgeId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@knowledgeId", knowledgeId);
            sp_params.Add("@UserId", "");
            sp_params.Add("@Mode", "2");
            return await _SqlRepository.GetAsync<knowledgelistEntity>(knowledgeQueries.GetKnowledgeById, sp_params);
        }

    }
}
