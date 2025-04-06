using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint119 : PointBase
    {
        public override string Content => $"{Player.Name} и GoldDre грустные выходят из падика, 'черт мы не убийцы чел' - СКАЗАЛ КАЧОК , Юнис вызвал полицию , чтобы спасти заложницу и попращался с Качком";
        public InterrogationPoint119()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint119(),
                new SecondActionInterrogationPoint119(),
                new ThirdActionInterrogationPoint119()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг никогда не был так расстроен.\n");
        }
    }

    internal class FirstActionInterrogationPoint119 : FirstAction
    {
        public override string ActionDescription => "Ехать на хату";
        public FirstActionInterrogationPoint119()
        {
            IsAvailable = true;
            NextPointID = 8;
        }
    }

    internal class SecondActionInterrogationPoint119 : SecondAction
    {
        public override string ActionDescription => "Подумать";
        public SecondActionInterrogationPoint119()
        {
            IsAvailable = false;
            MassageAfterAction = $"А что тут думать, домой надо";
        }
    }

    internal class ThirdActionInterrogationPoint119 : ThirdAction
    {
        public override string ActionDescription => "Сгонять попить";
        public ThirdActionInterrogationPoint119()
        {
            IsAvailable = false;
            MassageAfterAction = $"Юнис заскочил в Дикси, поздоровался с Чиржаевой и вернулся на локацию";
        }
    }
}






