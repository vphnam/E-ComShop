using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Web.Http;
using TMDT.Helpers;

namespace TMDT.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly Helper _helper;
        public readonly HttpConfiguration _httpconfig;
        public BaseController(IMapper mapper, Helper helper)
        {
            _mapper = mapper;
            _helper = helper;
        }
    }
}
