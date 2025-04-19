using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint109 : PointBase
    {
        public override string Content => $"Весь бар встает в окне появляется очень яркий свет. Пришло озарение всему этому бару. 'А давайте поднимем бокал за Атомик' - кто-то крикнул из зала. Юнис открывает клинское пивко и видит там на кольце от банки букву 'О'.Подняв голову перед собой, Юнис видит качка. Качек видит Юниса. Качок:'Поздравляю, ты прошел задание и бьет Юниса по грудаку, так сильно, что Юнис отлетает обратно в город Г'";
        public InterrogationPoint109()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint109(),
                new SecondActionInterrogationPoint109(),
            };
        }
    }

    internal class FirstActionInterrogationPoint109 : FirstAction
    {
        public override string ActionDescription => "Нееет , я хочу быть в прекрасном мире атомика всю жизнь и общаться с рукой";
        public FirstActionInterrogationPoint109()
        {
            IsAvailable = false;
            MassageAfterAction = $"Рука уже ничего не отвечала, а спереди стояли те самые коробки";
        }
    }

    internal class SecondActionInterrogationPoint109 : SecondAction
    {
        public override string ActionDescription => "Дальше спасть мема";
        public SecondActionInterrogationPoint109()
        {
            IsAvailable = true;
            NextPointID = 8;
            DoAfterAction = DoAfterActionLocal;
        }
        private void DoAfterActionLocal(Player player)
        {
            player.letters.Add("o");
            Console.WriteLine($"{Player.Instance.Name} Полурадостный покидает бар)");
        }
    }
}
