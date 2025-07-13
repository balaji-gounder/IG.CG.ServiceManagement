using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class TemplateMailAndSmsRepository : ITemplateMailAndSmsRepository
    {
        private readonly ISqlDbContext _TemplateRepository;
        public TemplateMailAndSmsRepository(ISqlDbContext templateRepository)
        {
            _TemplateRepository = templateRepository;
        }

        public async Task<string?> UpsertTemplateAsync(TemplateMailAndSmsEntity temObj)
        {
            var para = new DynamicParameters();
            para.Add("@TemplateId", temObj.TemplateId);
            para.Add("@TypeId", temObj.TypeId);
            para.Add("@TemplateName", temObj.TemplateName);
            para.Add("@TemplateSubject", temObj.TemplateSubject);
            para.Add("@TemplateBody", temObj.TemplateBody);
            para.Add("@Remarks", temObj.Remarks);
            para.Add("@IsHTML", temObj.IsHTML);
            para.Add("@IsActive", temObj.IsActive);
            para.Add("@UserId", temObj.UserId);
            return await _TemplateRepository.ExecuteScalarAsync<string?>(TemplateQueries.UpsertTemplate, para);
        }

        public async Task<string?> DeleteTemplateAsync(int templateId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@TemplateId", templateId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _TemplateRepository.ExecuteScalarAsync<string?>(TemplateQueries.DeleteTemplate, para);
        }

        public async Task<IList<TemplateMailAndSmsEntity>> GetAllTemplateAsync(TemplateMailAndSmsFilter MSFilter)
        {
            var para = new DynamicParameters();
            para.Add("@PageSize", MSFilter.PageNumber);
            para.Add("@PageNumber", MSFilter.PageSize);
            para.Add("@TypeId", MSFilter.TypeId);
            para.Add("@TemplateName", MSFilter.TemplateName);
            var lsttemplate = await _TemplateRepository.GetAllAsync<TemplateMailAndSmsEntity>(TemplateQueries.AllTemplate, para);
            return lsttemplate.ToList();
        }
        public async Task<TemplateMailAndSmsEntity?> GetTemplateByIdAsync(int templateId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@TemplateId", templateId);
            return await _TemplateRepository.GetAsync<TemplateMailAndSmsEntity>(TemplateQueries.GetTemplateById, sp_params);
        }


    }
}
