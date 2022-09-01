using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern_A
{
    /// <summary>
    /// 情境:間諜發現毒品正在交易時，通知警察們動作
    /// 
    /// 通常用在信件通知，像是訂閱，購買通知、付款通知、出貨通知
    /// 傳統信件通知，會使用輪巡方法，比較浪費資源
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Observer policeA = new policeA("警察A", spy);
            Observer policeB = new policeB("警察B", spy);
            //不同觀察者，相同方法
            spy.Add(policeA);
            spy.Add(policeB);
            spy.SubjectState = "桃園縣毒品開始交易";
            spy.Notify_1();
            Console.WriteLine("-----------------------");
            //不同觀察者，不同方法(使用委派)
            spy.eventhandler += policeA.Fire1;
            spy.eventhandler += policeB.Fire2;
            spy.SubjectState = "新北市毒品開始交易";
            spy.Notify();
            Console.ReadKey();
        }

        //抽象主題
        public interface Isubject
        {
            void Add(Observer observer);
            void Remove(Observer observer);
            string SubjectState { get; set; }
            void Notify();
            void Notify_1();
        }

        public delegate void EventHand1er();
        //間諜
        public class Spy : Isubject
        {
            public event EventHand1er eventhandler;
            private List<Observer> _observers = new List<Observer>();
            public void Add(Observer observer)
            {
                _observers.Add(observer);
            }
            public void Remove(Observer observer) 
            {
                _observers.Remove(observer);
            }
            public string SubjectState { get; set; }
            public void Notify()
            {
                eventhandler();
            }
            public void Notify_1()
            {
                foreach (Observer observers in _observers)
                {
                    observers.Update();
                }
            }
        }
        public abstract class Observer
        {
            protected string name;
            protected Isubject sub;
            public Observer(string name, Isubject sub)
            {
                this.name = name;
                this.sub = sub;
            }
            public abstract void Update();
            public abstract void Fire1();
            public abstract void Fire2();
        }

        //警察A
        class policeA: Observer
        {
            public policeA(string name, Isubject sub) : base(name, sub) { }
            public override void Update() 
            {
                Console.WriteLine($"{sub.SubjectState}，{name}正面進攻");
            }

            public override void Fire1()
            {
                Console.WriteLine($"{sub.SubjectState}，{name}正面進攻");
            }
            public override void Fire2() { }

        }
        //警察B
        class policeB : Observer
        {
            public policeB(string name, Isubject sub) : base(name, sub) { }
           
            public override void Update()
            {
                Console.WriteLine($"{sub.SubjectState}，{name}守住後門");
            }
            public override void Fire1() { }
            public override void Fire2()
            {
                Console.WriteLine($"{sub.SubjectState}，{name}守住後門");
            }

        }
    }
}
