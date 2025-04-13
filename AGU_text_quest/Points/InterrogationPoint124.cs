using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint124 : PointBase
    {
        public override string Content => $"{Player.Name} внимательно слушал. 'Дальше я шел за ним , потом он взял и скрафтил кирку и начал ломить кубы вниз. Мы оказались в какой-то пещере, где много лучников стреляли по нам. Я продолжал идти за ним. Охранник отвел меня в пещеру , где лежал пыльный и золотого цвета пиджак охранника. Охранник попросил меня надеть его. Дальше охранник радостный начал кричать что-то вроде я наконец свободен и не надо играть в кс. У меня пришло виденье, как только я надел пиджак. Мне сказали, как только я перестану быть охранником по своей воли и не найду достойного приемника, то весь мир рухнет и взорвется и еще все Спидом заболеют и Добрый кола пропадет с прилавка.... и вот я охранник теперь' - говорил Макс Суков";
        public InterrogationPoint124()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint124(),
                new SecondActionInterrogationPoint124(),
                new ThirdActionInterrogationPoint124()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Жесть'.\n");
        }
    }

    internal class FirstActionInterrogationPoint124 : FirstAction
    {
        public override string ActionDescription => "Ну го помогу тебе";
        public FirstActionInterrogationPoint124()
        {
            IsAvailable = true;
            NextPointID = 125;
        }
    }

    internal class SecondActionInterrogationPoint124 : SecondAction
    {
        public override string ActionDescription => "Я к тольне";
        public SecondActionInterrogationPoint124()
        {
            IsAvailable = true;
            NextPointID = 126;
        }
    }

    internal class ThirdActionInterrogationPoint124 : ThirdAction
    {
        public override string ActionDescription => "Понял , я к кобзону";
        public ThirdActionInterrogationPoint124()
        {
            IsAvailable = true;
            NextPointID = 131;
        }
    }
}








