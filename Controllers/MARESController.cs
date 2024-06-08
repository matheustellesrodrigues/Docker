using GS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MARESController : ControllerBase
    {
        private static List<MARES> _MARES = new List<MARES>();

        [HttpGet]
        public ActionResult<IEnumerable<MARES>> Get()
        {
            return Ok(_MARES);
        }

        [HttpGet("{id}")]
        public ActionResult<MARES> Get(int id)
        {
            var mar = _MARES.FirstOrDefault(m => m.ID == id);
            if (mar == null)
            {
                return NotFound();
            }
            return Ok(mar);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MARES mar)
        {
            _MARES.Add(mar);
            return CreatedAtAction(nameof(Get), new { id = mar.ID }, mar);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MARES updatedMar)
        {
            var mar = _MARES.FirstOrDefault(m => m.ID == id);
            if (mar == null)
            {
                return NotFound();
            }

            mar.NOME = updatedMar.NOME;
            mar.LOCALIZACAO = updatedMar.LOCALIZACAO;
            mar.PH = updatedMar.PH;
            mar.TURBIDEZ = updatedMar.TURBIDEZ;
            mar.OXIGENIO_DISSOLVIDO = updatedMar.OXIGENIO_DISSOLVIDO;
            mar.NITRATOS = updatedMar.NITRATOS;
            mar.FOSFATOS = updatedMar.FOSFATOS;
            mar.COLIFORMES_TOTAIS = updatedMar.COLIFORMES_TOTAIS;
            mar.DATA_MEDICAO = updatedMar.DATA_MEDICAO;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mar = _MARES.FirstOrDefault(m => m.ID == id);
            if (mar == null)
            {
                return NotFound();
            }

            _MARES.Remove(mar);
            return NoContent();
        }
    }
}
