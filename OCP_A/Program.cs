using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OCP_A.Program;
using static System.Net.WebRequestMethods;

namespace OCP_A
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dog dog = new Dog();
            DogVoice dogVoice = new DogVoice();
            Show show = new Show();
            show.ShowVoice(dog, dogVoice);
            
            
            //使用開閉原則，對擴充套件開放，對內部修改關閉
            //擴充貓的套件，內部不修改
            ICall d = new Dog2();
            IVoice dv = new DogVoice2();
            Show2 s = new Show2();
            s.ShowVoice(d, dv);

            ICall c = new Cat();
            IVoice v = new CatVoice();
            s.ShowVoice(c, v);
            Console.ReadKey();

        }

        public abstract class ICall
        {
           public abstract void Call(IVoice voice);
        }
        public interface IVoice
        {
            string Value { get; }
        }
        public class Dog2 : ICall
        {
            public override void Call(IVoice voice)
            {
                Console.WriteLine($"狗的叫聲是{voice.Value}");
            }
        }
        public class DogVoice2 : IVoice
        {
            public string Value => "汪汪汪";
        }
        public class Show2
        {
            public void ShowVoice(ICall dog, IVoice dogVoice)
            {
                dog.Call(dogVoice);
            }
        }

        public class Cat : ICall
        {
            public override void Call(IVoice voice)
            {
                Console.WriteLine($"貓的叫聲是{voice.Value}");
            }
        }
        public class CatVoice : IVoice
        {
            public string Value => "喵喵喵";
        }


        #region 未OCP
        public class DogVoice
        {
            public string Value
            {
                get { return "汪汪汪"; }
            }
        }
        public class Dog
        {
            public void Call(DogVoice dogVoice)
            {
                Console.WriteLine($"狗的叫聲是{dogVoice.Value}");
            }
        }
        public class Show
        {
            public void ShowVoice(Dog dog, DogVoice dogVoice)
            {
                dog.Call(dogVoice);
            }
        } 
        #endregion
    }
}
