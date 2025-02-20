namespace RoboControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly IRoboService _roboService;

        public RoboController(IRoboService roboService)
        {
            _roboService = roboService;
        }

        [HttpGet("state")]
        public IActionResult GetRoboState()
        {
            var state = _roboService.GetRoboState();
            return Ok(state);
        }

        [HttpPost("left-arm/elbow")]
        public IActionResult MoveLeftArmElbow([FromBody] ElbowState newState)
        {
            _roboService.MoveLeftArmElbow(newState);
            return NoContent();
        }

        [HttpPost("left-arm/wrist")]
        public IActionResult MoveLeftArmWrist([FromBody] WristState newState)
        {
            _roboService.MoveLeftArmWrist(newState);
            return NoContent();
        }

        [HttpPost("right-arm/elbow")]
        public IActionResult MoveRightArmElbow([FromBody] ElbowState newState)
        {
            _roboService.MoveRightArmElbow(newState);
            return NoContent();
        }

        [HttpPost("right-arm/wrist")]
        public IActionResult MoveRightArmWrist([FromBody] WristState newState)
        {
            _roboService.MoveRightArmWrist(newState);
            return NoContent();
        }

        [HttpPost("head/rotation")]
        public IActionResult RotateHead([FromBody] RotationState newState)
        {
            _roboService.RotateHead(newState);
            return NoContent();
        }

        [HttpPost("head/inclination")]
        public IActionResult InclineHead([FromBody] InclinationState newState)
        {
            _roboService.InclineHead(newState);
            return NoContent();
        }
    }
}
