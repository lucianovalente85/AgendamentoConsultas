using AgendamentoConsultas.Models.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgendamentoConsultas.Controllers
{
    public class ConsultaController : ApiController

    {
        private static List<ConsultaEntity> consultas;

        public IEnumerable<ConsultaEntity> Get()
        {
            return consultas;
        }

        public ConsultaEntity Get(string id)
        {
            return consultas.Where(x => x.id == id).FirstOrDefault();
        }

        public IHttpActionResult Post([FromBody] ConsultaEntity value)
        {
            try
            {
                if (value.id == null || value.id.Equals(""))
                    value.id = Guid.NewGuid().ToString();

                consultas.Add(value);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(string id, [FromBody]ConsultaEntity value)
        {
            try
            {
                consultas.Remove(consultas.Where(x => x.id == id).FirstOrDefault());
                consultas.Add(value);
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
                consultas.Remove(consultas.Where(x => x.id == id).FirstOrDefault());
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        static ConsultaController()
        {
            consultas = new List<ConsultaEntity>()
             {
                 
             };
        }
    }
}
