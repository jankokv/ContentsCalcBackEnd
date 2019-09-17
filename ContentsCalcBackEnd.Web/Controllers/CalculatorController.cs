using System;
using ContentsCalcBackEnd.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ContentsCalcBackEnd.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        // GET api/calculator
        [HttpGet]
        public ActionResult Get()
        {  
            return Ok(_calculatorService.Read());
        }

        // POST api/calculator
        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                var name = data["name"].ToString();
                var value = Convert.ToDouble(data["value"]);
                var category = data["category"].ToString();
                var id = _calculatorService.Create(name, value, category);

                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        // PUT api/calculator
        [HttpPut]
        public IActionResult Put([FromBody] JObject data)
        {
            try
            {
                var id = Convert.ToInt32(data["id"]);
                var name = data["name"].ToString();
                var value = Convert.ToDouble(data["value"]);
                var category = data["category"].ToString();
                _calculatorService.Update(id, name, value, category);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        // DELETE api/calculator/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _calculatorService.Delete(id);
                 return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
