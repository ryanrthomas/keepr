using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        public Keep CreateKeep(Keep keep)
        {
            return _repo.CreateKeep(keep);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
        public Keep GetById(int id)
        {
            return _repo.GetById(id);
        }
        public List<Keep> GetAll()
        {
            return _repo.GetAll();
        }

    }
}