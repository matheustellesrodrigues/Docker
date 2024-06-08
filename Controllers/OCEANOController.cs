using GS.Models;
using Microsoft.AspNetCore.Mvc;

namespace GS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCEANOSController : ControllerBase
    {
        private static List<OCEANOS> _OCEANOS = new List<OCEANOS>();

        [HttpGet]
        public ActionResult<IEnumerable<OCEANOS>> Get()
        {
            return Ok(_OCEANOS);
        }

        [HttpGet("{id}")]
        public ActionResult<OCEANOS> Get(int id)
        {
            var oceano = _OCEANOS.FirstOrDefault(o => o.Id == id);
            if (oceano == null)
            {
                return NotFound();
            }
            return Ok(oceano);
        }

        [HttpPost]
        public ActionResult Post([FromBody] OCEANOS oceano)
        {
            _OCEANOS.Add(oceano);
            return CreatedAtAction(nameof(Get), new { id = oceano.Id }, oceano);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OCEANOS updatedOceano)
        {
            var oceano = _OCEANOS.FirstOrDefault(o => o.Id == id);
            if (oceano == null)
            {
                return NotFound();
            }
            //oceano.

            oceano.Nome = updatedOceano.Nome;
            oceano.Localizacao = updatedOceano.Localizacao;
            oceano.Ph = updatedOceano.Ph;
            oceano.Turbidez = updatedOceano.Turbidez;
            oceano.OxigenioDissolvido = updatedOceano.OxigenioDissolvido;
            oceano.Nitratos = updatedOceano.Nitratos;
            oceano.Fosfatos = updatedOceano.Fosfatos;
            oceano.ColiformesTotais = updatedOceano.ColiformesTotais;
            oceano.DataMedicao = updatedOceano.DataMedicao;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var oceano = _OCEANOS.FirstOrDefault(o => o.Id == id);
            if (oceano == null)
            {
                return NotFound();
            }

            _OCEANOS.Remove(oceano);
            return NoContent();
        }
    }
}
