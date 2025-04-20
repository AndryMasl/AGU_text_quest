using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint129 : PointBase
    {
        public override string Content => $"{Player.Name} из последних сил и с одной рукой облакачивает парту на бок. Вцепившись зубами за парту, {Player.Instance.Name} начинает двигать её в окну. Подойдя к окну {Player.Instance.Name} случайно роянет парту из рук, что слышат его враги. Парта , падая, случайно нажимает на курок ПЗРК в кармане {Player.Instance.Name}а и все окна лопаются от мощного взрыва. {Player.Instance.Name} нашел ствол на полу и стреляет в ослабевших Путинцеву и Кузнецову со словами - 'Я Вас Оуу Есс'. Они умирают в муках. {Player.Instance.Name} смотрит на Тольну и она начинает крутиться , будто тасманский дъявол. И превращается в обычную Тольну. Она начинала что-то говорить и как обычно быстро, но {Player.Instance.Name} не стал её слушать, ведь ему нужно было спасть мема";
        public InterrogationPoint129()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint129(),
                new SecondActionInterrogationPoint129(),
                new ThirdActionInterrogationPoint129()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Мем - это святое'.\n");
        }
    }

    internal class FirstActionInterrogationPoint129 : FirstAction
    {
        public override string ActionDescription => "Пойти к рычагу";
        public FirstActionInterrogationPoint129()
        {
            IsAvailable = true;
            NextPointID = 130;
        }
    }

    internal class SecondActionInterrogationPoint129 : SecondAction
    {
        public override string ActionDescription => "Выдохнуть";
        public SecondActionInterrogationPoint129()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} выдохнул.";
        }
    }

    internal class ThirdActionInterrogationPoint129 : ThirdAction
    {
        public override string ActionDescription => "Написать на доске Бангладеш";
        public ThirdActionInterrogationPoint129()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} пишет Бангладеш и вспонимает те моменты жизни , когда он мечтал о поездки в эту идеальную страну";
        }
    }
}







