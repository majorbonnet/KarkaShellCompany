using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api.Models
{
    public class Coins
    {
        private readonly long _coins;

        public Coins(long coins)
        {
            _coins = coins;
            SetValuesFromTotal(_coins);
        }

        public Coins(long gold, int silver, int copper)
        {
            Gold = gold;
            Silver = silver;
            Copper = copper;
        }

        public long Gold { get; private set; }
        public int Silver { get; private set; }
        public int Copper { get; private set; }

        private void SetValuesFromTotal(long coins)
        {
            var coinsAsDecimal = (decimal)coins;

            Gold = Convert.ToInt64(Math.Floor(coinsAsDecimal / 10000));

            var withoutGold = coinsAsDecimal - Gold * 10000;

            Silver = Convert.ToInt32(Math.Floor(withoutGold / 100));
            Copper = Convert.ToInt32(withoutGold - Silver * 100);
        }

        public static Coins operator +(Coins a, Coins b) => new Coins(a._coins + b._coins);

        public static Coins operator -(Coins a, Coins b) => new Coins(a._coins - b._coins); 

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }
}
