using System;

namespace StatePattern
{
    /// <summary>
    /// ͣ��״̬
    /// </summary>
    public class StopState : ICarState
    {
        public void Drive(Car car)
        {
            Console.WriteLine($"{car.Name}����������ʼ�Զ���ʻ��");
            car.CurrentCarState = Car.RunState;
        }

        public void Stop(Car car)
        {
            Console.WriteLine("������ֹͣ��");
        }

        public void SpeedUp(Car car)
        {
            Console.WriteLine("������ֹͣ��");
        }

        public void SpeedDown(Car car)
        {
            Console.WriteLine("������ֹͣ��");
        }
    }
}