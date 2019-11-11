using System.Collections.Generic;

namespace CollectionHierarchy.Interfaces
{
    public class AddCollection : IAddCollection
    {
        private List<string> list = new List<string>();
        public int Add(string item)
        {
            this.list.Add(item);
            return list.Count - 1;
        }
    }
}
