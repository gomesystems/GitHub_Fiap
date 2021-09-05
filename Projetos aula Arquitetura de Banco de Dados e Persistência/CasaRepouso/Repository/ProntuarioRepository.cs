using CasaRepouso.Models;
using CasaRepouso.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaRepouso.Repository
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public Task DeleteProntuarioAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProntuarioModel> Get()
        {
            throw new NotImplementedException();
        }

        public ProntuarioModel GetProntuarioById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveProntuarioSingleAsync(ProntuarioModel ProntuarioModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProntuarioAsync(Guid id, ProntuarioModel ProntuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}
