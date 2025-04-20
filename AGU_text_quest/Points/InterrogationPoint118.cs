using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint118 : PointBase
    {
        public override string Content => $"ГолдДрэ одним движением руки снимает ремень с себя и передает Юнису. ГолдДрэ отталкивает Блохину, а Юнис накидывает ремень на шею Белику. Через пару минут Белик синеет и пропадает, а на его месте появляется записка с буквами 'БА'. Парни и Блохина выходят на улицу. Прощаются. Юнис остается один на локации.";
        public InterrogationPoint118()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint118(),
                new SecondActionInterrogationPoint118(),
                new ThirdActionInterrogationPoint118()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг рад, что они спасли заложницу.\n");
        }
    }

    internal class FirstActionInterrogationPoint118 : FirstAction
    {
        public override string ActionDescription => "Поехать домой";
        public FirstActionInterrogationPoint118()
        {
            IsAvailable = true;
            NextPointID = 8;
            DoAfterAction = DoAfterActionLocal;
        }
        private void DoAfterActionLocal(Player player)
        {
            player.dresMoney++;
            player.letters.Add("a");
            player.letters.Add("b");
            Console.WriteLine($"{Player.Instance.Name} отдает монету ГолдДрэ и говорит СПС)");
        }
    }

    internal class SecondActionInterrogationPoint118 : SecondAction
    {
        public override string ActionDescription => "Перкур в шишке";
        public SecondActionInterrogationPoint118()
        {
            IsAvailable = false;
            MassageAfterAction = $"Юнис пошел в шишку и выкурил самый крутой кальян в его жизни) Дальше вернулся на локацию.";
        }
    }

    internal class ThirdActionInterrogationPoint118 : ThirdAction
    {
        public override string ActionDescription => "Погулять в Дубках";
        public ThirdActionInterrogationPoint118()
        {
            IsAvailable = false;
            MassageAfterAction = $"Юнис погулял в Дубках и вернулся к локации убийства Белика";
        }
    }
}








