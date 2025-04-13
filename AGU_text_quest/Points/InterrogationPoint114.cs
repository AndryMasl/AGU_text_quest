using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint114 : PointBase
    {
        public override string Content => $"{Player.Name} и GoldDre пошли в МУМУ. Качок съел все МУМУ вместе с персоналом. 'Я готов идти на дело' - сказал качок. Юнис вместе с качком поехали в Лос Антос. Пригоня к падику на асфальте лежало 2 аптечки, 2 броника и 2 узишки";
        public InterrogationPoint114()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint114(),
                new SecondActionInterrogationPoint114(),
                new ThirdActionInterrogationPoint114()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг думает: 'Я бы взял'.\n");
        }
    }

    internal class FirstActionInterrogationPoint114 : FirstAction
    {
        public override string ActionDescription => "Взять лут";
        public FirstActionInterrogationPoint114()
        {
            IsAvailable = true;
            NextPointID = 115;
        }
    }

    internal class SecondActionInterrogationPoint114 : SecondAction
    {
        public override string ActionDescription => "Не брать лут";
        public SecondActionInterrogationPoint114()
        {
            IsAvailable = true;
            NextPointID = 116;
        }
    }

    internal class ThirdActionInterrogationPoint114 : ThirdAction
    {
        public override string ActionDescription => "Перекур 5 мин";
        public ThirdActionInterrogationPoint114()
        {
            IsAvailable = false;
            MassageAfterAction = $"Парни сгоняли в Дубки в толкан и вернулись на локацию";
        }
    }
}




