using System.Collections.Generic;
using System.Linq;
using ViceCity.Repositories.Contracts;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> list;

        public GunRepository()
        {
            this.list = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.list.AsReadOnly();

        public void Add(IGun model)
        {
            if (this.Find(model.Name) == null)
            {
                this.list.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.list.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(IGun model)
        {
            if (this.Find(model.Name) == null) return false;
            this.list.Remove(model);
            return true;
        }
    }
}
