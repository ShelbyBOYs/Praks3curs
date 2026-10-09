using Microsoft.AspNetCore.Mvc;
using AvtoCars.Application.Services;


namespace AvtoCars.Api.Controllers
{

    [ApiController]
    [Route("api/cars")]
    public class CarsController: ControllerBase
    {
        private readonly AddCarServices _carServices;
        private readonly SellCarServices _sellCarServices;

        public CarsController(AddCarServices carServices, SellCarServices sellServices)
        {
            _carServices = carServices;
            _sellCarServices = sellServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCarRequest request)
        {
           var id = await _carServices.AddCar(request.VinCode, request.Price, request.Currency);
            return Ok(new {id});
        }
        [HttpPost("{id}/sell")]
        public async Task<IActionResult> Sell(Guid id)
        {
            await _sellCarServices.SellCar(id);
            return Ok();
        }
        public record AddCarRequest(string VinCode, decimal Price, string Currency);

    }
}
