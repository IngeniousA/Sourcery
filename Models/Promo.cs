using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceryWeb.Models
{
    public class Promo
    {
        public string val;
        public string link;
        public bool expired;
        public enum PromoType
        {
            Continuous = 1,
            Dashed = 2,
            Infinite = 3
        }
        public Promo(string link, PromoType type)
        {
            this.link = link;
            val = RandStr(type);
            expired = false;
        }
        public Promo(string raw, bool ex = false)
        {
            val = raw.Substring(0, 9);
            link = raw.Substring(9, raw.Length - 9);
            expired = ex;
        }
        string RandStr(PromoType type)
        {
            Random rnd = new Random();
            string res = "";
            switch (type)
            {
                case PromoType.Continuous:
                    res += (char)rnd.Next(65, 72);
                    for (int i = 0; i < 8; i++)
                    {
                        res += (char)rnd.Next(65, 90);
                    }
                    break;
                case PromoType.Dashed:
                    res += (char)rnd.Next(65, 72);
                    res += (char)rnd.Next(65, 90);
                    res += "-";
                    for (int i = 0; i < 3; i++)
                    {
                        res += (char)rnd.Next(65, 90);
                    }
                    res += "-";
                    for (int i = 0; i < 2; i++)
                    {
                        res += (char)rnd.Next(65, 90);
                    }
                    break;
                case PromoType.Infinite:
                    res += "I";
                    for (int i = 0; i < 8; i++)
                    {
                        res += (char)rnd.Next(65, 90);
                    }
                    break;
                default:
                    return "XXXXXXXXX";
            }
            var checklist = Data.GetPromos();
            var checklistEx = Data.GetExpired();
            foreach (var toCompare in checklist)
            {
                if (toCompare.val == res)
                {
                    return RandStr(type);
                }
            }
            foreach (var toCompare in checklistEx)
            {
                if (toCompare == res)
                {
                    return RandStr(type);
                }
            }
            return res;
        }
    }
}