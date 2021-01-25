using AmsterdamSportInc.Data;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/membertosport")]
    [ApiController]
    public class MemberToSportController : ControllerBase
    {
        private readonly IMemberToSportRepository _repository;

        public MemberToSportController(IMemberToSportRepository repository)
        {
            _repository = repository;
        }

    }
}