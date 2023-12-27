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
    public class JewelryService:IJewelryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IJewelryRepo _jewelryRepo;
        private readonly IMapper _mapper;

        public JewelryService(ICategoryRepo categoryRepo, IJewelryRepo jewelryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _jewelryRepo = jewelryRepo;
            _mapper = mapper;
        }

        public List<JewelryDto> GetAll()
        {
            return _mapper.Map<List<JewelryDto>>(_jewelryRepo.GetAll());
        }

        public JewelryDto Get(int id)
        {
            return _mapper.Map<JewelryDto>(_jewelryRepo.Get(id));
        }

        public List<JewelryDto> GetByCategoryId(int id)
        {
            var jewelries = _jewelryRepo.GetJewelriesByCategory(id);
            return _mapper.Map<List<JewelryDto>>(jewelries);
        }

        public bool Add(JewelryDto jewelry)
        {
            return _jewelryRepo.Add(_mapper.Map<Jewelry>(jewelry));
        }
        public bool Update(JewelryDto jewelry)
        {
            return _jewelryRepo.Update(_mapper.Map<Jewelry>(jewelry));
        }
        public bool Delete(int id)
        {
            return _jewelryRepo.Delete(id);
        }
    }
}
