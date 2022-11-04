namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Lake : IEnumerable<int>
    {
        private int[] stones;
        public Lake(int[] stones)
        {
            this.stones = stones;
        }
        public IEnumerator<int>GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (i%2==0)
                {
                    yield return stones[i];
                }
            }
            for (int i = stones.Length - 1; i >=0 ; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
