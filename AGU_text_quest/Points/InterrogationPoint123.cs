using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint123 : PointBase
    {
        public override string Content => $"'Я приехал к нему. Дальше было все как обычно. Каточка в кс и я его ОУ ЕС) После предыдущий охранник пустил слезы и куда-то убежал... Я начал его искать, кричал. Потом я решил проверить в раздевалке и девочек и вижу он сидит с женскими трусами на голове. Я сразу спросил , что ты делаешь ? Он просто молча дал мне трусы и попросил надеть. Я надел эти трусы на себя и оказался в новой реальности, все было темно и только я и охранник. Он сказал идем за мной.' - говорил Макс Суков";
        public InterrogationPoint123()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint123(),
                new SecondActionInterrogationPoint123(),
                new ThirdActionInterrogationPoint123()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Надеюсь трусы чистые были'.\n");
        }
    }

    internal class FirstActionInterrogationPoint123 : FirstAction
    {
        public override string ActionDescription => "Ты нарик?";
        public FirstActionInterrogationPoint123()
        {
            IsAvailable = false;
            MassageAfterAction = $"'Нет' - ответил Макс Суков";
        }
    }

    internal class SecondActionInterrogationPoint123 : SecondAction
    {
        public override string ActionDescription => "Очень интересно, но как ты стал охранником то ?";
        public SecondActionInterrogationPoint123()
        {
            IsAvailable = true;
            NextPointID = 124;
        }
    }

    internal class ThirdActionInterrogationPoint123 : ThirdAction
    {
        public override string ActionDescription => "Мне бы к Тольне";
        public ThirdActionInterrogationPoint123()
        {
            IsAvailable = true;
            NextPointID = 126;
        }
    }
}








