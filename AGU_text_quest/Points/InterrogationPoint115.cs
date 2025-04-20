using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint115 : PointBase
    {
        public override string Content => $"{Player.Name} и GoldDre взяли лут. У них появилась шкала Хэпэшки и оружие, которое убиралось колесиком. Они пошли в падик, но вдруг с верхних этажей открыли огонь по ним. Одна пуля пробила броню качка, {Player.Name} начал отстреливаться , но тоже словил 1 пулю в броню и сила брони закончилась у парней. {Player.Instance.Name} , как спецназовец вкатил всю обойму во врагов и у него закончились все патроны. Качок отстреливался из укрытия стен и расстрелял всех оставшихся врагов. Теперь у парней нет оружия и брони(";
        public InterrogationPoint115()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint115(),
                new SecondActionInterrogationPoint115(),
                new ThirdActionInterrogationPoint115()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг в шоке от увиденного и как у них нет 2х звезд от полиции.\n");
        }
    }

    internal class FirstActionInterrogationPoint115 : FirstAction
    {
        public override string ActionDescription => "Идти к квартире";
        public FirstActionInterrogationPoint115()
        {
            IsAvailable = true;
            NextPointID = 116;
        }
    }

    internal class SecondActionInterrogationPoint115 : SecondAction
    {
        public override string ActionDescription => "Отлить в падике";
        public SecondActionInterrogationPoint115()
        {
            IsAvailable = false;
            MassageAfterAction = $"Парни ссут в падике";
        }
    }

    internal class ThirdActionInterrogationPoint115 : ThirdAction
    {
        public override string ActionDescription => "Отдышаться";
        public ThirdActionInterrogationPoint115()
        {
            IsAvailable = false;
            MassageAfterAction = $"Парни отдышались в падике";
        }
    }
}





