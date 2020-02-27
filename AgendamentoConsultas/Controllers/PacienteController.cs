using AgendamentoConsultas.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgendamentoConsultas.Controllers
{
    public class PacienteController: ApiController 
    {

        public IEnumerable<pacienteEntity> Get()
        {
            return pacientes;
        } 

        public pacienteEntity Get(string id) 
        {
            return pacientes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IHttpActionResult Post([FromBody] pacienteEntity value)
        {
            try
            {
                if (value.Id == null || value.Id.Equals(""))
                    value.Id = Guid.NewGuid().ToString();

                pacientes.Add(value);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        public IHttpActionResult Put(string id, [FromBody]pacienteEntity value)
        {
            try
            {
                pacientes.Remove(pacientes.Where(x => x.Id == id).FirstOrDefault());
                pacientes.Add(value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(string id)
        {
            try
            {
                pacientes.Remove(pacientes.Where(x => x.Id == id).FirstOrDefault());
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

       static PacienteController()
        {
            pacientes = new List<pacienteEntity>()
            {
                new pacienteEntity {Id = "X1", Codigo = 123, Cpf = 123456789, DataNascimento=10/10/20},
                new pacienteEntity {Id = "X2", Codigo = 124, Cpf = 213456789, DataNascimento=10/10/99}
            };
        }

        private static List<pacienteEntity> pacientes;

    }
}
