using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint116 : PointBase
    {
        public override string Content => $"{Player.Name} и GoldDre стоят у квартиры Белика. Они звонят в звонок. Им открывает дверь разъяренный Никита у которого в заложницах Блохина и к виску Блохиной приложен пестик. 'Думали я так легко отдам ваши секретные буквы' - сказал Белик";
        public InterrogationPoint116()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint116(),
                new SecondActionInterrogationPoint116(),
                new ThirdActionInterrogationPoint116()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг думает, что Белик так бы не пеоступил, но такой сейчас сюжет, ничего не поделать.\n");
        }
    }

    internal class FirstActionInterrogationPoint116 : FirstAction
    {
        public override string ActionDescription => "Убить всех";
        public FirstActionInterrogationPoint116()
        {
            IsAvailable = true;
            NextPointID = 117;
        }
    }

    internal class SecondActionInterrogationPoint116 : SecondAction
    {
        public override string ActionDescription => "Постараться убить только Белика";
        public SecondActionInterrogationPoint116()
        {
            IsAvailable = true;
            NextPointID = 118;
        }
    }

    internal class ThirdActionInterrogationPoint116 : ThirdAction
    {
        public override string ActionDescription => "Никого не убивать";
        public ThirdActionInterrogationPoint116()
        {
            IsAvailable = true;
            NextPointID = 119;
        }
    }
}





