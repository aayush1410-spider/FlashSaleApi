using FlashSaleApi.Data;
using FlashSaleApi.Models;

namespace FlashSaleApi.Services
{
    public class SaleSvc
    {
        private readonly MemStore _db;

        public SaleSvc(MemStore db)
        {
            _db = db;
        }

        public void Init(int count)
        {
            lock (_db.LockObj)
            {
                _db.Inv = count;
                _db.Wl.Clear();
                _db.Res.Clear();
            }
        }

        public ReserveRes Reserve(string userId)
        {
            lock (_db.LockObj)
            {
                if (_db.Inv > 0)
                {
                    _db.Inv--;

                    var resId = "res_" + Guid.NewGuid().ToString("N").Substring(0, 6);
                    var exp = DateTime.UtcNow.AddMinutes(5);

                    _db.Res[resId] = exp;

                    return new ReserveRes
                    {
                        reservation_id = resId,
                        expires_at = exp,
                        message = "Reserved"
                    };
                }
                else
                {
                    _db.Wl.Enqueue(userId);

                    return new ReserveRes
                    {
                        message = "Added to waitlist",
                        waitlist_position = _db.Wl.Count
                    };
                }
            }
        }

        public StatusRes GetStatus()
        {
            lock (_db.LockObj)
            {
                return new StatusRes
                {
                    available_inventory = _db.Inv,
                    waitlist_size = _db.Wl.Count
                };
            }
        }
    }
}
