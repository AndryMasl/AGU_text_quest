using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint133 : PointBase
    {
        public override string Content => $"{Player.Name} по фастику начал писал самостоялку, как вдруг Кабзону на его Кабзонофон позвонила пышка со второго этажа и он радостно ушел к ней";
        public InterrogationPoint133()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint133(),
                new SecondActionInterrogationPoint133(),
                new ThirdActionInterrogationPoint133()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг - 'Время удалить все с ПК'.\n");
        }
    }

    internal class FirstActionInterrogationPoint133 : FirstAction
    {
        public override string ActionDescription => "Ну он ушел и я пойду к Тутаеву";
        public FirstActionInterrogationPoint133()
        {
            IsAvailable = true;
            NextPointID = 31;
        }
    }

    internal class SecondActionInterrogationPoint133 : SecondAction
    {
        public override string ActionDescription => "Подойти к ПК и поставить всем пять и удалить Золотую осень";
        public SecondActionInterrogationPoint133()
        {
            IsAvailable = true;
            NextPointID = 134;
        }
    }

    internal class ThirdActionInterrogationPoint133 : ThirdAction
    {
        public override string ActionDescription => "Бля чет ничего не охото";
        public ThirdActionInterrogationPoint133()
        {
            IsAvailable = false;
            MassageAfterAction = $"Наебал охото)";
        }
    }
}










