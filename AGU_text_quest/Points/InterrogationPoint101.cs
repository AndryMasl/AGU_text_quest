using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint101 : PointBase
    {
        public override string Content => $"{Player.Name} смотрит на руку, а рука смотрит на него. {Player.Name} думает , что не зря нарисовал руке глаза. Долгое молчание.. Становится жарко. {Player.Name} открыл окно, которое находилось на стене, куда светил проектор и оказывается в самом лучшем мире, который никак нельзя сравнивать с биошок , ведь биошок в 3000 раз хуже атомик. {Player.Name} видит перед собой двух близняшек и достает свой ПЗРК. \n" +
          $"Рука: \"Босс, а может, не будем?\"\r\n" +
          $"Юнайс: \"Поздно, уже прицелился.\"" +
          $"и бахает их. Ба бах." +
          $"Но… дым рассеивается, а близняшки всё ещё стоят. Они неуязвимы.\r\nОдна из них кивает, другая подносит палец к виску, и в этот момент  \r\n Юнайс слышит голос в своей голове." +
            $"Рука(шёпотом): *«Ну ты, конечно, гений, стрелять в бессмертных...»* " +
            $"Рука*(громко): *«Ладно, босс, выбирай: либо в окно, либо вниз по лестнице?»*";
        public InterrogationPoint101() 
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint101(),
                new SecondActionInterrogationPoint101(),
			};
        }
    }

    internal class SecondActionInterrogationPoint101 : SecondAction
    {
        public override string ActionDescription => "Давай вниз по лестнице";
        public SecondActionInterrogationPoint101()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} бегом побежал к лестнице. Начал спускаться вниз. Какой-то странный запах? - сказал руке {Player.Instance.Name}" +
              $"'Ты дурак? Я не чувствую запаха' - ответила рука" +
              $"{Player.Instance.Name} посмотрел вниз вдоль пролетов и прикинул , что там этажей 100 и воняет немытой мошонкой , поэтому {Player.Instance.Name} попадает в петлю времени и начанает вечно падать, как вдруг {Player.Instance.Name} чуть дрыгнул ПЭНИСОМ и упал на каком-то этаже с дверью,{Player.Instance.Name} открывает дверь и там опять эта же локация";
        }
    }

    internal class FirstActionInterrogationPoint101 : FirstAction
    {
        public override string ActionDescription => "Давай в окно";
        public FirstActionInterrogationPoint101()
        {
            IsAvailable = true;
            NextPointID = 102;
        }
    }
}
