using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint117 : PointBase
    {
        public override string Content => $"{Player.Name} толкает Белика в хату. Белик вместе с Блохиной падают на пол и Белик выстреливает прям в висок Блохиной. Качок бросается на Белика и начинает душить его , что есть мочи в мочевом пузыре) Белик весь синеет и говорит: 'Вы выиграли битву, но не выиграли войну' и стреляет в люстру наверху. {Player.Instance.Name} все это видит:";
        public InterrogationPoint117()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint117(),
                new SecondActionInterrogationPoint117(),
                new ThirdActionInterrogationPoint117()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг тоже видит это.\n");
        }
    }

    internal class FirstActionInterrogationPoint117 : FirstAction
    {
        public override string ActionDescription => "Спасти ГолдДрэ";
        public FirstActionInterrogationPoint117()
        {
            IsAvailable = true;
            NextPointID = 120;
        }
    }

    internal class SecondActionInterrogationPoint117 : SecondAction
    {
        public override string ActionDescription => "Ничего не делать";
        public SecondActionInterrogationPoint117()
        {
            IsAvailable = false;
            MassageAfterAction = $"Так нельзя";
        }
    }

    internal class ThirdActionInterrogationPoint117 : ThirdAction
    {
        public override string ActionDescription => "Подумать";
        public ThirdActionInterrogationPoint117()
        {
            IsAvailable = false;
            MassageAfterAction = $"Нет времени думать";
        }
    }
}






