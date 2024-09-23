using Business;
using Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ServicioArquitectura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ServiceAppointments _serviceAppointments;

        public AppointmentController(ServiceAppointments serviceAppointments)
        {
            _serviceAppointments = serviceAppointments;
        }

        [HttpGet(Name = "GetCitas")]
        public IEnumerable<Citas> Get()
        {
            return _serviceAppointments.GetCitas();
        }

        // GET: Appointment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                var cita = _serviceAppointments.GetCita(id);
                return Ok(cita);
            }

            return BadRequest();
        }

        // POST: Appointment/Create
        [HttpPost]
        public IActionResult Create(Citas citaDTO)
        {

            if (ModelState.IsValid)
            {
                var result = _serviceAppointments.AgregarCitas(citaDTO);
                return Ok(result);
            }

            return BadRequest();
        }

        // POST: Appointment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Citas citaDTO)
        {

            if (ModelState.IsValid)
            {
                var result = _serviceAppointments.Edit(id,citaDTO);
                return Ok(result);
            }

            return BadRequest();
        }

        // Delete: Appointment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceAppointments.Delete(id);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
