
namespace Threeuple
{
    public class Tuple<TKey,TValue1,TValue2> : IWritable
    {
        public TKey Item1 { get; set; }
        public TValue1 Item2 { get; set; }
        public TValue2 Item3 { get; set; }
        public Tuple(TKey item1, TValue1 item2, TValue2 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }        
        public string WriteMe()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
