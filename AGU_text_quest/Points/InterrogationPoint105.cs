using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint105 : PointBase
    {
        public override string Content => $"{Player.Name} разогнался и прыгнул в секретное место. Там {Player.Instance.Name} увидел много тренажеров и на одном из низ тягал жим лежа какой-то сверх Гиго Мега качок, издалека похож на Сарычева или Маланичева. Подойдя ближе, {Player.Name} увидел чела, который говорил : 'Бред бред бред бред'" +
          $"'Ты кто? ' - спросил {Player.Instance.Name}" +
          $"'Я GoldDre' - сказал GoldDre" +
          $"'Ты пришел мне помочь заработать монеты на галант ? ' - спросил GoldDre " +
          $"И они часами говорили про турники, качков и галант , а как {Player.Instance.Name} спрашивал про работу GoldDre, так GoldDre приходил в ярость и становился ПоверВульфем который уничтожает все на своем пути. Оказалось , что GoldDre копит на галант и чтобы ему всевышний лимбо дал 1 монету , ему надо зафиксировать 5 подтягиваний, а GoldDre всегда делал 100500 и поэтому ему не дают монету";
        public InterrogationPoint105()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint105(),
                new SecondActionInterrogationPoint105(),
            };
            DoBeforeAction = DoBeforeActionLocal;
        }
        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;

            Console.WriteLine($"СильверГрэг в шоке от GoldDre , ведь СильверГрэг просто серебро в этом мире по сравнению с золотом .\n");
        }
    }

    internal class SecondActionInterrogationPoint105 : SecondAction
    {
        public override string ActionDescription => "Давай помогу";
        public SecondActionInterrogationPoint105()
        {
            IsAvailable = true;
            NextPointID = 106;
        }
    }

    internal class FirstActionInterrogationPoint105 : FirstAction
    {
        public override string ActionDescription => "Сорри , мне надо спасти Мема";
        public FirstActionInterrogationPoint105()
        {
            IsAvailable = true;
            NextPointID = 104;
        }
    }
}

