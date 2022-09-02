using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern_A
{
    internal class Program
    {
        /// <summary>
        /// 抽象工廠  製作小籠包 炒飯 等等
        /// 台北工廠
        /// 台中工廠
        /// 高雄工廠
        ///介面 去抽象製作的產品(小籠包 炒飯)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Imaker taipeiFactory = new TaipeiFactory();
            taipeiFactory.GetXiaoLongBao().GetInfo();
        }

        interface Imaker
        {
            AbstractBao GetXiaoLongBao();

            AbstractRice GetFiredRice();
        }

       public class TaipeiFactory: Imaker
        {
            public AbstractBao GetXiaoLongBao() 
            {
                return new MakeBao();
            }

            public AbstractRice GetFiredRice()
            {
                return new MakeRice();
            }
        }

       public  abstract class AbstractBao
        {
            protected abstract void DoOperation();

            public void GetInfo()
            {
                Console.WriteLine(string.Format("I am {0}.", this.GetType().Name));
            }
        }
        public class MakeBao: AbstractBao
        {
            protected override void DoOperation()
            {
                throw new System.NotImplementedException();
            }

        }



        public abstract class AbstractRice
        {
            protected abstract void DoOperation();

            public void GetInfo()
            {
                Console.WriteLine(string.Format("I am {0}.", this.GetType().Name));
            }
        }
        class MakeRice : AbstractRice
        {
            protected override void DoOperation()
            {
                throw new System.NotImplementedException();
            }

        }
    }
}
