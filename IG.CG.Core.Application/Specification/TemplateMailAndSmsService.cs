using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class TemplateMailAndSmsService : ITemplateMailAndSmsService
    {
        private readonly IMapper _mapper;
        private readonly ITemplateMailAndSmsRepository _templateRepository;
        public TemplateMailAndSmsService(IMapper mapper, ITemplateMailAndSmsRepository templateRepository)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;

        }


        public async Task<IList<TemplateMailAndSmsModel>> GetAllTemplateAsync(TemplateMailAndSmsFilter MSFilter)
        {
            var template = await _templateRepository.GetAllTemplateAsync(MSFilter);
            var templateModel = _mapper.Map<List<TemplateMailAndSmsModel>>(template.ToList());
            return templateModel;
        }


        public async Task<TemplateMailAndSmsModel> GetTemplateByIdAsync(int TemplateId)
        {
            var template = await _templateRepository.GetTemplateByIdAsync(TemplateId);
            var templateModel = _mapper.Map<TemplateMailAndSmsModel>(template);
            return templateModel;
        }


        public async Task<string?> UpsertTemplateAsync(TemplateMailAndSmsModel temModel, string? userId)
        {
            TemplateMailAndSmsEntity templateObj = _mapper.Map<TemplateMailAndSmsEntity>(temModel);
            templateObj.UserId = userId;
            return await _templateRepository.UpsertTemplateAsync(templateObj);
        }
        public async Task<string?> DeleteTemplateAsync(int TemplateId, string? userId, int isActive)
        {
            return await _templateRepository.DeleteTemplateAsync(TemplateId, userId, isActive);
        }


    }
}
