using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLogic;

namespace Points
{
    internal class InterrogationPoint110 : PointBase
    {
        public override string Content => $"{Player.Name} открывает коробку и там лежат крутые очки РэйБен, прям как на садоводе. У {Player.Instance.Name}а пошла слеза от былых времен перепродаж и богаств.";
        public InterrogationPoint110()
        {
            Actions = new()
            {
                new FirstActionInterrogationPoint110(),
                new SecondActionInterrogationPoint110(),
                new ThirdActionInterrogationPoint110()
            };
            DoBeforeAction = DoBeforeActionLocal;
        }

        private void DoBeforeActionLocal()
        {
            if (!Player.Instance.SilverGreg)
                return;
            Console.WriteLine($"СильверГрэг тоже пускает слезу по времена садовода.\n");
        }
    }

    internal class FirstActionInterrogationPoint110 : FirstAction
    {
        public override string ActionDescription => "Снять свои очки и надеть РейБен";
        public FirstActionInterrogationPoint110()
        {
            IsAvailable = true;
            NextPointID = 111;
        }
    }

    internal class SecondActionInterrogationPoint110 : SecondAction
    {
        public override string ActionDescription => "Надеть РейБен на свои очки";
        public SecondActionInterrogationPoint110()
        {
            IsAvailable = true;
            NextPointID = 111;
        }
    }

    internal class ThirdActionInterrogationPoint110 : ThirdAction
    {
        public override string ActionDescription => "Продать РейБен на авито";
        public ThirdActionInterrogationPoint110()
        {
            IsAvailable = false;
            MassageAfterAction = $"{Player.Instance.Name} достал телефон , чтобы отфокать очки и выложить на авито ,но на заставке телефона у {Player.Instance.Name}а стоял Аборт с фразой 'Why not abort' и {Player.Instance.Name} опомнился... \n";
        }
    }
}

