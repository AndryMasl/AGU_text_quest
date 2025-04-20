using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint120 : PointBase
    {
        public override string Content => $"{Player.Name} Отталкивает ГолдДрэ, но люстра не падает и Белик обретает второе дыхание. ГолдДрэ встает и начинает кидать {Player.Instance.Name}у ПЗРК, {Player.Instance.Name} ловит ПЗРК и стреляет. Появилась записка с буквами 'БА', парни выполнили задание и спускаются вниз. {Player.Instance.Name} вызывает скорую помощь, чтобы похоронить покойников , парни прощаются";
        public InterrogationPoint120()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint120(),
                new SecondActionInterrogationPoint120(),
                new ThirdActionInterrogationPoint120()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг апплодирует стоя.\n");
        }
    }

    internal class FirstActionInterrogationPoint120 : FirstAction
    {
        public override string ActionDescription => "Поехать домой";
        public FirstActionInterrogationPoint120()
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

    internal class SecondActionInterrogationPoint120 : SecondAction
    {
        public override string ActionDescription => "Перкур в шишке";
        public SecondActionInterrogationPoint120()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} пошел в шишку и выкурил самый крутой кальян в его жизни) Дальше вернулся на локацию.";
        }
    }

    internal class ThirdActionInterrogationPoint120 : ThirdAction
    {
        public override string ActionDescription => "Погулять в Дубках";
        public ThirdActionInterrogationPoint120()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} погулял в Дубках и вернулся к локации убийства Белика";
        }
    }
}







