using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint111 : PointBase
    {
        public override string Content => $"{Player.Name} надевает очки. Появляется проекция с адресом дома : Ул. Гроу стрит дом Крутой";
        public InterrogationPoint111()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint111(),
                new SecondActionInterrogationPoint111(),
                new ThirdActionInterrogationPoint111()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг уверен , что автор не смог вспомнить адрес из ГТА 4.\n");
        }
    }

    internal class FirstActionInterrogationPoint111 : FirstAction
    {
        public override string ActionDescription => "Поехать на адрес на мерсе";
        public FirstActionInterrogationPoint111()
        {
            IsAvailable = true;
            NextPointID = 112;
        }
    }

    internal class SecondActionInterrogationPoint111 : SecondAction
    {
        public override string ActionDescription => "Поехать на адрес на такси";
        public SecondActionInterrogationPoint111()
        {
            IsAvailable = true;
            NextPointID = 112;
        }
    }

    internal class ThirdActionInterrogationPoint111 : ThirdAction
    {
        public override string ActionDescription => "Знакомый адрес";
        public ThirdActionInterrogationPoint111()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} вспоминает , что адрес похож на Сан Андрес , но ГТА 4 круче вроде...";
        }
    }
}


