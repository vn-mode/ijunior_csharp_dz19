using System;

namespace vn_mode_csharp_dz19
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, которые вы можете использовать против Босса.
                Вы должны уничтожить босса и только после этого будет вам покой.

                Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон. У вас есть 4 заклинания для нанесения урона боссу.
                Программа завершается только после смерти босса или смерти пользователя.

                Пример заклинаний

                Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)

                Хуганзакура (Может быть выполнен только после призыва теневого духа), наносит 100 ед. урона

                Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп. Урон босса по вам не проходит

                Заклинания должны иметь схожий характер и быть достаточно сложными, они должны иметь какие-то условия выполнения (пример - Хуганзакура).
                Босс должен иметь возможность убить пользователя.
             */
            Random random = new Random();

            int healthHero = 100;
            int mannaHero = 100;
            int damageSpelHeroKarambula;
            int minimumDamageSpelHeroKarambula = 30;
            int maximumDamageSpelHeroKarambula = 60;
            int priceSpelHeroKarambula = 10;
            string spelHeroKarambulaInfo = "Карамбула - Атака огненным шаром. Стоимость: " + priceSpelHeroKarambula + " манны. (Возможный урон от " + minimumDamageSpelHeroKarambula + " хп до " + maximumDamageSpelHeroKarambula + " хп).";
            int damageSpelHeroKvirta = 100;
            int priceSpelHeroKvirta = 10;
            bool isEnableKvirta = false;
            string spelHeroKvirtaInfo = "Квирта - мощное заклинание. Отнимает " + damageSpelHeroKvirta + " хп у врага. Стоимость " + priceSpelHeroKvirta + " манны (Применяется лишь после заклинания Карамбула).";
            int spelHeroMagicShield;
            int priceSpelHeroMagicShield = 15;
            bool isEnableMagicShield = true;
            string spelHeroMagicShieldInfo = "Магический щит. Немного восстанавливает ваше хп. Урон босса по вам не проходит. Стоимость: " + priceSpelHeroMagicShield + " манны. (Нельзя использовать это заклинание 2 раза подряд)";
            int recoveryHealthHero;
            int minimumRecoveryHealthHero = 10;
            int maximumRecoveryHealthHero = 20;
            int spelRecoveryHeroManna;
            string spelRecoveryHeroMannaInfo = "Каваджо  - заклинание восстановления манны. Можно использовать лишь один раз за игру.";
            int counterSpelRecoveryHeroManna = 1;

            int healthEnemy = 500;
            int damageEnemy;
            int minimumDamageEnemy = 9;
            int maximumDamageEnemy = 25;
            string inputUser = "";

            
            Console.WriteLine("Осталась финальная битва, герой. Сейчас либо ты... либо тебя...");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Внимательно извучи книгу заклинаний, так как враг будет использовать каждую твою оплошность против тебя!");
            Console.ForegroundColor = ConsoleColor.White;

            while (healthHero >= 0 && healthEnemy >= 0)
            {
                damageSpelHeroKarambula = random.Next(minimumDamageSpelHeroKarambula, maximumDamageSpelHeroKarambula);
                damageEnemy = random.Next(minimumDamageEnemy, maximumDamageEnemy);
                recoveryHealthHero = random.Next(minimumRecoveryHealthHero, maximumRecoveryHealthHero);

                Console.WriteLine($"Уровень здоровья героя: {healthHero}\nУроверь манны героя: {mannaHero}");
                Console.WriteLine($"Уровень здоровья врага: {healthEnemy}\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Доступные вам команды:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Для ознакомления с заклинаниями нажмите: ?\nАтаковать врага нажмите: 0");
                inputUser = Console.ReadLine();

                if (inputUser == "?")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ваша книга заклинаний:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(spelHeroKarambulaInfo);
                    Console.WriteLine(spelHeroKvirtaInfo);
                    Console.WriteLine(spelHeroMagicShieldInfo);
                    Console.WriteLine(spelRecoveryHeroMannaInfo + "\n");
                }else if (inputUser == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Выберите заклинание, которое хотите применить:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("заклинание КАРАМБУЛА - нажми: 1");
                    Console.WriteLine("заклинание КВИРТА - нажми: 2");
                    Console.WriteLine("заклинание МАГИЧЕСКИЙ ЩИТ - нажми: 3");
                    Console.WriteLine("заклинание КАВАДЖО - нажми: 4");
                    Console.WriteLine("Посмотреть описание заклинаний - нажми: ?");
                    inputUser = Console.ReadLine();
                    switch (inputUser)
                    {
                        case "1":
                            if(mannaHero >= priceSpelHeroKarambula)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Ты применил заклинание КАРАМБУЛА и нанёс врагу {damageSpelHeroKarambula} урона.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                mannaHero -= priceSpelHeroKarambula;
                                healthEnemy -= damageSpelHeroKarambula;
                                healthHero -= damageEnemy;
                                isEnableKvirta = true;
                                isEnableMagicShield = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("НЕУДАЧА. У тебя недостаточно манны для применения заклинания КАРАМБУЛА.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                healthHero -= damageEnemy;
                            }
                            break;
                        case "2":
                            if (mannaHero >= priceSpelHeroKvirta)
                            {
                                if (isEnableKvirta)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Ты применил заклинание КВИРТА и нанёс врагу {damageSpelHeroKvirta} урона.");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    mannaHero -= priceSpelHeroKvirta;
                                    healthEnemy -= damageSpelHeroKvirta;
                                    healthHero -= damageEnemy;
                                    isEnableKvirta = false;
                                    isEnableMagicShield = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("НЕУДАЧА. Тебе не удалось применить заклинание КВИРТА.");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    healthHero -= damageEnemy;
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("НЕУДАЧА. У тебя недостаточно манны для применения заклинания КВИРТА.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                healthHero -= damageEnemy;
                            }
                            
                            break;
                        case "3":
                            if (mannaHero >= priceSpelHeroMagicShield)
                            {
                                if (isEnableMagicShield)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Ты применил заклинание МАГИЧЕСКИЙ ЩИТ. и поправил свой уровень здоровья на {recoveryHealthHero} хп.");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Враг нанёс тебе 0 урона");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    mannaHero -= priceSpelHeroMagicShield;
                                    healthHero += recoveryHealthHero;
                                    isEnableMagicShield = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("НЕУДАЧА. Тебе не удалось применить заклинание МАГИЧЕСКИЙ ЩИТ.");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    healthHero -= damageEnemy;
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("НЕУДАЧА. У тебя недостаточно манны для применения заклинания МАГИЧЕСКИЙ ЩИТ.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                healthHero -= damageEnemy;
                            }
                            break;
                        case "4":
                            if(counterSpelRecoveryHeroManna == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ты применил заклинание КАВАДЖО и полностью восстановил уровень своей манны.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                mannaHero = 100;
                                healthHero -= damageEnemy;
                                isEnableMagicShield = true;
                                counterSpelRecoveryHeroManna = 0;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("НЕУДАЧА. Тебе не удалось применить заклинание КАВАДЖО.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Враг нанёс тебе {damageEnemy} урона");
                                Console.ForegroundColor = ConsoleColor.White;
                                healthHero -= damageEnemy;
                            }
                            break;
                        case "?":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ваша книга заклинаний:");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(spelHeroKarambulaInfo);
                            Console.WriteLine(spelHeroKvirtaInfo);
                            Console.WriteLine(spelHeroMagicShieldInfo);
                            Console.WriteLine(spelRecoveryHeroMannaInfo + "\n");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели несуществующую команду");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели несуществующую команду");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if(healthHero <= 0 && healthEnemy <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Вы поубивали друг друга. Игра окончена.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (healthHero <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ты умер. Игра окончена.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(healthEnemy <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("ПОБЕДА! Ты сумел одержать верх над своим врагом!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
