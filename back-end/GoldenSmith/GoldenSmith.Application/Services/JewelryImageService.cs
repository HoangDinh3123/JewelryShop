using AutoMapper;
using GoldenSmith.Application.Dto;
using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
/*using GoldenSmith.Infrastructure.Migrations;*/
using GoldenSmith.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public class JewelryImageService:IJewelryImageService
    {
        private readonly IJewelryImageRepo _jewelryImageRepo;
        private readonly IJewelryRepo _jewelryRepo;
        private readonly IMapper _mapper;

        public JewelryImageService(IJewelryImageRepo jewelryImageRepo, IJewelryRepo jewelryRepo, IMapper mapper)
        {
            _jewelryImageRepo = jewelryImageRepo;
            _jewelryRepo = jewelryRepo;
            _mapper = mapper;
        }

        public List<JewelryImageDto> GetAll()
        {
            return _mapper.Map<List<JewelryImageDto>>(_jewelryImageRepo.GetAll());
        }


        public JewelryImageDto Get(int id)
        {
            return _mapper.Map<JewelryImageDto>(_jewelryImageRepo.Get(id));
        }
        public bool Add(JewelryImageDto jewelryImage, int id)
        {
            var jewelry = _jewelryRepo.Get(id);
            var jewelryImageEntity = _mapper.Map<JewelryImage>(jewelryImage);
            jewelryImageEntity.Jewelry = jewelry;
            return _jewelryImageRepo.Add(jewelryImageEntity);
        }
        public bool Update(JewelryImageDto jewelryImage)
        {
            return _jewelryImageRepo.Update(_mapper.Map<JewelryImage>(jewelryImage));
        }
        public bool Delete(int id)
        {
            return _jewelryImageRepo.Delete(id);
        }
    }
}
