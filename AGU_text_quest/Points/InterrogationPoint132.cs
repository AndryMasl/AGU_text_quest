using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint132 : PointBase
    {
        public override string Content => $"{Player.Name} говорит в слух : 'Он что даун?'. Кабзон это слышит. И быстро дает всем самостоятельную работу. 'Я же Даун' - сказал Кобзон";
        public InterrogationPoint132()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint132(),
                new SecondActionInterrogationPoint132(),
                new ThirdActionInterrogationPoint132()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Во Во, правда даун'.\n");
        }
    }

    internal class FirstActionInterrogationPoint132 : FirstAction
    {
        public override string ActionDescription => "Я шк закончил давно, пойду к Тутаеву";
        public FirstActionInterrogationPoint132()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint132 : SecondAction
    {
        public override string ActionDescription => "Ну давай по фасту напишу";
        public SecondActionInterrogationPoint132()
        {
            IsAvailable = true;
            NextPointID = 133;
        }
    }

    internal class ThirdActionInterrogationPoint132 : ThirdAction
    {
        public override string ActionDescription => "Ща с ГДЗ спишу";
        public ThirdActionInterrogationPoint132()
        {
            IsAvailable = false;
            MassageAfterAction = $"'Даун все слышал, давай мобилу' - сказал Кабзон";
        }
    }
}









