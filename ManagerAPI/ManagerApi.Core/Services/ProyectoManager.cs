
using ManagerAPI.Model;
using Persistencia.Context;
using Persistencia.Interfaz;

namespace ManagerAPI.Repositorio
{
    public class ProyectoManager : IRepository<Proyectos>
    {
        private readonly ProjectManagerContext _project;
        public ProyectoManager(ProjectManagerContext context)
        {
            _project = context;
        }

        public void Delete(int id)
        {
           if(id != null)
            {
                var project = GetById(id);
                _project.Proyecto.Remove(project);
                _project.SaveChanges();
            }
        }

        public List<Proyectos> GetAll()
        {
            return _project.Proyecto.ToList();
        }

        public Proyectos GetById(int id)
        {
            return _project.Proyecto.FirstOrDefault(proyect => proyect.Id == id)!;
        }

        public void Insert(Proyectos entity)
        {
            if(entity != null)
            {
                _project.Proyecto.Add(entity);
                _project.SaveChanges();
            }
        }

        public void Update(int id, Proyectos newData)
        {
            if(id !=null && newData != null)
            {
                    var proyect = GetById(id);
                _project.Entry(proyect).CurrentValues.SetValues(newData);
                _project.SaveChanges();
            }
        }
    }
}
