using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint122 : PointBase
    {
        public override string Content => $"Макс Суков рассказывает, что раньше, еще давно во времена школы и начала учебы в инсте он до сих пор общался с предыдущим охранником. Они гамали в кс, веселились, бегали в парке. Но в один день, когда они плотнячком сдружились. Предыдущий охранник позвал Максима Сукова к себе в шк.";
        public InterrogationPoint122()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint122(),
                new SecondActionInterrogationPoint122(),
                new ThirdActionInterrogationPoint122()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Ну нет, го в другое место, не хочу его слушать' .\n");
        }
    }

    internal class FirstActionInterrogationPoint122 : FirstAction
    {
        public override string ActionDescription => "И что дальше было? ";
        public FirstActionInterrogationPoint122()
        {
            IsAvailable = true;
            NextPointID = 123;
        }
    }

    internal class SecondActionInterrogationPoint122 : SecondAction
    {
        public override string ActionDescription => "А что Тутаева подвальчик тут? Можно я схожу? ";
        public SecondActionInterrogationPoint122()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class ThirdActionInterrogationPoint122 : ThirdAction
    {
        public override string ActionDescription => "Есть снюсик?";
        public ThirdActionInterrogationPoint122()
        {
            IsAvailable = false;
            MassageAfterAction = $"'Какой снюс?' - спросил Суков. 'Жалко, что я добрый сегодня, иначе снес бы все ПЗРК' - подумал Юнис";
        }
    }
}








