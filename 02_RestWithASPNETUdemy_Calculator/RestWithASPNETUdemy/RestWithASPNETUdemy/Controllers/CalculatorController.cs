using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{tipo}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string tipo,string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && tipo == "sum")
            {
                var soma = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(soma.ToString());
            }
            else if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && tipo == "sub")
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            else if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && tipo == "multi")
            {
                var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multi.ToString());
            }
            else if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && tipo == "divi")
            {
                var divi = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(divi.ToString());
            }
            else if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && tipo == "media")
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2; 
                return Ok(media.ToString());
            }


            return BadRequest("Invalid Input");
        }


        [HttpGet("{tipo}/{firstNumber}")]

        public IActionResult Get(string tipo, double firstNumber)
        {

        if (tipo == "raiz")
            {
                var raiz = Math.Sqrt((firstNumber));
                return Ok(raiz.ToString());
            }

            return BadRequest("Invalid Input");
        }



        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
           
            return isNumber;
            
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        


    }
}
