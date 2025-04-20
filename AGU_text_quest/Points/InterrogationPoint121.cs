using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint121 : PointBase
    {
        public override string Content => $"{Player.Name} глянул на охраника. 'Привет! Помнишь меня? В кс гамали вместе' - Сказал Юнис. 'Погодь. Юнис , не узнал меня? Это же я Макс Суков'- ответил Макс Суков . 'Почему ты охранник? Ты же в инсте учился' - спросил Юнис. 'О это долгая история' - Сказал Макс Суков" ;
        public InterrogationPoint121()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint121(),
                new SecondActionInterrogationPoint121(),
                new ThirdActionInterrogationPoint121()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг в шоке, а где его нисанчик?.\n");
        }
    }

    internal class FirstActionInterrogationPoint121 : FirstAction
    {
        public override string ActionDescription => "Ну рассказывай";
        public FirstActionInterrogationPoint121()
        {
            IsAvailable = true;
            NextPointID = 122;
        }
    }

    internal class SecondActionInterrogationPoint121 : SecondAction
    {
        public override string ActionDescription => "Нет времени, я в подвал к Тутаеву";
        public SecondActionInterrogationPoint121()
        {
            IsAvailable = true;
            NextPointID = 31;

        }
    }

    internal class ThirdActionInterrogationPoint121 : ThirdAction
    {
        public override string ActionDescription => "Ну ща ща , меня Тольна звала";
        public ThirdActionInterrogationPoint121()
        {
            IsAvailable = true;
            NextPointID = 126;
        }
    }
}








