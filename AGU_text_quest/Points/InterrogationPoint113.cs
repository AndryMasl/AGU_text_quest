using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint113 : PointBase
    {
        public override string Content => $"{Player.Name} подъехал на тимку и видит какого-то гиго качка , который орет 'Работа достала, не могу накопить на галант, сейчас все тут разъебу' - кричал качок у тимки. {Player.Instance.Name} подошел к качку. 'Йоу , чел , а ты силен. Помоги с одним дельцем, в долгу не останусь.' - Говорит {Player.Instance.Name} и показывает качку монету. 'Я готов, я GoldDre' - сказал качок, Качок говорит , что ему надо сначала подхаваться";
        public InterrogationPoint113()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint113(),
                new SecondActionInterrogationPoint113(),
                new ThirdActionInterrogationPoint113()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг тоже подхавался бы.\n");
        }
    }

    internal class FirstActionInterrogationPoint113 : FirstAction
    {
        public override string ActionDescription => "Пойти в Бургер Кинг";
        public FirstActionInterrogationPoint113()
        {
            IsAvailable = false;
            MassageAfterAction = $"Качок говорит: 'Я такое не ем'";
        }
    }

    internal class SecondActionInterrogationPoint113 : SecondAction
    {
        public override string ActionDescription => "Пойти в муму";
        public SecondActionInterrogationPoint113()
        {
            IsAvailable = true;
            NextPointID = 114;
        }
    }

    internal class ThirdActionInterrogationPoint113 : ThirdAction
    {
        public override string ActionDescription => "Не кормить качка";
        public ThirdActionInterrogationPoint113()
        {
            IsAvailable = false;
            MassageAfterAction = $"Качок говорит: 'Тогда я тебя съем'. {Player.Instance.Name} не готов погибнуть такой смертью";
        }
    }
}



