using AutoMapper;
using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public class JewelryReviewService:IJewelryReviewService
    {
        private readonly IJewelryReviewRepo _jewelryReviewRepo;
        private readonly IMapper _mapper;

        public JewelryReviewService(IJewelryReviewRepo jewelryReviewRepo, IMapper mapper)
        {
            _jewelryReviewRepo = jewelryReviewRepo;
            _mapper = mapper;
        }

        public List<JewelryReviewDto> GetAll()
        {
            return _mapper.Map<List<JewelryReviewDto>>(_jewelryReviewRepo.GetAll());
        }

        public JewelryReviewDto Get(int id)
        {
            return _mapper.Map<JewelryReviewDto>(_jewelryReviewRepo.Get(id));
        }
        public List<JewelryReviewDto> GetByJewelryId(int id)
        {
            var jewelryReviews = _jewelryReviewRepo.GetJewelryReviewByJewelryId(id);
            return _mapper.Map<List<JewelryReviewDto>>(jewelryReviews);
        }
        public bool Add(JewelryReviewDto jewelryReview)
        {
            return _jewelryReviewRepo.Add(_mapper.Map<JewelryReview>(jewelryReview));
        }
        public bool Update(JewelryReviewDto jewelryReview)
        {
            return _jewelryReviewRepo.Update(_mapper.Map<JewelryReview>(jewelryReview));
        }
        public bool Delete(int id)
        {
            return _jewelryReviewRepo.Delete(id);
        }
    }
}
