using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test1();//單例模式

            #region 多線程模式
            Thread process1 = new Thread(() =>
            {
                test2("ABC123");
            });
            Thread process2 = new Thread(() =>
            {
                test2("OOO456");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

            Console.ReadKey(); 
            #endregion




        }
       static void test1()//單例模式
        {
            Singleton singleton = Singleton.GetInstance();
            singleton.SomeBusiness();
        }
        static void test2(string value)//多線程模式
        {
            SingletonMulite singletonMulite = SingletonMulite.GetInstance(value);
            singletonMulite.SomeBusiness();
        }       
    }
    #region 單例模式
    public sealed class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;
        public static Singleton GetInstance()
        {
            
                
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            
           
        }
        public void SomeBusiness()
        {
            Console.WriteLine("可以做一些邏輯處理");
        }

    }
    #endregion
    #region 多線程模式
    public sealed class SingletonMulite
    {
        private SingletonMulite() { }
        private static SingletonMulite singletonMulite = new SingletonMulite();
        private static readonly object _lock=new object();
        private static SingletonMulite _instance;

        public string  _value { get; set; }
        public static SingletonMulite GetInstance(string value)
        {
            if (_instance == null)
            {
                lock(_lock)
                {
                    _instance = singletonMulite;
                    _instance._value = value;
                }   
            }
               
            return _instance;
        }
        public void SomeBusiness()
        {
            Console.WriteLine($"可以做一些邏輯處理，傳出下列數值{_value}");
        }

    }
    #endregion




}
