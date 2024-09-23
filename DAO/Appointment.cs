using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Appointment
    {

        public List<citas> GetAll()
        {
            List<citas> citas = new List<citas>();

            using (saludDBEntities context = new saludDBEntities())
            {
                citas = context.citas.ToList();
            }

            return citas;
        }

        public citas Get(int id)
        {
            citas cita = new citas();

            using (saludDBEntities context = new saludDBEntities())
            {
                cita = context.citas.Where(x => x.id == id).FirstOrDefault();
            }

            return cita;
        }

        public bool Add(citas cita)
        {
            int result = 0;

            using (saludDBEntities context = new saludDBEntities())
            {
                context.citas.Add(cita);
                context.SaveChanges();
                result = 1;
            }

            return result > 0;
        }

        public bool Update(citas cita)
        {
            int result = 0;

            using (saludDBEntities context = new saludDBEntities())
            {
                context.citas.AddOrUpdate(cita);
                context.SaveChanges();
                result = 1;
            }

            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = 0;

            using (saludDBEntities context = new saludDBEntities())
            {
                var cita = context.citas.Where(x => x.id == id).FirstOrDefault();
                context.citas.Remove(cita);
                context.SaveChanges();
                result= 1;
            }

            return result > 0;

        }
    }
}
