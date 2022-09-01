using System;

namespace StatePattern
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public class RuningState : ICarState
    {
        public void Drive(Car car)
        {
            Console.WriteLine("���������Զ���ʻ��");
        }

        public void Stop(Car car)
        {
            Console.WriteLine("������ֹͣ��");
            car.CurrentCarState = Car.StopState;
        }

        public void SpeedUp(Car car)
        {
            Console.WriteLine("·�����ã���ʼ������ʻ��");
            car.CurrentCarState = Car.SpeedUpState;
        }

        public void SpeedDown(Car car)
        {
            Console.WriteLine("·��һ�㣬��ʼ������ʻ��");
            car.CurrentCarState = Car.SpeedDownState;
        }
    }
}