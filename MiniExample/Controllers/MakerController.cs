using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniExample.Data.Repositories.Interfaces;
using MiniExample.Model;
using MiniExample.Model.Models;
using MiniExample.Service.Interfaces;
using MiniExample.Data.Entities;
using MiniExample.Model.Wrapper;
using MiniExample.Service.Services;

namespace MiniExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakerController : ControllerBase
    {
        private readonly IMakerService _makerService;
        public MakerController(IMakerService makerService)
        {
            _makerService = makerService;
        }

        [Route("/[controller]/Create")]
        [HttpPost]
        public async Task<MyResponse<bool>> Create([FromBody] CreateMakerDto newMakerData)
        {
            var input = new Maker
            {
                Name = newMakerData.Name,
                Description = newMakerData.Description,
                Location = newMakerData.Location,
            };
            bool result = await _makerService.CreateMaker(input);

            return new MyResponse<bool>(result);
        }

        [Route("/[controller]/Update/{id}")]
        [HttpPost]
        public async Task<MyResponse<bool>> Update([FromBody] CreateMakerDto makerData, int id)
        {
            var input = new Maker
            {
                Name = makerData.Name,
                Description = makerData.Description,
                Location = makerData.Location,
            };
            
            bool updateStatus = await _makerService.UpdateMaker(input, id);
            return new MyResponse<bool>(updateStatus);
        }

    }
}
