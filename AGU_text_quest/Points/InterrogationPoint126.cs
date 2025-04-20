using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint126 : PointBase
    {
        public override string Content => $"{Player.Name} зашел в кабинет Тольны. Он видит, как в кабинете темно и все окна замазаны какой-то черной краской. В углу кабинета стояли над партой Путинцева, Кузнецова и Тольна. Тольна была будто Демитреску из резидента с 2 дочерми( Подойдя к ним ближе , они обернулись , на парте было видно тело физрука, который на последнем издыхании говорил - 'Убегай'";
        public InterrogationPoint126()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint126(),
                new SecondActionInterrogationPoint126(),
                new ThirdActionInterrogationPoint126()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Явный резидент'.\n");
        }
    }

    internal class FirstActionInterrogationPoint126 : FirstAction
    {
        public override string ActionDescription => "Убежать к Кабзону";
        public FirstActionInterrogationPoint126()
        {
            IsAvailable = true;
            NextPointID = 131;
        }
    }

    internal class SecondActionInterrogationPoint126 : SecondAction
    {
        public override string ActionDescription => "Не убегать";
        public SecondActionInterrogationPoint126()
        {
            IsAvailable = true;
            NextPointID = 127;
        }
    }

    internal class ThirdActionInterrogationPoint126 : ThirdAction
    {
        public override string ActionDescription => "Покричать";
        public ThirdActionInterrogationPoint126()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} покричал и привлек внимание";
        }
    }
}









