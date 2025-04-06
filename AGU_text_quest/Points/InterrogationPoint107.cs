using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint107 : PointBase
    {
        public override string Content => $"Бармен дает Юнису баночку клинского и открывалку и обратно отварачивается. Юнис замечает на баночке какую-то записку... Юнис открывает записку и там написано : 'Признай, что Биошок полный кал по сравнению с Атомик'";
        public InterrogationPoint107()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint107(),
                new SecondActionInterrogationPoint107(),
            };
        }
    }

    internal class SecondActionInterrogationPoint107 : SecondAction
    {
        public override string ActionDescription => "Атомик в 100 раз круче";
        public SecondActionInterrogationPoint107()
        {
            IsAvailable = true;
            NextPointID = 109;
        }
    }

    internal class FirstActionInterrogationPoint107 : FirstAction
    {
        public override string ActionDescription => "НЕТ";
        public FirstActionInterrogationPoint107()
        {
            IsAvailable = false;
            MassageAfterAction = $"Нет! Никода не признаю, что биошок круче атомик. Юнис глядя в народ бара громко говорит :";
        }
    }
}
