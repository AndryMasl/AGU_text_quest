using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint104 : PointBase
    {
        public override string Content => $"{Player.Name} падает вниз сквозь облака. Он оказывается в каком-то баре, где играет НЕприятная ГЕЙСКАЯ музыка из ИГРЫ биошок.{Player.Name} приземлился чисто на барный стул и видит перед собой бармена, который разливает различные напитки и одновременно убивает гадзилу из лазера , который идет из глаз бармена. Бармен поворачивается лицом к Юнису и говорит: 'Чел , сорянба, у нас сегодня только пиво'";
        public InterrogationPoint104()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint104(),
                new SecondActionInterrogationPoint104(),
            };
        }
    }

    internal class FirstActionInterrogationPoint104 : FirstAction
    {
        public override string ActionDescription => "Ну давай баночку клинского";
        public FirstActionInterrogationPoint104()
        {
            IsAvailable = true;
            NextPointID = 107;
        }
    }

    internal class SecondActionInterrogationPoint104 : SecondAction
    {
        public override string ActionDescription => "Откажусь от пива";
        public SecondActionInterrogationPoint104()
        {
            IsAvailable = true;
            NextPointID = 108;
        }
    }
}
