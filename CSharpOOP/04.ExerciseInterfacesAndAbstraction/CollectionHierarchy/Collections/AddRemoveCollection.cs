
using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Collections
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public override int Add(string item)
        {
            this.list.Insert(0, item);
            return 0;
        }
        public virtual string Remove()
        {
            string removedItem = null;
            if (list.Count > 0)
            {
                removedItem = list[list.Count-1];
                list.RemoveAt(list.Count - 1);
            }
            return removedItem;
        }
    }
}
