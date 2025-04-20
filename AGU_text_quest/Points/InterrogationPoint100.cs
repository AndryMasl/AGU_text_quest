using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint100 : PointBase
    {
        public override string Content => $"В коробке лежала какая-то непонятная Неваляшка. {Player.Name} взял эту хрень и случайно уронил, оттуда выпал микропроект и сразу начал проецировать на стену. {Player.Name} смотрит на стену, а там роботы из атомика какают на стену в сторону {Player.Name}а. {Player.Name} вспомнил атомик и задумался , как бы поступил майор Нечевин(Нечаяв(Майор(Атомик)))?";
        public InterrogationPoint100()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint100(),
                new SecondActionInterrogationPoint100(),
			};
            DoBeforeAction = DoBeforeActionLocal;
        }
        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;

            Console.WriteLine($"СильверГрэг вызывает GoldDre и хвастается моментом в проге про атомик и говорит, что Биошок говно и нет его в проге.\n");
        }
    }

    internal class FirstActionInterrogationPoint100 : FirstAction
    {
        public override string ActionDescription => "Он бы погорил в пивом в пятерочке";
        public FirstActionInterrogationPoint100()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} пошел быстро на улицу. Достал свой Iphone 16 PRO MAX на 256 gb и зашел в приложение яндекс карты. По близости оказался только ДИКСИ. Юнис расстроенный вернулся домой\n";
            DoAfterAction = DoAfterActionLocal;
        }
        private void DoAfterActionLocal(Player player)
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"BronzeАмир любит ДИКСИ , потому там бухает Чижаева с бомжами : 'Сказал СильверГрэг'\n");
        }
    }

    internal class SecondActionInterrogationPoint100 : SecondAction
    {
        public override string ActionDescription => "Он бы погорил с рукой";
        public SecondActionInterrogationPoint100()
        {
            IsAvailable = true;
            NextPointID = 101;
        }
    }
}
