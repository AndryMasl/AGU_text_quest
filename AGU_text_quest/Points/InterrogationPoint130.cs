using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint130 : PointBase
    {
        public override string Content => $"{Player.Name} подошел в рычагу. Взял свою руку. Взял пузырек с аптечкой. {Player.Instance.Name} прислонил часть руки в месту разрыва, скрепил степлером и полил аптечкой. 'Больно конечно , но работает'- сказал {Player.Instance.Name}. {Player.Instance.Name} покрутил рычаг , дверь открылась. ";
        public InterrogationPoint130()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint130(),
                new SecondActionInterrogationPoint130(),
                new ThirdActionInterrogationPoint130()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг аплодирует стоя.\n");
        }
    }

    internal class FirstActionInterrogationPoint130 : FirstAction
    {
        public override string ActionDescription => "Идти к Тутаеву";
        public FirstActionInterrogationPoint130()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint130 : SecondAction
    {
        public override string ActionDescription => "Идти к Кабзону";
        public SecondActionInterrogationPoint130()
        {
            IsAvailable = true;
            NextPointID =131;
        }
    }

    internal class ThirdActionInterrogationPoint130 : ThirdAction
    {
        public override string ActionDescription => "Постоять";
        public ThirdActionInterrogationPoint130()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} постоял. Надо принимать решение.";
        }
    }
}








