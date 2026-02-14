using System.Collections.Generic;

namespace FlashSaleApi.Data
{
    public class MemStore
    {
        public int Inv { get; set; } = 0;

        public Queue<string> Wl = new Queue<string>(); // waitinglist

        public Dictionary<string, DateTime> Res = new Dictionary<string, DateTime>();

        public object LockObj = new object();
    }
}
