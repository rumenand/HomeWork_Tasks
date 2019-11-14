using System.Collections.Generic;

namespace CollectionHierarchy.Collections
{
    class MyList : AddRemoveCollection, IMyList
    {
        public int Used
        {
            get => this.list.Count;
        }       

        public override string Remove()
        {
            string removedItem = null;
            if (this.list.Count > 0)
            {
                removedItem = list[0];
                list.RemoveAt(0);
            }
            return removedItem;
        }
    }
}
