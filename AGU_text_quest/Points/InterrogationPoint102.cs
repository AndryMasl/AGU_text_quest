using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint102 : PointBase
    {
        public override string Content => $"{Player.Name} бежит со всей скорости в окно и прыгает. {Player.Name} закрывает глаза. Перед ним появляется картинка вся в бокалах ИКСО и играет странная музыка 'ЕЁ БОКАЛ ПОЛОН ИКСО, ОНА СКРЫВАЕТ СВОЁ ЛИЦО'. " +
            $"'Крутая музыка' - подумал {Player.Name}" +
            $"'Найс мы в мире ЛИМБО((, теперь скакать по стаканам' - сказала рука" +
            $"{Player.Name} открывает глаза и лежит в огромном стакане из-под мартини";
        public InterrogationPoint102()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint102(),
                new SecondActionInterrogationPoint102(),
                new ThirdActionInterrogationPoint102(),
            };
            DoBeforeAction = DoBeforeActionLocal;
        }
        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;

            Console.WriteLine($"СильверГрэг: 'Мартини) Болтать , но не смешивать'.\n");
        }
    }

    internal class SecondActionInterrogationPoint102 : SecondAction
    {
        public override string ActionDescription => "Я что дурак прыгать на бокалам, я слезу вниз";
        public SecondActionInterrogationPoint102()
        {
            IsAvailable = true;
            NextPointID = 104;
        }
    }

    internal class ThirdActionInterrogationPoint102 : ThirdAction
    {
        public override string ActionDescription => "Попрыгали по бокалам , надо спасать Мема";

        public ThirdActionInterrogationPoint102()
        {
            IsAvailable = true;
            NextPointID = 103;
        }
    }

    internal class FirstActionInterrogationPoint102 : FirstAction
    {
        public override string ActionDescription => "Рука, что делать?";

        public FirstActionInterrogationPoint102()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} сам решай))))";
        }
    }
}
