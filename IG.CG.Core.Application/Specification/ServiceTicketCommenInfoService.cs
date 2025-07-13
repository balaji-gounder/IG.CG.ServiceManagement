using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ServiceTicketCommenInfoService : IServiceTicketCommenInfoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceTicketCommenInfoRepository _CommentRepository;
        public ServiceTicketCommenInfoService(IMapper mapper, IServiceTicketCommenInfoRepository CommentRepository)
        {
            _mapper = mapper;
            _CommentRepository = CommentRepository;
        }


        public async Task<IList<ServiceTicketCommenInfoListModel>> GetAllServiceTicketCommenInfoAsync(string? ServiceTicketId)
        {
            var Comment = await _CommentRepository.GetAllServiceTicketCommenInfoAsync(ServiceTicketId);
            var CommentModel = _mapper.Map<List<ServiceTicketCommenInfoListModel>>(Comment.ToList());
            return CommentModel;
        }

        public async Task<string?> UpsertServiceTicketCommenInfoAsync(ServiceTicketCommenInfoModel CommentModel, string? userId)
        {
            ServiceTicketCommenInfoEntitys CommentObj = _mapper.Map<ServiceTicketCommenInfoEntitys>(CommentModel);
            CommentObj.UserId = userId;
            return await _CommentRepository.UpsertServiceTicketCommenInfoAsync(CommentObj);
        }


        public async Task<IList<ServiceTicketCommenInfoListModel>> GetAllServiceTicketEscalationInfoAsync(string? ServiceTicketId)
        {
            var Comment = await _CommentRepository.GetAllServiceTicketEscalationInfoAsync(ServiceTicketId);
            var CommentModel = _mapper.Map<List<ServiceTicketCommenInfoListModel>>(Comment.ToList());
            return CommentModel;
        }

        public async Task<string?> UpsertServiceTicketEscalationInfoAsync(ServiceTicketCommenInfoModel CommentModel, string? userId)
        {
            ServiceTicketCommenInfoEntitys CommentObj = _mapper.Map<ServiceTicketCommenInfoEntitys>(CommentModel);
            CommentObj.UserId = userId;
            return await _CommentRepository.UpsertServiceTicketEscalationInfoAsync(CommentObj);
        }


    }
}
