using MiniExample.Model.Models;
using System.Runtime.InteropServices;

namespace MiniExample.Service.Interfaces
{
    public interface IMakerService
    {
        public Task<bool> CreateMaker(Maker newMaker);
        public Task<bool> UpdateMaker(Maker newMaker, int id);

        //public Task<List<Maker>> GetMakers();
       

    }
}
