using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactTracking.Models;
using ContactTracking.Repository;
using System.Web.Http.Cors;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactTracking.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            RPCandidate rpCli = new RPCandidate();
            return Ok(rpCli.ObtenerClientes());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPCandidate rpCli = new RPCandidate();

            var cliRet = rpCli.ObtenerCliente(id);

            if (cliRet == null)
            {
                var nf = NotFound("The candidate " + id.ToString() + " doesnt exist.");
                return nf;
            }

            return Ok(cliRet);
        }

        
        [HttpGet("search/id={id}/firstname={firstname}/lastname={lastname}/emailaddress={emailaddress}/phonenumber={phonenumber}/residentialzipcode={residentialzipcode}")]
        public IActionResult Search(int id, string firstname, string lastname, string emailaddress, string phonenumber, string residentialzipcode)
        {
            RPCandidate rpCli = new RPCandidate();

            var cliRet = rpCli.searchCandidate(id, firstname, lastname, emailaddress, phonenumber, residentialzipcode);

            if (cliRet == null)
            {
                var nf = NotFound("The candidate " + id.ToString() + " doesnt exist.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente([FromBody] Candidate nuevoCliente)
        {
            if(!validateEmail(nuevoCliente.EmailAddress))
            {
                var nf = BadRequest("The email is not correct.");
                return nf;
            }
            RPCandidate rpCli = new RPCandidate();
            rpCli.Agregar(nuevoCliente);
            Console.WriteLine(nuevoCliente.FirstName);
            return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        }

        static bool validateEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
