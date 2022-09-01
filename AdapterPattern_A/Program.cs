using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern_A
{
    internal class Program
    {
        /// <summary>
        /// 轉接器模式
        /// 在舊有行為上添加新的方法
        /// 但又要保持單一職責模式
        /// 所以會再舊方法上注入新方法 ，使用者呼叫的方法是呼叫舊方法，但實際上已經被轉成新的方法了
        /// 以企鵝為例 鴨子要模仿成企鵝(因為動物園企鵝不夠，拿鴨子充數，所以企鵝轉接器是注入鴨子(舊方法)+模仿成企鵝的行為(新方法)
        /// 以銀行為例 BankA 使用卡機A 刷卡  銀行B 使用卡機B 刷卡 ， 現在要讓銀行B使用卡機A刷卡  要做一個ˊ轉接成卡機A的動作 
        /// 以化學藥劑為例
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 轉接企鵝

            Penguins penguin = new KingPenguins();//正常的企鵝
            Duck duck = new MallardDuck();//正常的鴨子

            Penguins duckAdapter = new DuckAdapter(duck); //叫鴨子穿上企鵝套裝(轉接器)
            Console.Write("\n\n鴨子展示：\n"); //正常鴨子
            duck.Duck_walk();
            duck.Duck_quack();


          
            Console.WriteLine("\n\n國王企鵝展示：");//正常企鵝
            penguin.Penguin_walk();
            penguin.Penguin_gobble();

            Console.WriteLine("\n\n假裝是企鵝的鴨子展示：");
            duckAdapter.Penguin_walk();//模仿企鵝  實際上就是企鵝方法注入鴨子的方法進去
            duckAdapter.Penguin_gobble();
            Console.ReadKey();
            #endregion
            
            #region 銀行卡機轉接
            BankA bankA = new BankA();
            BankB bankB = new BankB();

            BankBAdapter bankBAdapter = new BankBAdapter(bankB);

            bankBAdapter.BankA_WriteDB();
            bankBAdapter.BankA_PrintA();
            Console.ReadKey(); 
            #endregion
        }
    }
    #region 銀行卡機轉接

    public interface ICreditCardA
    {
        void BankA_PrintA();//列印明細
        void BankA_WriteDB();//紀錄DB
    }

    public class BankA : ICreditCardA
    {
        public void BankA_PrintA()//列印明細
        {
            Console.WriteLine("A列印明細工作");
        }
        public void BankA_WriteDB()//紀錄DB
        {
            Console.WriteLine("A紀錄DB工作");
        }
    }
    public interface ICreditCardB
    {
        void BankB_PrintA();//列印明細
        void BankB_WriteDB();//紀錄DB
    }

    public class BankB : ICreditCardB
    {
        public void BankB_PrintA()//列印明細
        {
            Console.WriteLine("B列印明細工作");
        }
        public void BankB_WriteDB()//紀錄DB
        {
            Console.WriteLine("B紀錄DB工作");
        }
    }


    public class BankBAdapter : ICreditCardA
    {
        public BankB bankB;
        public BankBAdapter(BankB _bankB)
        {
            bankB = _bankB;
        }

        public void BankA_PrintA()//列印明細
        {
            bankB.BankB_PrintA();
            Console.WriteLine("轉接列印明細工作");
        }
        public void BankA_WriteDB()//紀錄DB
        {
            bankB.BankB_WriteDB();
            Console.WriteLine("轉接紀錄DB工作");
        }

    }

    #endregion

    #region 轉接企鵝邏輯

    public interface Penguins
    {
        void Penguin_gobble();
        void Penguin_walk();
    }

    public class KingPenguins : Penguins
    {
        public void Penguin_gobble()
        {
            Console.WriteLine("企鵝叫");
        }

        public void Penguin_walk()
        {
            Console.WriteLine("企鵝走路");
        }
    }
    public interface Duck
    {
        void Duck_quack();
        void Duck_walk();
    }
    public class MallardDuck : Duck
    {
        public void Duck_quack()
        {
            Console.WriteLine("鴨子叫");
        }

        public void Duck_walk()
        {
            Console.WriteLine("鴨子走路");
        }
    }
    public class DuckAdapter : Penguins
    {
        Duck gDuck;

        public DuckAdapter(Duck pDuck)
        {
            this.gDuck = pDuck;
        }

        #region Penguins 成員
        public void Penguin_gobble()
        {
            gDuck.Duck_quack(); 
            Console.Write("壓低聲音！\n");   
        }

        public void Penguin_walk()
        {
            gDuck.Duck_walk();
            Console.Write("翅膀向下伸值，左右搖擺！\n");
        }

        #endregion
    } 
    #endregion




}
