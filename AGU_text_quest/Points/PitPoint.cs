using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class PitPoint : PointBase
	{
		public override string Content => $"Все внимание {Player.Instance.Name}а сосредоточено на углублении.";

        public PitPoint()
        {
			Actions = new()
			{
				new FirstActionPitPoint(),
				new SecondActionPitPoint(),
				new ThirdActionPitPoint(),
				new FourthActionPitPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.pitAnswer.Count == 0)
			{
				Console.WriteLine($"{Player.Instance.Name} бежит к нему. На дне стоит Мем. В яму медленно заливается суспензия. Скоро она достигнет уровня яиц. Мему грозит смертельная опасность.\n");
			}
			if (Player.Instance.Am)
			{
				Actions.First(x => x.Number == ThirdAction.ACTION_NUMBER).IsAvailable = true;
			}
			if (!Player.SilverGreg)
			{
				Actions.First(x => x.Number == FourthAction.ACTION_NUMBER).IsAvailable = true;
			}

			SetVisibleByList(Player.Instance.pitAnswer);
			ConfigureFourthAction(Player.Instance);
		}

		private void ConfigureFourthAction(Player player)
		{
			var fourthAction = Actions.First(x => x.Number == FourthAction.ACTION_NUMBER);

			if (player.InterrogationResult > 0 && !player.SilverGreg)
			{
				fourthAction.NextPointID = 34;
			}
			if (player.InterrogationResult == 0 && player.dresMoney == 0)
			{
				fourthAction.NextPointID = 34;
			}
			if (player.InterrogationResult == 0 && player.dresMoney > 0)
			{
				fourthAction.NextPointID = 35;
			}
			if (player.InterrogationResult < 0 && player.dresMoney <= 1)
			{
				fourthAction.NextPointID = 34;
			}
			if (player.InterrogationResult < 0 && player.dresMoney > 1)
			{
				fourthAction.NextPointID = 35;
			}
		}
	}

	internal class FourthActionPitPoint : FourthAction
	{
		public override string ActionDescription => "Вытащить Мема из ямы.";

        public FourthActionPitPoint()
        {
			IsAvailable = true;
			// NextPointID = 34;

			DoAfterAction = DoAfterActionGlobal;
        }

		private void DoAfterActionGlobal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} борясь с болью, собирает волю в кулаки, хватает Мема за шиворот и вытаскивает его из ямы. ");

			SilverGregAddition(player);

			Console.WriteLine($"\nМем: Па, ты как?\n{Player.Instance.Name}: Не переживай, все норм.\n{Player.Instance.Name} поднялся на ноги, взял Мема за руку и они пошли к выходу, подальше от этого богом забытого места.");

			if (player.InterrogationResult > 0) // ментов нет
			{
				Console.WriteLine($"Солнце светит, птички поют, небо чистое, погода отличная, день чудесный. {Player.Instance.Name} и Мем радостно удаляются в горизонт.");

				if (player.SilverGreg)
				{
					BestEnd(player);
				}
				else
				{
					Console.WriteLine($"Однако с каждым шагом {Player.Instance.Name} ослабевает все сильнее и сильнее. Вирус постепенно разрушает его изнутри.\n");
				}
			}
			else if (player.InterrogationResult == 0) // обычная облава
			{
				Console.WriteLine($"Радость длилась не долго, снаружи {Player.Instance.Name}а ждала ментовская облава. Куча ментовских автомобилей, менты наставили на выход свои пистолеты.\nМайор Либовски: {Player.Instance.Name}, Вы признаны мастером оригами и арестованы, сдавайтесь без сопротивления, иначе мы будем вынуждены открыть огонь.\n");

				if (player.dresMoney > 0)
				{
					EasyChase(player);
				}
				else
				{
					if (player.SilverGreg)
					{
						Jail(player);
					}
					else
					{
						FightWithPolice(player);
					}
				}
			}
			else // вооруженные силы в деле
			{
				Console.WriteLine($"Ничего не предвещало беду, но внезапно драма. На выходе здание обложили военные. Везде стоят БТРы, куча хорошо вооруженных солдат, полумесяцем перед выходом стоят нанки, повернув свои башни на дверь. По небу летают вертушки и дроны. Вояки явно не настроены на переговоры, с минуты на минуту начнется пальба.");

				if (player.dresMoney == 1)
				{
					Console.WriteLine($"У {Player.Instance.Name}а звонит телефон, но звонок непривычный, он достает из кармана кнопочный samsung Dre. Видимо Dre незаметно засунул его в карман {Player.Instance.Name}а.\n{Player.Instance.Name} берет трубку: Ало.\nDre: {Player.Instance.Name}, у меня тут galant сдох на трассе, жду эвакуатор, боюсь не смогу приехать, у тебя там все хорошо?\n{Player.Instance.Name}: Лучше не бывает.\nDre: Ну и супер, пока!! Пу-пу-пу (гудки)\n{Player.Instance.Name} блокирует телефон нажатием *. Раздается \"Блинк-Блинк\" ммммм, какой прикольный звук.");
				}

				if (player.dresMoney > 1)
				{
					HardChase(player);
				}
				else
				{
					FightWithMilitary(player);
				}
			}
		}

		private void FightWithMilitary(Player player)
		{
			if (player.SilverGreg)
			{
				Console.WriteLine($"Рядом появляется СильверГрэг: Мда, как я вижу, новости относительно вируса не в приоритете. Не имею представления, как выбраться из этой передряги живым.\n{Player.Instance.Name}: Я тоже.");
			}

			Console.WriteLine($"{Player.Instance.Name} рукой заводит Мема себе за спину, а сам прикрывает его своим телом. Вояки открывают огонь. Шквал пуль летит в сторону {Player.Instance.Name}а, некоторые из них достигают цели. Каждое попадание словно удар отклоняют тело {Player.Instance.Name}а, но оно тут же принимает прежнее положение. Несмотря на поток пуль, {Player.Instance.Name} не отступил ни на шаг. Словно Великая Китайская стена, {Player.Instance.Name} отгородил Мема от внешней угрозы. Вояки поняли, что такими темпами ничего не добьются и открыли залп из танков.\nДля {Player.Instance.Name}а время замедлилось в сотни раз, он наблюдал как медленно подлетают снаряды. {Player.Instance.Name} поднял кулаки и принялся отбивать снаряды. Взрывы со всех сторон, отраженные снаряды попадают в БТРы, в танки, в ряды солдат. Крики, огонь, с неба начинают падать вертушки. Школьный двор превратился в поле боя, крики, кратеры от взрывов, огромные потери среди личного состава солдат.\nМайор Либовмки подползает к рации и радирует воздушным силам: Срочно проведите ковровую бомбардировке по координатам: 55.823699, 37.567653.\nОператор: Прием, в бомбардировке отказано, по нашим данным в этой локации развернуты наши войска.\nЛибовмки: Это мы, мы запрашиваем удар, нам не справиться, враг слишком силен, мы не сможем долго его сдерживать.\nОператор: Вас понял, одобряю бомбардировке. Прощайте парни.\nПо небу на низкой тяге летят два B-52F. За ними по земле тянулся шлейф взрывов. За самолетами не оставалось ничего живого, просто месиво из камней и металла. {Player.Instance.Name} повалил Мема на землю и напрыгнул на него. Бомбардировщики с ревом пролетели над головой, все заволокло взрывами...\nОт школы не осталось ничего. Камни с треском сыплются в стороны от встающего на ноги {Player.Instance.Name}а. Мем цел и невредим. {Player.Instance.Name} осматривает окрестности, больше никто не выжил.\n");

			if (player.SilverGreg)
			{
				Console.WriteLine($"На останках танка сидит печальный СильверГрэг: Ты мего крут, но с такими ранами долго не живут. Хотел бы я как-нибудь пошутить, но момент слишком печальный.\n");
			}
		}

		private void HardChase(Player player)
		{
			if (player.dresMoney == 2)
			{
				Console.WriteLine($"{player.Name} слышит звук сигналки, все поворачивают головы в сторону, с которой на полном ходу несется mitsubishi galant 8 в офигительном состоянии, за рулем Dre.");
			}
			if (player.dresMoney > 2)
			{
				Console.WriteLine($"Раздается низкий гул, рев и гудение, кажется будто началось вторжение пришельцев. Но нет, это гудок тюнингованного Quadra galant Turbo Type-8. Пока у вояк душа ушла в пятки, с неба свалился Quadra galant, за рулем Dre.");
			}

			Console.WriteLine($"Вояки открыли огонь. Galant останавливается между {Player.Instance.Name}ом и вояками, прикрывая тем самым его от пуль.\nDre кричит: Запрыгивайте быстрее.\n{Player.Instance.Name} с Мемом влетают внутрь авто. Galant со свистом колес стартует с места. На него сыплется град выстрелов.");

			if (player.dresMoney == 2)
			{
				Console.WriteLine($"Кузов дырявится, стекла трескаются, но galant уходит с линии огня и пускается прочь. За ним следом несутся бронированные БРТы, galant не может оторваться.\n{Player.Instance.Name}: Никогда не думал, что БТРы могут быть такими быстрыми.\nDre: Это не обычные БТР, а патрульные. Не знаю как ты им насолил, но они решили взяться за тебя всерьез.\nОдин из БТРов влетает в зад galant'у, багажник всмятку.\nDre: Бл*, *ука *баная...\nБТРы открывают огонь из пулеметов. Dre крутит баранку. Galant виляет по дороге пытаясь избежать попаданий, но не выходит. Dre делает смертельный маневр. Он таранит ограждение эстакады и слетает на нижнюю скрещивающуюся трассу. Тут же делает дрифт разворот на 180° и уносится в обратном направлении. БТРы спрыгивая вслед теряют galant из вида. Когда вояки понимают что произошло, столпотворение БТРов просто не может нормально разъехаться, чтобы развернуться. Galant уже далеко.\n{Player.Instance.Name}: Все кончено?\nDre: Еще нет, смотри.\nДорогу перекрыла колонна танков, они открывают огонь. Dre бешенным маневром вылетает с трассы на бездорожье. Вслед за galant'ом летят два бомбардировщика, они скидывают сотни бомб уничтожая все на своем пути. Dre не знает куда деться, он ищет варианты. Бомбардировщики уже сверху, все вкруг начинает взрываться, galant'у отрывает двери, в последний момент Dre влетает в ж/д тоннель.\n{Player.Instance.Name}: Спаслись?\nDre: Неет.\nВ лобовую на galant несется локомотив. Dre врубает заднюю и пытается выехать из тоннеля. Galant выезжает, Dre выруливает, но локомотив цепляет морду galant'а, авто закручивается, отрывается бампер и капот. Ж/д полотно разрушено после бомбежки. Поезд слетает в рельс. Задние вагоны налетают на передние. Вагоны встают дыбом как иголки у ежика. Страшное зрелище, Dre медленно уезжает прочь.\n");
			}
			if (player.dresMoney > 2)
			{
				Console.WriteLine($"Броня Quadra galant'а слишком прочна, пули словно резиновые отскакивают от кузова. Quadra galant уносится с линии огня, но за ним вслед стартуют БРТы, Quadra конечно не на максимальной скорости, но БТРы не отстают.\n{Player.Instance.Name}: Никогда не думал, что БТРы могут быть такими быстрыми.\nDre: Это не обычные БТР, а патрульные, у них ракетные двигатели. Но мы легко можем оторваться, просто я на обкатке движка, не хочу давать высокие обороты.\n{Player.Instance.Name}: А, ну тогда ладно.\nБТРы открывают огонь из пулеметов. Dre врубает боевой режим.\nУ Quadra galant два пулемета спереди и два сзади. Dre отвечает БТРам огнем. Калибр у пулеметов Quadr'ы значительно больше, чем у БТРов. Броня БТРов как фольга начинает превращаться в труху. Вскоре от преследователей не остается и следа. Но рано радоваться, дорогу преградила колонна танков и они открывают встречный огонь. Dre жмет на газ, неужели он решил протаранить танки? Раздается хлопок, galant подлетает вверх. Прыжковые заряды, тут и такое есть. Капитан Шепард бы обзавидовался. Quadra galant пролетает над танками, приземляется с другой стороны и уносится вданъль. Но на встречу galant'у летят два бомбардировщика, они скидывают сотни бомб уничтожая все на своем пути.\nDre: Подключайся через личный порт к гаубице на крыше.\n{Player.Instance.Name}: А это безопасно напрямую по личному порту?\nDre: Ну точно безопаснее чем встретиться с ковровой бомбардировкой.\n{Player.Instance.Name}: Лады.\n{Player.Instance.Name} берет под контроль многоствольную гаубицу на крыше galant'а и открывает огонь. Один бомбардировщик виляет в сторону, но слишком поздно, у него загораются двигатели правого крыла и он идет на снижение. Теперь весь шквал гаубицы сосредоточен на оставшемся самолете. Ему не повезло среагировать. Как взорвавшаяся дсп, самолет разносит в щепки. Quadra galant выезжает на пустошь образовавшуюся после бомбежки и уносится прочь.\n");
			}
		}

		private void FightWithPolice(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} больше самому себе чем окружающим: Гребанные менты, а еще этот вирус, я совсем ослаб, они в любой момент могут открыть огонь, что же делать?\n");

			if (player.kojimaNumber)
			{
				Console.WriteLine($"{Player.Instance.Name}: У меня же есть номер Кодзимы!!!\n{Player.Instance.Name} сует руку в карман, но там ничего нет, ни визитки, ни мего крутого телефона {Player.Instance.Name}а. По видимому все осталось в ДелиМерсе, вод же облом. Придется выкручиваться самому.");
			}

			Console.WriteLine($"{Player.Instance.Name} не растерялся, достал ПЗРК и шмальнул в ментов. БАБАХ!!! Горящие остовы автомобилей разлетаются в стороны, офигевшие менты замешкали. {Player.Instance.Name} пользуется моментом и начинает кулаками выкашивать ментов одного за другим. Через минуту в руках {Player.Instance.Name}а уже красуются два пистолета, которые он подобрал от поверженных врагов. Прыжки {Player.Instance.Name}а по крутизне сопоставимы с прыжками Макс Пейна. Последним на землю падает Мойор Либовски от удара рукоятью пистолета по лбу. Он так и не успел понять, что происходит.");
		}

		private void Jail(Player player)
		{
			Console.WriteLine($"Рядом материализуется СильверГрэг он явно сильно устал.\nСильверГрэг: Я разобрался с вирусом, но тебя опять угораздило встрять в неприятности?\n{Player.Instance.Name}: А я то в чем виноват?\nСильверГрэг: В том то и дело, что и обвинить то некого, вот меня это и бесит. Послушай, ты слишком ослаб, бой может плохо кончится. Думаю на придется сдаться.\n{Player.Instance.Name} некоторое время думал, он мог дать бой ментам, но при этом мог пострадать Мем. По итогу {Player.Instance.Name} согласился, поднял руки и вышел вперед, оставляя Мема позади.\nСильверГрэг: Не переживай, я в любом случае с тобой.\nНа встречу {Player.Instance.Name}у выходит майор Либовски, майор надевает наручники и пакует {Player.Instance.Name}а в автозак. Машина уезжает в горизонт, прямиком в тюрьму, но это не конец для {Player.Instance.Name}а, ведь с ним СильверГрэг, а вместе, эти двоя найдут выход из любой ситуации. Даже из тюрьмы arkham asylum. Но это уже совсем другая история.\nКонец.\n");

			player.endGame = true;
		}

		private void EasyChase(Player player)
		{
			if (player.dresMoney == 1)
			{
				Console.WriteLine($"С пердежом и дребезжанием на сцену врывается ржавый galant Dre.");
			}
			if (player.dresMoney == 2)
			{
				Console.WriteLine($"С ревом мотора на сцену врывается mitsubishi galant 8 в офигительном состоянии, за рулем Dre.");
			}
			if (player.dresMoney > 2)
			{
				Console.WriteLine($"Земля содрогнулась, раздался оглушительный рев и на полном ходу вылетает тюнингованный Quadra galant Turbo Type-8, за рулем Dre.");
			}

			Console.WriteLine($"Galant останавливается между {Player.Instance.Name}ом и ментами, открывается дверь.\nDre кричит: Запрыгивайте.\n{Player.Instance.Name} с Мемом влетают внутрь авто. Galant со свистом колес стартует с места. За ним в погоню устремляется колонна ментовских тачек.");

			if (player.dresMoney == 1)
			{
				Console.WriteLine($"Ржавый galant едва вытягивает столь высокую скорость. Ментовские тачки настигают и начинают бортовать galant. Две особо настырные ментовские тачки решают сдавить galant с двух сторон. Гнилой кузов не выдержит такого трюка. Dre бьет по тормозам и ментовские тачки влетают друг в друга. Dre начинает крутить баранку как бешенных, лишь бы не цепануть летящие сзади автомобили. Galant как игрушечный волчок метается по всей ширине дороги. Пока менты пытаются развернуться, galant уже петляет на узких улочках, заметая следы.\n");
			}
			if (player.dresMoney == 2)
			{
				Console.WriteLine($"Mitsubishi galant 8 несется на полном ходу. Рядовым ментовским тачкам не поспеть за резвым стоковым турбированым движком galant'а. Основная масса авто все удаляется и удаляется. Дистанция ростет. Но и у ментов нашлось две шустрые тачки. Они решают сжать galant с двух сторон. Однако Dre не намерен ждать, он тут же бортует правую тачки вытесняя ее с дороги, где она встречается в лобовом поцелуе со столбом. Dre сбавляет скорость и берет в лево, удар приходится на правое заднее колесо ментовской тачки, она закручивается и вылетает с дороги.\n{Player.Instance.Name}: Ментовскими приемами против ментов?\nDre: Клин клином вышибают.\nGalant устремляется в даль, оставляя позади все невзгоды.");
			}
			if (player.dresMoney > 2)
			{
				Console.WriteLine($"Dre даже не нажимает педаль газа в пол. Quadra galant летит как реактивный самолет. Dre смотрит в зеркала: оооо, пара ментов пытаются нас догнать...\nС равнодушием на лице Dre медленно уводит Quadra galant с трассы на бездорожье. Минута и galant летит по бездорожью на той же скорости. Подвеска мягко съедает все неровности. По ощущению в салоне разницы между трассой и бездорожьем никакой. Тем временем, ментовские тачки остановились на обочине, не рискуя выезжать на бездорожье. Легкая катка.");
			}
		}

		private void BestEnd(Player player)
		{
			Console.WriteLine($"Рядом материализуется встрепанный СильверГрэг, борясь с отдышкой он говорит: Хорошие новости, я разъебал вирус, жить будешь.\n{Player.Instance.Name}: Спасибо, СильверГрэг, ты все таки офигенный парень, и чувство юмора у тебя офигенное.\nСильверГрэг: Такое же офигенное, как суспензия под яйца?\n{Player.Instance.Name}: Ладно, иногда твой юмор просто отвратителен.\nОни оба засмеялись.\nМем: Па, с кем ты разговариваешь?\n{Player.Instance.Name}: Ох, это долгая история становления дружбы, Мем.\nДорогу нашей троице преграждает мотоцикл. Мотоциклист снимает шлем и это ни кто иной как Лиза.\nЛиза: {Player.Instance.Name}, Я...\nСильверГрэг: ...блоко\n{Player.Instance.Name} и СильверГрэг весело смеются.\nЛиза: Я хотела сказать...\n{Player.Instance.Name}: Не нужно слов, и так все ясно, пошли с нами.\n");

			if (player.dresMoney > 0)
			{
				Console.Write("К мотоциклу подъезжает ");

				if (player.dresMoney == 1)
				{
					Console.Write("раздолбанный ржавый mitsubishi galant 8.");
				}
				if (player.dresMoney == 2)
				{
					Console.Write("mitsubishi galant 8 отличного состояния, сверкает как новый.");
				}
				if (player.dresMoney > 2)
				{
					Console.Write("тюнингованный Quadra galant Turbo Type-8.");
				}

				Console.Write($" Водительская дверь открывается и высовывается Dre, в руках у него гантелив.\nDre: Работаем Пацаны!!\nСильверГрэг: Дре в своем репертуаре.\nDre: А поехали хавать хинкали.");

				if (!player.Am)
				{
					Console.WriteLine(" Я заплачу за всех.");
				}
				else
				{
					Console.WriteLine(" Платит Амир.\nНа встречу galant'у выезжает SAAB Ама. Довольный Ам вылазит из тачки. Все его руки измазаны в Крахмале.\nАм: Хинкали это збс, одобряю.");
				}

				if (player.kojimaNumber)
				{
					Console.WriteLine($"И вроде бы все отлично, но {Player.Instance.Name}у кажется, что кого-то не хватает. И в этот момент подъезжает ДелиМерс, из окна радостно машет рукой Кодзима. Во второй руке у него телефон {Player.Instance.Name}а.\n{Player.Instance.Name}: Блин, вот где я оставил свой телефон.\nКодзима: Что-то кричи на Японском про хинкали, он тоже в деле.");
				}

				Console.WriteLine($"Колонна машин несется по трассе, довольные друзья весело переговариваются.\nСильверГрэг: Если мне не понравятся хинкали, вернете мне деньги.\nDre: Да ты даже не платишь...");
			}

			Console.WriteLine("Конец!!");
			player.endGame = true;
		}

		private static void SilverGregAddition(Player player)
		{
			if (player.SilverGreg)
			{
				Console.WriteLine($"Больно, но прикольно, - подумал {Player.Instance.Name}. Боль больше походила на внутренний зуд, который нельзя почесать, а откуда-то изнутри доносились крики СильверГрэга: Получай пизды, роботизированная-тварь! Технологии корпоратов ничто, против рока! Это тебе за Трилыча!!\nСильверГрэг знал свое дело, в противостоянии технологии корпов он был лучший. ");
			}
			else
			{
				Console.WriteLine($"Боль была невыносимой. Вытаскивая Мема, {Player.Instance.Name} чуть не потерял сознание. Чтобы набраться сил, ему пришлось еще минуту сидеть и глубоко дышать. Дела плохи. ");

				if (player.kojimaNumber)
				{
					Console.WriteLine($"{Player.Instance.Name} засовывает руку в карман. Не повезло, номер Кодзимы остался в ДелиМерсе вместе с мобилой {Player.Instance.Name}а. Есть только немного обезбола. ");
				}
			}
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			if (player.pitAnswer.Count == 0)
				IsVisible = false;
			else
				IsVisible = true;
		}
	}

	internal class ThirdActionPitPoint : ThirdAction
	{
		public override string ActionDescription => "Крахмальный убегает!!";

        public ThirdActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = "Томми Крахмальный-Шелби взбегает по лестнице и скрывается. Он продолжит свои злодеяния где-то в другом месте.";
			NextPointID = 33;

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionPitPoint : SecondAction
	{
		public override string ActionDescription => "Подать руку Мему.";

        public SecondActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} накланяется и протягивает руку Мему. В этот момент сзади подкрадывается Томми Крахмальный-Шелби и вкалывает в спину {Player.Instance.Name}а огромный шприц с вирусными нано роботами. Роботы начинают изнутри разрушать все системы и органы. {Player.Instance.Name} от боли катается по полу. Крахмальный-Шелби убегает.\n";

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);

			if (player.SilverGreg)
			{
				Console.WriteLine($"СильверГрэг: Держись!! Я возьму весь удар нано-роботов на себя!! А ты сосредоточься на спасении Мема!!\n");
			}
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionPitPoint : FirstAction
	{
		public override string ActionDescription => "Мем, ты в порядке?";

        public FirstActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Мем: Все в порядке, Па, я так рад, что ты меня нашел. Какое ужасное место, что здесь было раньше?\n{Player.Instance.Name}: В этом подвали школьников учили стрелять, разбирать автоматы, снаряжать магазины, надевать противогазы...\nМем: Здесь детей готовили к войне?\n{Player.Instance.Name}: Можно и так сказать.\nМем: Какое страшное место.\n{Player.Instance.Name}: Хватит разговоров, пора вытаскивать тебя отсюда.\n";

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);

			if (!player.SilverGreg)
				return;

			Console.WriteLine($"СильвеГрэг спрыгивает в яму и внимательно рассматривает суспензию.\nСильвеГрэг: Хм, знакомый состав, помниться мне в 2012 бомжи вгоняли себе такой состав под...\n{Player.Instance.Name}: Прекрати, ты меня отвлекаешь.\nСильвеГрэг: Будь внимателен, тут подозрительно тихо после взрыва Тутаева, чую опасность.\n");
		}
	}
}
