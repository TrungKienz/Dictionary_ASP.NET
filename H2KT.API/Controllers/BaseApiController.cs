﻿using H2KT.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    [Route("H2KT-api/[controller]")]
    [ApiController, Authorize]
    public class BaseApiController : ControllerBase
    {
        protected INhom2ServiceCollection ServiceCollection;

        public BaseApiController(INhom2ServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
    }
}
