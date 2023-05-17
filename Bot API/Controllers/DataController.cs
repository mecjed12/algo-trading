using Bot_API.DataContext;
using Bot_API.Models;
using Bot_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bot_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        private readonly IHistoricalDataService _historicalDataService;

        public DataController(EF_DataContext eF_DataContext, IHistoricalDataService historicalDataService)
        {
            _dbHelper = new DbHelper(eF_DataContext);
            _historicalDataService = historicalDataService;
        }

        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataController>/5
        [HttpDelete]
        [Route("botapi/[controller]/delete Historical Dataset{id}")]
        public async Task<IActionResult> DeleteTheHistoricalData(int id)
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _historicalDataService.DeleteTheHistoricalDataSet(id);
                return Ok(ResponseHandler.GetApiResponse(responseType, "Delete the Dataset Sucessfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("botapi/[controller]/scrap")]
        public async Task<IActionResult> ScrapTheHistoricalData()
        {
            try
            {
                ResponseType responseType = ResponseType.Success;
                await _historicalDataService.ScrapTheHIstoricalData();
                return Ok(ResponseHandler.GetApiResponse(responseType, "Collect Complete"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
