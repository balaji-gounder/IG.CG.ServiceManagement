using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Enums;

namespace IG.CG.Core.Application.Specification
{
    public class knowledgeService : IknowledgeService
    {
        private readonly IMapper _mapper;
        private readonly IknowledgeRepository _knowledgeRepository;
        public readonly ICommunication _ProdCustInfoRepository1;

        public readonly CommunicationService _communication;

        public knowledgeService(IMapper mapper, IknowledgeRepository knowledgeRepository, ICommunication communication)
        {
            _mapper = mapper;
            _knowledgeRepository = knowledgeRepository;
            _ProdCustInfoRepository1 = communication;
        }


        public async Task<IList<knowledgelistModel>> GetAllknowledgeAsync(string? userId)
        {
            var knowledge = await _knowledgeRepository.GetAllknowledgeAsync(userId);
            var knowledgeModel = _mapper.Map<List<knowledgelistModel>>(knowledge.ToList());
            return knowledgeModel;
        }


        public async Task<knowledgelistModel> GetknowledgeByIdAsync(string? knowledgeId)
        {
            var knowledge = await _knowledgeRepository.GetknowledgeByIdAsync(knowledgeId);
            var knowledgeModel = _mapper.Map<knowledgelistModel>(knowledge);
            return knowledgeModel;
        }

        public async Task<string?> UpsertknowledgeAsync(knowledgeInfoDetailslistModel KnowModel, string? userId)
        {

            bool ifSuccess;
            DocumentTypes docType = DocumentTypes.KnowledeDoc;
            string? filePath = "";


            List<Tuple<bool, string>> documentResult = await _ProdCustInfoRepository1.UploadDocument(KnowModel.InvoiceFile, docType);

            foreach (var item in documentResult)
            {

                ifSuccess = item.Item1;
                if (ifSuccess == true)
                {
                    filePath = item.Item2;
                }
            }

            knowledgeInfoDetailslistEntity KwObj = _mapper.Map<knowledgeInfoDetailslistEntity>(KnowModel);
            KwObj.UserId = userId;

            return await _knowledgeRepository.UpsertknowledgeAsync(KwObj, filePath);
        }
        public async Task<string?> DeleteknowledgeAsync(string? knowledgeId, string? userId, int isActive)
        {
            return await _knowledgeRepository.DeleteknowledgeAsync(knowledgeId, userId, isActive);
        }

    }
}
