using GS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace GS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RIOSController : ControllerBase
    {
        private static List<RIOS> _rios = new List<RIOS>();

        [HttpGet]
        public ActionResult<IEnumerable<RIOS>> Get()
        {
            return Ok(_rios);
        }

        [HttpGet("{id}")]
        public ActionResult<RIOS> Get(int id)
        {
            var rio = _rios.FirstOrDefault(r => r.Id == id);
            if (rio == null)
            {
                return NotFound();
            }
            return Ok(rio);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RIOS rio)
        {
            _rios.Add(rio);
            return CreatedAtAction(nameof(Get), new { id = rio.Id }, rio);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RIOS updatedRio)
        {
            var rio = _rios.FirstOrDefault(r => r.Id == id);
            if (rio == null)
            {
                return NotFound();
            }

            rio.Nome = updatedRio.Nome;
            rio.Localizacao = updatedRio.Localizacao;
            rio.Ph = updatedRio.Ph;
            rio.Turbidez = updatedRio.Turbidez;
            rio.OxigenioDissolvido = updatedRio.OxigenioDissolvido;
            rio.Nitratos = updatedRio.Nitratos;
            rio.Fosfatos = updatedRio.Fosfatos;
            rio.ColiformesTotais = updatedRio.ColiformesTotais;
            rio.DataMedicao = updatedRio.DataMedicao;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var rio = _rios.FirstOrDefault(r => r.Id == id);
            if (rio == null)
            {
                return NotFound();
            }

            _rios.Remove(rio);
            return NoContent();
        }
    }
}
