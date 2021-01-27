using System;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class DeveloperService : IDeveloperService
    {
        private IDeveloperRepository _developerRepository;
        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Developer GetByVideoGameId(int id)
        {
            return _developerRepository.GetByVideoGameId(id).toLocal();
        }
    }
}
