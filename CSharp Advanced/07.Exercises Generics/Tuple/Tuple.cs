
namespace Tuples
{
    public class Tuple<TKey,TValue>
    {
        public TKey Item1 { get; set; }
        public TValue Item2 { get; set; }

        public Tuple(TKey item1, TValue item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public override string ToString()
        {            
            return $"{Item1} -> {Item2}";
        }
    }
}
