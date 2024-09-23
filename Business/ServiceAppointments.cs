using Business.DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ServiceAppointments
    {
        Appointment appointment;
        public ServiceAppointments() { 
            appointment = new Appointment();
        }
        public List<Citas> GetCitas()
        {
            List<Citas> citasDTO = new List<Citas>();
            appointment.GetAll().ForEach(cita => {

                Citas citaDTO  = new Citas() { Id = cita.id ,Estado = cita.estado, Fecha= cita.fecha, IdMedico = cita.medico_id, IdUsuario = cita.usuario_id };
                citasDTO.Add(citaDTO);
            });

            return citasDTO;

        }
        public Citas GetCita(int id)
        {
            var cita= appointment.Get(id);
            Citas citaDTO = new Citas() { Id = cita.id, Estado = cita.estado, Fecha = cita.fecha, IdMedico= cita.medico_id, IdUsuario= cita.usuario_id };
            return citaDTO;
        }

        public bool AgregarCitas(Citas citaDTO)
        {
            citas cita = new citas() { estado = citaDTO.Estado, fecha = citaDTO.Fecha, medico_id= citaDTO.IdMedico, usuario_id= citaDTO.IdUsuario };
            return appointment.Add(cita);
        }

        public bool Edit(int id,Citas citaDTO)
        {
            var cita = appointment.Get(id);
            cita.estado = citaDTO.Estado;
            cita.fecha = citaDTO.Fecha;
            cita.medico_id = citaDTO.IdMedico;
            cita.usuario_id = citaDTO.IdUsuario;
            return appointment.Update(cita);
        }

        public bool Delete(int id)
        {
            return appointment.Delete(id);
        }
    }
}
