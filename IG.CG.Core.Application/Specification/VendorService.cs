using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Specification
{
    public class VendorService : IVendorService
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;

        public VendorService(IMapper mapper, IVendorRepository vendorRepository)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;

        }
        public async Task<IList<VendorDisplayModel>> GetAllVendorAsync(VendorFilter vendorFilter)
        {
            var vendor = await _vendorRepository.GetAllVendorAsync(vendorFilter);
            var vendorModel = _mapper.Map<List<VendorDisplayModel>>(vendor.ToList());
            return vendorModel;
        }

        public async Task<string?> UpsertVendorAsync(VendorModel VendorModel, string? userId)
        {
            VendorEntity vendorObj = _mapper.Map<VendorEntity>(VendorModel);
            vendorObj.UserId = userId;  //will be update later with active session userid
            return await _vendorRepository.UpsertVendorAsync(vendorObj);
        }
        public async Task<VendorDisplayModel> GetVendorByIdAsync(int VendorId)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(VendorId);
            var vendorModel = _mapper.Map<VendorDisplayModel>(vendor);
            return vendorModel;
        }
        public async Task<string?> DeleteVendorAsync(int VendorId, string? userId, int isActive)
        {
            return await _vendorRepository.DeleteVendorAsync(VendorId, userId, isActive);
        }

        public async Task<IList<VendorDisplayModel>> GetAllVendorAsyncByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode)
        {
            var Vendor = await _vendorRepository.GetAllVendorAsyncByProductAsync(DivisionCode, ProductLineCode, ProductGroupCode);
            var VendorModel = _mapper.Map<List<VendorDisplayModel>>(Vendor.ToList());
            return VendorModel;
        }
    }
}
