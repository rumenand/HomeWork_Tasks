using System.Collections.Generic;

namespace CollectionHierarchy.Interfaces
{
    public class AddCollection : IAddCollection
    {
        protected List<string> list = new List<string>();
        public virtual int Add(string item)
        {
            this.list.Add(item);
            return this.list.Count - 1;
        }
    }
}
