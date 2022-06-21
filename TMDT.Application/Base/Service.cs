using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Application.Base
{
    public class Service
    {
        public readonly IMapper _mapper;
        public Service(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
