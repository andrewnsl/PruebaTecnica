using AutoMapper;
using PruebaTecnica.Helpers.LoggerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public class Service
    {
        public readonly IMapper _mapper;      
        public readonly ILog _log;
        public Service(IMapper mapper, ILog log)
        {
            _mapper = mapper;
            _log = log;
        }
    }
}
