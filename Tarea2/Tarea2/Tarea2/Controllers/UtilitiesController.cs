using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using Tarea2.Clases;

namespace Tarea2.Controllers
{
    [Route("/api/v1/utilidades/")]
    public class UtilitiesController : ControllerBase
    {
        [HttpGet]
        public string getSalud()
        {
            return "Hello woirdl";
        }

        [HttpGet("ordenarNumeros")]
        public ActionResult<UtilityClass> ordenarNumeros([FromBody] UtilityClass utilityClass)
        {
            int[] lstTemporal = utilityClass.valores;

            for (int i = 0; i < lstTemporal.Length; i++)
            {
                for (int j = 0; j < lstTemporal.Length; j++)
                {
                    if (lstTemporal[i] < lstTemporal[j])
                    {
                        int aux = lstTemporal[i];
                        lstTemporal[i] = lstTemporal[j];
                        lstTemporal[j] = aux;
                    }
                }
            }

            return Ok(new { Numeros = lstTemporal });
        }

        [HttpGet("verificaPrimo/{numero}")]
        public ActionResult<string> verificaPrimo(int numero)
        {
            int divisores = 2;
            bool esPrimo = true;
            string msg_respuesta = string.Empty;

            while (divisores < numero && esPrimo)
            {
                if (numero % divisores != 0)
                {
                    divisores++;
                }
                else
                {
                    esPrimo = false;
                }
            }

            msg_respuesta = esPrimo ? "El numero es primo" : "El numero no es primo";
            return Ok(msg_respuesta);
        }


        //TAREA Verificar si una palabra es palindroma o no.
        [HttpGet("Palindroma")]
        public ActionResult<UtilityClass> Palindroma([FromBody] UtilityClass utilityClass)
        {
            string Palabra = utilityClass.Palabra.ToLower();
            string reves = new string(Palabra.Reverse().ToArray());
            if (Palabra == reves)
            {
                return Ok("La palabra es palíndroma.");
            }
            else
            {
                return Ok("La palabra NO es palíndroma");
            }
         
        }


    


    }
}
