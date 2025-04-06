using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint108 : PointBase
    {
        public override string Content => $"Юнис отказывается от пива, встает и медленно отправляется к выходу, опустив голову вниз. Юнис видит, что лежит пивная пробка и решил её поднять. Подняв пивную пробку он увидел на ней букву 'О'. Подняв голову перед собой, Юнис видит качка. Качек видит Юниса. Качок:'Поздравляю, ты прошел задание и бьет Юниса по грудаку, так сильно, что Юнис отлетает обратно в город Г'";
        public InterrogationPoint108()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint108(),
                new SecondActionInterrogationPoint108(),
            };
        }
    }

    internal class SecondActionInterrogationPoint108 : SecondAction
    {
        public override string ActionDescription => "Нееет , я хочу быть в прекрасном мире атомика всю жизнь и общаться с рукой";
        public SecondActionInterrogationPoint108()
        {
            IsAvailable = false;
            MassageAfterAction = $"Рука уже ничего не отвечала, а спереди стояли те самые коробки";
        }
    }

    internal class FirstActionInterrogationPoint108 : FirstAction
    {
        public override string ActionDescription => "Дальше спасть мема";
        public FirstActionInterrogationPoint108()
        {
            IsAvailable = true;
            NextPointID = 8;
        }
    }
}
