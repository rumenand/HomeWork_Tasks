using System.Collections.Generic;

namespace CollectionHierarchy.Collections
{
    class MyList : IMyList
    {
        private List<string> list = new List<string>();
        public int Used
        {
            get => this.list.Count;
        }

        public int Add(string item)
        {
            this.list.Insert(0, item);
            return 0;
        }

        public string Remove()
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
