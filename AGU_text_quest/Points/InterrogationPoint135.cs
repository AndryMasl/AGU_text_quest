using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint135 : PointBase
    {
        public override string Content => $"{Player.Name} спрашивает - 'А что произошло?'. 'Ты удалил золотую осень, а там находилась вся его душа, удалив игру , ты убил его и сделал всю школу умнее и разумнее, теперь не будет самостоялок в шк на последних 15 минутах' - сказала толстая жена Кабзона. {Player.Name} спас школу и довольный уходит по коридору";
        public InterrogationPoint135()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint135(),
                new SecondActionInterrogationPoint135(),
                new ThirdActionInterrogationPoint135()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'ГГ красава'.\n");
        }
    }

    internal class FirstActionInterrogationPoint135 : FirstAction
    {
        public override string ActionDescription => "Пойти к Тутаеву";
        public FirstActionInterrogationPoint135()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint135 : SecondAction
    {
        public override string ActionDescription => "Отлить в толчке";
        public SecondActionInterrogationPoint135()
        {
            IsAvailable = false;
            MassageAfterAction = $"ГГ отлил в толчке и скинул сахар в бак. Вернулся в коридор";
        }
    }

    internal class ThirdActionInterrogationPoint135 : ThirdAction
    {
        public override string ActionDescription => "Закинуть снюсик";
        public ThirdActionInterrogationPoint135()
        {
            IsAvailable = false;
            MassageAfterAction = $"У меня нет снюсика";
        }
    }
}












