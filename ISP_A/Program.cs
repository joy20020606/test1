using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_A
{
    internal class Program
    {/// <summary>
    /// 介面隔離原則
    /// 應用程式不依賴不用多餘的介面，可以保證程式安全性，
    /// 下面例子 系統內部使用增刪查改，系統外部只使用查詢
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
        }
        public interface ICardService
        {
             void Add();
             void Remove();

             void Update();
          
        }
        public interface ICardServiceOut
        {
            void Query();
        }
        /// <summary>
        /// 系統內部就繼承兩個介面
        /// </summary>
        public class OurCard : ICardService, ICardServiceOut
        {
            public void Add()
            {
                throw new NotImplementedException();
            }

            public void Query()
            {
                throw new NotImplementedException();
            }

            public void Remove()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 第三方就只能繼承外部介面 只能查詢操作
        /// </summary>
        public class ThirdCard : ICardServiceOut
        {
            public void Query()
            {
                throw new NotImplementedException();
            }
        }
    }
}
