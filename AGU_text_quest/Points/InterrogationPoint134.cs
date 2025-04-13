using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint134 : PointBase
    {
        public override string Content => $"{Player.Name} заходит в электронныйц журнал и ставит всем пятерочки и удаляет золотую осень. Вдруг раздается жесткий грохот. Будто что-то взорвалось. {Player.Name} выходит в коридор и видит, как довольные ученики бегают по школе. Спускаясь на второй этаж,{Player.Name} видит что остался только костюм Кабзона и рядом стояла пухлая жена Кабзона";
        public InterrogationPoint134()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint134(),
                new SecondActionInterrogationPoint134(),
                new ThirdActionInterrogationPoint134()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Она его Жена?'.\n");
        }
    }

    internal class FirstActionInterrogationPoint134 : FirstAction
    {
        public override string ActionDescription => "Ну пофиг, я пойду к Тутаеву";
        public FirstActionInterrogationPoint134()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint134 : SecondAction
    {
        public override string ActionDescription => "Что случилось?";
        public SecondActionInterrogationPoint134()
        {
            IsAvailable = true;
            NextPointID = 135;
        }
    }

    internal class ThirdActionInterrogationPoint134 : ThirdAction
    {
        public override string ActionDescription => "Оуу Есс я его";
        public ThirdActionInterrogationPoint134()
        {
            IsAvailable = false;
            MassageAfterAction = $"Ну рил интересно что произошло";
        }
    }
}











