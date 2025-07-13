using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Specification
{
    public class ApprovalLevelService : IApprovalLevelService
    {
        private readonly IMapper _mapper;
        private readonly IApprovalLevelRepository _approvalLevelRepository;
        public ApprovalLevelService(IMapper mapper, IApprovalLevelRepository approvalLevelRepository)
        {
            _mapper = mapper;
            _approvalLevelRepository = approvalLevelRepository;

        }

        public async Task<string?> UpsertApprovalLevelAsync(ApprovalLevelModel approvalLevelModel, string? userId)
        {
            ApprovalLevelEntity approvalLevelObj = _mapper.Map<ApprovalLevelEntity>(approvalLevelModel);
            approvalLevelObj.UserId = userId;
            return await _approvalLevelRepository.UpsertApprovalLevelAsync(approvalLevelObj);
        }

        public async Task<IList<ApprovalLevelDisplayModel>> GetAllApprovalLevelAsync(ApprovalLevelFilter approvalLevelFilter)
        {
            var approvalLevel = await _approvalLevelRepository.GetAllApprovalLevelAsync(approvalLevelFilter);
            var approvalLevelModel = _mapper.Map<List<ApprovalLevelDisplayModel>>(approvalLevel.ToList());
            return approvalLevelModel;
        }

        public async Task<IList<ApprovalLevelUsersModel>> GetAllApprovalLevelUsersAsync(ApprovalLevelFilter approvalLevelFilter)
        {
            var approvalLevelUsers = await _approvalLevelRepository.GetAllApprovalLevelUsersAsync(approvalLevelFilter);
            var approvalLevelUsersModel = _mapper.Map<List<ApprovalLevelUsersModel>>(approvalLevelUsers.ToList());
            return approvalLevelUsersModel;
        }

    }
}
