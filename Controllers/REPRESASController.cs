using GS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class REPRESASController : ControllerBase
    {
        private static List<REPRESAS> _REPRESAS = new List<REPRESAS>();

        [HttpGet]
        public ActionResult<IEnumerable<REPRESAS>> Get()
        {
            return Ok(_REPRESAS);
        }

        [HttpGet("{id}")]
        public ActionResult<REPRESAS> Get(int id)
        {
            var represa = _REPRESAS.FirstOrDefault(r => r.ID == id);
            if (represa == null)
            {
                return NotFound();
            }
            return Ok(represa);
        }

        [HttpPost]
        public ActionResult Post([FromBody] REPRESAS represa)
        {
            _REPRESAS.Add(represa);
            return CreatedAtAction(nameof(Get), new { id = represa.ID }, represa);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] REPRESAS updatedRepresa)
        {
            var represa = _REPRESAS.FirstOrDefault(r => r.ID == id);
            if (represa == null)
            {
                return NotFound();
            }

            represa.NOME = updatedRepresa.NOME;
            represa.LOCALIZACAO = updatedRepresa.LOCALIZACAO;
            represa.PH = updatedRepresa.PH;
            represa.TURBIDEZ = updatedRepresa.TURBIDEZ;
            represa.OXIGENIO_DISSOLVIDO = updatedRepresa.OXIGENIO_DISSOLVIDO;
            represa.NITRATOS = updatedRepresa.NITRATOS;
            represa.FOSFATOS = updatedRepresa.FOSFATOS;
            represa.COLIFORMES_TOTAIS = updatedRepresa.COLIFORMES_TOTAIS;
            represa.DATA_MEDICAO = updatedRepresa.DATA_MEDICAO;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var represa = _REPRESAS.FirstOrDefault(r => r.ID == id);
            if (represa == null)
            {
                return NotFound();
            }

            _REPRESAS.Remove(represa);
            return NoContent();
        }
    }
}
