using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint125 : PointBase
    {
        public override string Content => $"{Player.Name} пишет в вк Нечевину и говорит - 'Подойди в шк, в раздевалку тут женские трусы бесплатно можно понюхать' - написал ему {Player.Instance.Name}. Нечевин быстро прибежал с горящими глазами и рынулся надевать на себя женские трусы. Там Макс Суков также обманными действиями заставил надеть Нечевина пиджак на себя и теперь охранник шк Нечевин) Вот рофл. 'Спасибо {Player.Instance.Name} большое' - сказал Макс Суков и довольный убежал из шк";
        public InterrogationPoint125()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint125(),
                new SecondActionInterrogationPoint125(),
                new ThirdActionInterrogationPoint125()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг аплодирует стоя.\n");
        }
    }

    internal class FirstActionInterrogationPoint125 : FirstAction
    {
        public override string ActionDescription => "Ну теперь к Тольне";
        public FirstActionInterrogationPoint125()
        {
            IsAvailable = true;
            NextPointID = 126;
        }
    }

    internal class SecondActionInterrogationPoint125 : SecondAction
    {
        public override string ActionDescription => "Пойду к Кабзону";
        public SecondActionInterrogationPoint125()
        {
            IsAvailable = true;
            NextPointID = 131;
        }
    }

    internal class ThirdActionInterrogationPoint125 : ThirdAction
    {
        public override string ActionDescription => "Сгонять к Тутаеву";
        public ThirdActionInterrogationPoint125()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }
}








