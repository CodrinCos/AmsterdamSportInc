using AmsterdamSportInc.Data;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _repository;

        public MembersController(IMemberRepository repository)
        {
            _repository = repository;
        }

    }
}