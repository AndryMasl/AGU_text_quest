using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint112 : PointBase
    {
        public override string Content => $"Приехав на адрес {Player.Name} видит странную надпись на стене. 'Гадание , в том числе на кофейном зерне'. Зайдя в здание , там была кофейня. Юнис вспоминает , что не любит нормис кофе и засрал его когда-то. Подойдя к стойке бара он увидел гадалку Торопкина" +
            $"'О это вы' - сказал Торопкин, 'Мне надо спасти сына и получить оставшиеся буквы' - сказал Юнис. Они присели на стол. Торопкин разложил карты ТАРО. 'По картам я вижу, что тебе надо убить некого Никиту Белик, который живет в Лос Сантос , рядом с тимкой'" ;
        public InterrogationPoint112()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint112(),
                new SecondActionInterrogationPoint112(),
                new ThirdActionInterrogationPoint112()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг прям утверждается , что Белик - это фамилия , как в ГТА 4.\n");
        }
    }

    internal class FirstActionInterrogationPoint112 : FirstAction
    {
        public override string ActionDescription => "Как он выглядит Никита Белик?";
        public FirstActionInterrogationPoint112()
        {
            IsAvailable = false;
            MassageAfterAction = $"Торопкин говорит: 'Ну как Иващенко Никита'";
        }
    }

    internal class SecondActionInterrogationPoint112 : SecondAction
    {
        public override string ActionDescription => "Поехали к нему на хату";
        public SecondActionInterrogationPoint112()
        {
            IsAvailable = true;
            NextPointID = 113;
        }
    }

    internal class ThirdActionInterrogationPoint112 : ThirdAction
    {
        public override string ActionDescription => "Мне нужен Протеин, чтобы расслабиться";
        public ThirdActionInterrogationPoint112()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} ждет , пока Торопкин намешает протеина. 'Протеин у вас хороший , жаль что на воде( , Я фанат на молоке' - сказад Юнис и выкидывает шейкер на пол";
        }
    }
}


