﻿using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
   public class Lake : IEnumerable<int>
    {
        private List<int> stones;
        IList<int> test;
        public Lake (int [] array)
        {
            stones = new List<int>(array);          
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if (i % 2 == 0) yield return stones[i];
            }
            for (int i = stones.Count-1; i >= 0; i--)
            {
                if (i % 2 != 0) yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
