using Microsoft.AspNetCore.Mvc;
using SmartPark.Api.Extensions;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Api.Controllers
{
    [ApiController]
    [Route("api/parking-lots")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly IGetParkingLotsUseCase _getParkingLotsUseCase;
        private readonly IGetParkingLotByIdUseCase _getParkingLotByIdUseCase;
        private readonly IPostParkingLotUseCase _postParkingLotUseCase;

        public ParkingLotsController(
            IGetParkingLotsUseCase getParkingLotsUseCase,
            IGetParkingLotByIdUseCase getParkingLotByIdUseCase,
            IPostParkingLotUseCase postParkingLotUseCase
            )
        {
            _getParkingLotsUseCase = getParkingLotsUseCase;
            _getParkingLotByIdUseCase = getParkingLotByIdUseCase;
            _postParkingLotUseCase = postParkingLotUseCase;
        }

        [HttpGet("get-list")]
        [ProducesResponseType(typeof(PagedResult<ParkingLotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync([FromQuery] GetParkingLotsRequest request)
        {
            return ActionResultConverter.Convert(await _getParkingLotsUseCase.Execute(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParkingLotEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            return ActionResultConverter.Convert(await _getParkingLotByIdUseCase.Execute(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] ParkingLotEntity request)
        {
            return ActionResultConverter.Convert(await _postParkingLotUseCase.Execute(request));
        }
    }
}
