using AutoMapper;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Model.Models;
using MiniExample.Service.Interfaces;
using MiniExample.Data.Entities;
using MiniExample.Data.Repositories.Repositories;
using System.Net;

namespace MiniExample.Service.Services
{
    public class MakerService : IMakerService
    {
        private readonly IMakerRepository _makerRepository;
        private readonly IMapper _mapper;
        public MakerService(IMakerRepository makerRepository, IMapper mapper)
        {
            _makerRepository = makerRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateMaker(Maker newMaker)
        {
            MakerEntity input = _mapper.Map<MakerEntity>(newMaker);

            try
            {
                await _makerRepository.Insert(input);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateMaker(Maker newMaker, int id)
        {
            var currData = await _makerRepository.GetById(id);
            if (currData == null)
            {
                return false;
            }
            currData.Name = newMaker.Name;
            currData.Description = newMaker.Description;
            currData.Location = newMaker.Location;

            try
            {
                await _makerRepository.Update(currData);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
