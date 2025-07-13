using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class DealerService : IDealerService
    {
        private readonly IMapper _mapper;
        private readonly IDealerRepository _dealerRepository;

        public DealerService(IMapper mapper, IDealerRepository dealerRepository)
        {
            this._mapper = mapper;
            this._dealerRepository = dealerRepository;
        }

        public async Task<string?> UpsertDealerAsync(DealerModel dealerModel, string? userId)
        {
            DealerEntity dealer = _mapper.Map<DealerEntity>(dealerModel);
            dealer.UserId = userId;
            return await _dealerRepository.UpsertDealerAsync(dealer);
        }

        public async Task<DealerModel> GetDealerByIdAsync(int dealerId)
        {
            var dealer = await _dealerRepository.GetDealerByIdAsync(dealerId);
            var dealerModel = _mapper.Map<DealerModel>(dealer);
            return dealerModel;
        }

        public async Task<IList<DealerDisplayModel>> GetAllDealerAsync(DealerFilter dealerFilter)
        {
            var dealer = await _dealerRepository.GetAllDealerAsync(dealerFilter);
            var dealerModel = _mapper.Map<List<DealerDisplayModel>>(dealer.ToList());
            return dealerModel;
        }

        public async Task<string?> DeleteDealerAsync(int dealerId, string? userId, int isActive)
        {
            return await _dealerRepository.DeleteDealerAsync(dealerId, userId, isActive);
        }

        public async Task<DealerModel> GetDealerByCodeAsync(string? DealerCode)
        {
            var dealer = await _dealerRepository.GetDealerByCodeAsync(DealerCode);
            var dealerModel = _mapper.Map<DealerModel>(dealer);
            return dealerModel;
        }

        public async Task<DealerModel> GetDealerByNameAsync(string? DealerName)
        {
            var dealer = await _dealerRepository.GetDealerByNameAsync(DealerName);
            var dealerModel = _mapper.Map<DealerModel>(dealer);
            return dealerModel;
        }

        public async Task<string?> UpsertRetailerAsync(DealerModel dealerModel, string? userId)
        {
            DealerEntity dealer = _mapper.Map<DealerEntity>(dealerModel);
            dealer.UserId = userId;
            return await _dealerRepository.UpsertRetailerAsync(dealer);
        }


        public async Task<IList<DealerDisplayModel>> GetDealerAndOEMAsync(string? DealerTypeId)
        {
            var dealer = await _dealerRepository.GetDealerAndOEMAsync(DealerTypeId);
            var dealerModel = _mapper.Map<List<DealerDisplayModel>>(dealer.ToList());
            return dealerModel;
        }
    }
}
