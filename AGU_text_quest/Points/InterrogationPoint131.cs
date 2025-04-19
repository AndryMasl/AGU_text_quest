using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint131 : PointBase
    {
        public override string Content => $"{Player.Name} подошел к кабинету Кабзона. Открыв кабинет {Player.Name} видит, что у доски стоит Капитан Никитин и решает какую-то задачу, а Кабзон чешат правое ухо левой рукой";
        public InterrogationPoint131()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint131(),
                new SecondActionInterrogationPoint131(),
                new ThirdActionInterrogationPoint131()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Мдэ ничего не поменялось'.\n");
        }
    }

    internal class FirstActionInterrogationPoint131 : FirstAction
    {
        public override string ActionDescription => "Идти к Тутаеву";
        public FirstActionInterrogationPoint131()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint131 : SecondAction
    {
        public override string ActionDescription => "Он че даун чтоли?";
        public SecondActionInterrogationPoint131()
        {
            IsAvailable = true;
            NextPointID = 132;
        }
    }

    internal class ThirdActionInterrogationPoint131 : ThirdAction
    {
        public override string ActionDescription => "Капитан Никитин, почему пропал мой сын?";
        public ThirdActionInterrogationPoint131()
        {
            IsAvailable = false;
            MassageAfterAction = $"'Чел, я решаю задачу и потом еще в вечерку гнать, мне некогда' - ответил капитан Никитин";
        }
    }
}









