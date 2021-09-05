using CasaRepouso.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaRepouso.Repository.Interfaces
{
    public interface IProntuarioRepository
    {
        ICollection<ProntuarioModel> Get();
        ProntuarioModel GetProntuarioById(Guid id);
        Task SaveProntuarioSingleAsync(ProntuarioModel ProntuarioModel);
        Task DeleteProntuarioAsync(Guid id);
        Task UpdateProntuarioAsync(Guid id, ProntuarioModel ProntuarioModel);
       
    }
}
