using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint103 : PointBase
    {
        public override string Content => $"{Player.Name} встал , немного отбежал назад и со всей скорости бежал вперед, подбегая к краю он оттолкнулся, что есть мочи в мочевом пузыре. И оказался на острове , где стоял какой-то домик из пряника. {Player.Instance.Name} проголодался и начал хавать домик из пряника. Почти доев домик, от окошка вышел какой-то ГИГОКАЧ МЭН и сказал : 'Сосал?'.\n" +
          $"{Player.Instance.Name} ответил : 'я твою мамку ипал'\n" +
          $"Началась эпичная битва и в итоге {Player.Instance.Name} услышал знакомую песню. Покашеварим здесь,обзоры от Витали. {Player.Instance.Name} приклонился перед челом и он угостил его самыми вкусными сушами в мире. Дальше тебе надо прыгать вниз из мира Лимбо , либо ты можешь прыгнуть на маленький остров , который приведет тебя в СЕКРЕТНОЕ место";
        public InterrogationPoint103()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint103(),
                new SecondActionInterrogationPoint103(),
            };
            DoBeforeAction = DoBeforeActionLocal;
        }
        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;

            Console.WriteLine($"СильверГрэг просто в шоке) Это что Покашеварим помог {Player.Instance.Name}у, как жаль, что я не могу попробывать это самые лучшие суши в мире.\n");
        }
    }

    internal class SecondActionInterrogationPoint103 : FirstAction
    {
        public override string ActionDescription => "Прыгаю вниз";
        public SecondActionInterrogationPoint103()
        {
            IsAvailable = true;
            NextPointID = 104;
            DoAfterAction = DoAfterActionLocal;
        }
        private void DoAfterActionLocal(Player player)
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"Будет больно : 'Сказал СильверГрэг'\n");
        }
    }

    internal class FirstActionInterrogationPoint103 : SecondAction
    {
        public override string ActionDescription => "Ну го в секретное место по фастику";
        public FirstActionInterrogationPoint103()
        {
            IsAvailable = true;
            NextPointID = 105;
        }
    }
}
