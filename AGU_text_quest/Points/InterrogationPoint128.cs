using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint128 : PointBase
    {
        public override string Content => $"{Player.Name} берет рычаг и начинает крутить , дверь немного стала открываться. Как вдруг Бам, Путинцева отрезала серпом руку Юниса и рука осталась висеть на рычаге. Юнис убежал под парту";
        public InterrogationPoint128()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint128(),
                new SecondActionInterrogationPoint128(),
                new ThirdActionInterrogationPoint128()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Минус рука , но плюс уважение'.\n");
        }
    }

    internal class FirstActionInterrogationPoint128 : FirstAction
    {
        public override string ActionDescription => "Использовать парту, как щит и пробираться к окну";
        public FirstActionInterrogationPoint128()
        {
            IsAvailable = true;
            NextPointID = 129;
        }
    }

    internal class SecondActionInterrogationPoint128 : SecondAction
    {
        public override string ActionDescription => "Чтобы сделал на моем месте Дунаев Влад?";
        public SecondActionInterrogationPoint128()
        {
            IsAvailable = false;
            MassageAfterAction = $"'Зачем мне новый Гелик?' - это не лучшая покупка сейчас, подумал Юнис";
        }
    }

    internal class ThirdActionInterrogationPoint128 : ThirdAction
    {
        public override string ActionDescription => "Какие у меня варианты ? ";
        public ThirdActionInterrogationPoint128()
        {
            IsAvailable = false;
            MassageAfterAction = $"Ну я использую наверно парту как щит и проберусь к окну, правда руки нет(";
        }
    }
}








