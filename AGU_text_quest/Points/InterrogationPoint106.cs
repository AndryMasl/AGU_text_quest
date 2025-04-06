using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint106 : PointBase
    {
        public override string Content => $"{Player.Instance.Name} залез на турник. Что делать дальше?";
        public InterrogationPoint106()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint106(),
                new SecondActionInterrogationPoint106(),
            };
            DoBeforeAction = DoBeforeActionLocal;
        }
        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;

            Console.WriteLine($"СильверГрэг изо всех сил кричит давай вперед!!!.\n");
        }
    }

    internal class SecondActionInterrogationPoint106 : SecondAction
    {
       public override string ActionDescription => "Слезть с турника";
        public SecondActionInterrogationPoint106()
        {
            IsAvailable = true;
            NextPointID = 104;
        }

    }

    internal class FirstActionInterrogationPoint106 : FirstAction
    {
        public override string ActionDescription => "Подтянуться на лайте 5 раз";
        public FirstActionInterrogationPoint106()
        {
            IsAvailable = true;
            NextPointID = 104;
            DoAfterAction = DoAfterActionLocal;
        }

        private void DoAfterActionLocal(Player player)
        {
            player.monetGold++;
            Console.WriteLine($"{Player.Instance.Name} молча подтягивается 5 раз. И спрыгивает с турника со всей силы и проваливается вниз....");
        }
    }
}
