using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Specification
{
    public class ASCServiceRequestService : IASCServiceRequestService
    {
        private readonly IMapper _mapper;
        private readonly IASCServiceRequestRepository _ascServiceRequestRepository;
        public ASCServiceRequestService(IMapper mapper, IASCServiceRequestRepository ascServiceRequestRepository)
        {
            _mapper = mapper;
            _ascServiceRequestRepository = ascServiceRequestRepository;

        }

        public async Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var ASCServiceRequest = await _ascServiceRequestRepository.GetAllASCServiceRequestAsync(ascServiceRequestFilter, userId);
            var ASCServiceRequestModel = _mapper.Map<List<ASCServiceRequestModel>>(ASCServiceRequest.ToList());
            return ASCServiceRequestModel;
        }


        public async Task<IList<SerialNoWiseTicketModel>> GetAlSerialNoWiseTicketAsync(string? SrNo)
        {
            var SerialNoWiseTicketRequest = await _ascServiceRequestRepository.GetAlSerialNoWiseTicketAsync(SrNo);
            var SrTicketModel = _mapper.Map<List<SerialNoWiseTicketModel>>(SerialNoWiseTicketRequest.ToList());
            return SrTicketModel;
        }



        public async Task<IList<ASCServiceRequestModel>> GetAllCallCenterRequestOpenTicketAsync(CallCenterRequestOpenTicketFilter ascServiceRequestFilter, string? userId)
        {
            var ASCServiceRequest = await _ascServiceRequestRepository.GetAllCallCenterRequestOpenTicketAsync(ascServiceRequestFilter, userId);
            var ASCServiceRequestModel = _mapper.Map<List<ASCServiceRequestModel>>(ASCServiceRequest.ToList());
            return ASCServiceRequestModel;
        }


        public async Task<IList<ASCServiceRequestTotalCountModel>> GetAllASCServiceRequestTotalCountAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var ASCServiceRequest = await _ascServiceRequestRepository.GetAllASCServiceRequestTotalCountAsync(ascServiceRequestFilter, userId);
            var ASCServiceRequestModel = _mapper.Map<List<ASCServiceRequestTotalCountModel>>(ASCServiceRequest.ToList());
            return ASCServiceRequestModel;
        }


        public async Task<IList<ASCServiceRequestModel>> GetAllASMServiceRequestAsync(ASCServiceRequestFilter asmServiceRequestFilter, string? userId)
        {
            var ASMServiceRequest = await _ascServiceRequestRepository.GetAllASMServiceRequestAsync(asmServiceRequestFilter, userId);
            var ASMServiceRequestModel = _mapper.Map<List<ASCServiceRequestModel>>(ASMServiceRequest.ToList());
            return ASMServiceRequestModel;
        }

        public async Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestViewAsync(ASCServiceRequestViewAllFilter ascServiceRequestFilter)
        {
            var ASCServiceRequestView = await _ascServiceRequestRepository.GetAllASCServiceRequestViewAsync(ascServiceRequestFilter);
            var ASCServiceRequestViewModel = _mapper.Map<List<ASCServiceRequestModel>>(ASCServiceRequestView.ToList());
            return ASCServiceRequestViewModel;
        }

        public async Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestCancelledAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId)
        {
            var ASCServiceRequestCancelled = await _ascServiceRequestRepository.GetAllASCServiceRequestCancelledAsync(ascServiceRequestFilter, userId);
            var ASCServiceRequestCancelledModel = _mapper.Map<List<ASCServiceRequestModel>>(ASCServiceRequestCancelled.ToList());
            return ASCServiceRequestCancelledModel;
        }

    }
}
