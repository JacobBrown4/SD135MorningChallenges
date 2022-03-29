using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MHService _mh = new MHService();
            var monster = _mh.GetMonsterById(10).Result;
            var result = _mh.GetMonsters().Result;
            Console.ReadKey();            
        }
    }
}
