using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint127 : PointBase
    {
        public override string Content => $"Путинцева схватила какой то серп. Кузнецова начала бежать на Юниса. А Тольна просто говорила - 'Убейте его', Юнис немного отошел назад и дверь кабинета сразу закрылась. Рядом был рычаг, который явно поворачивался и открывал дверь. Около рычага лежала какая-то баночка с наклейкой креста...";
        public InterrogationPoint127()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint127(),
                new SecondActionInterrogationPoint127(),
                new ThirdActionInterrogationPoint127()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Надо достать пзрк и палить'.\n");
        }
    }

    internal class FirstActionInterrogationPoint127 : FirstAction
    {
        public override string ActionDescription => "Бежать к рычагу";
        public FirstActionInterrogationPoint127()
        {
            IsAvailable = true;
            NextPointID = 128;
        }
    }

    internal class SecondActionInterrogationPoint127 : SecondAction
    {
        public override string ActionDescription => "Бежать на Путинцеву";
        public SecondActionInterrogationPoint127()
        {
            IsAvailable = false;
            MassageAfterAction = $"Юнис побежал на Путинцеву и проскачил под ней. Он оказался прямо около Тольны. Тольна оттолкнула Юниса обратно к двери";
        }
    }

    internal class ThirdActionInterrogationPoint127 : ThirdAction
    {
        public override string ActionDescription => "Умереть , как герой смотря на этот пиздец";
        public ThirdActionInterrogationPoint127()
        {
            IsAvailable = false;
            MassageAfterAction = $"Не время умирать, надо спасать Мема";
        }
    }
}








