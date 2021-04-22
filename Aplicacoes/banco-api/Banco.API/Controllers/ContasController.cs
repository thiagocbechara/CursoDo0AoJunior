using Banco.Domain.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaFactory ContaFactory;

        public ContasController(IContaFactory contaFactory)
        {
            ContaFactory = contaFactory;
        }
    }
}
