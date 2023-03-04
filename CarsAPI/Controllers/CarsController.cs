using Microsoft.AspNetCore.Mvc;
using CarsAPI.Repositories;

namespace CarsAPI.Controllers
{
    using CarClassLibary;
    using Microsoft.AspNetCore.Cors;

    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private CarsRepository repository;

        public CarsController(CarsRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Car?namefilter=har
        [EnableCors("AllowAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            List<Car> result = repository.GetAll();    
            if (result.Count < 1)
            {
                return NoContent();
            }
            return result;
        }
      
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            Car? foundCar = repository.GetById(id);
            if (foundCar == null)
            {
                return NotFound();
            }
            return Ok(foundCar);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = repository.Add(newCar);
                return Created($"api/cars/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            try
            {
                Car? carToBeUpdated = repository.Update(id, updates);
                if (carToBeUpdated == null)
                {
                    return NotFound();
                }
                return Ok(carToBeUpdated);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? carToBeDeleted = repository.Delete(id);
            if (carToBeDeleted == null)
            {
                return NotFound("A car with that id doesn't exist!");
            }
            return Ok (carToBeDeleted);
        }
    }
}