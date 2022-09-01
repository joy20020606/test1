using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP_A
{
    internal class Program
    {
        /// <summary>
        /// 里氏替換原則
        /// 母雞抽象動物主體 下蛋方法
        /// 但是羊不會下蛋 ，不要強行繼承會下蛋，如果要繼承就要完全實現
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }

        public abstract class Animal
        {
            public abstract double LayEgg();
           
            public abstract double LayEggAvg(Animal s);
        }
        public class Hen : Animal
        {
            public override double LayEgg()
            {
                return 100;
            }

            public override double LayEggAvg(Animal s)
            {
                return 365 / s.LayEgg();
            }
        }
        public class Sheep : Animal
        {
            public override double LayEgg()
            {
                return 0;
            }

            public override double LayEggAvg(Animal s)
            {
                return 365 / s.LayEgg();
            }
        }
    }
}
