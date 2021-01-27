using System;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public Publisher GetByVideoGameId(int id)
        {
            return _publisherRepository.GetByVideoGameId(id).toLocal();
        }
    }
}
