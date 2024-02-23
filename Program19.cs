Console.Title = $"Boss battle";

const string title =  "#############################################################################\n" +
                      "#                                                                           #\n" +
                      "#    ###    #####  #####  #####    ###    ###   #####  #####  #      #####  #\n" +
                      "#    #  #   #   #  #      #        #  #   #  #    #      #    #      #      #\n" +
                      "#    #####  #   #  #####  #####    #####  ####    #      #    #      ###    #\n" +
                      "#    #   #  #   #      #      #    #   #  #  #    #      #    #      #      #\n" +
                      "#    #####  #####  #####  #####    #####  #  #    #      #    #####  #####  #\n" +
                      "#                                                                           #\n" +
                      "#############################################################################\n";
const string menuFight = "1";
const string menuExit = "2";
const string menuHeroAttack = "1";
const string menuHeroFireBall = "2";
const string menuHeroExplosion= "3";
const string menuHeroHeal = "4";
const string messageWinBattle = "Вы победили! Босс повержен!";
const string messageLooseBattle = "Вы проиграли! Босс победил!";

const int heroMaxMana = 100;
const int heroMaxHealth = 10;
const int bossMaxHealth = 50;
const int bossMinimumDamage = 1;
const int bossMaximumDamage = 5;
const int heroFireBall = 5;
const int heroExplosion = 15;
const int heroFireBallMana = 10;
const int heroExplosionMana = 50;
const int heroHeal = 5;

Random random = new Random();

int bossDamage=0;
int heroDamage=0;
int bossHealth;
int heroHealth;
int heroMana;
int heroRegularAttack = 1;
int healingPoints = 5;

bool isPlying = true;
bool isFight = true;
bool isUseFireBall = false;

string mainMenu= string.Empty ;
string messageResult= string.Empty ;
string messageHero= string.Empty ;
string messageBoss= string.Empty ;

while (isPlying)
{
    Console.Clear();
    Console.WriteLine(title);
    Console.WriteLine($"{menuFight}) Бой");
    Console.WriteLine($"{menuExit}) Выход");

    mainMenu = Console.ReadLine() ?? "";

    switch (mainMenu)
    {
        case menuFight:
            isFight = true;
            bossHealth = bossMaxHealth;
            heroHealth = heroMaxHealth;
            heroMana = heroMaxMana;

            while (isFight)
            {
                Console.Clear();
                Console.WriteLine(title);

                if (isFight)
                {
                    Console.WriteLine($"Здоровье героя:{heroHealth}\t\t\tЗдоровье босса:{bossHealth}\n" +
                                      $"Мана героя:{heroMana}");

                    if (heroDamage != 0)
                    {
                        Console.WriteLine($"{messageBoss}\t\t\t\t\t\t{messageHero}\n");
                    }
                    else
                    {
                        Console.WriteLine($"{messageHero}{messageBoss}\n");
                    }
                }

                Console.WriteLine($"Выберите атаку:");
                Console.WriteLine($"{menuHeroAttack} Обычная атака");

                if ((heroMana - heroFireBall) > 0)
                    Console.WriteLine($"{menuHeroFireBall} Огненный шар");

                if (isUseFireBall)
                    Console.WriteLine($"{menuHeroExplosion} Взрыв");

                if (healingPoints > 0)
                    Console.WriteLine($"{menuHeroHeal} Лечение({healingPoints})");

                mainMenu = Console.ReadLine() ?? "";
                heroDamage = 0;
                messageHero = string.Empty;
                messageBoss = string.Empty;

                switch (mainMenu)
                {
                    case menuHeroFireBall:
                        if ((heroMana - heroFireBall) > 0)
                        {
                            heroDamage = heroFireBall;
                            heroMana -= heroFireBallMana;
                            isUseFireBall = true;
                        }
                        break;

                    case menuHeroExplosion:
                        if (isUseFireBall)
                        {
                            heroDamage = heroExplosion;
                            heroMana -= heroExplosionMana;
                            isUseFireBall = false;
                        }
                        break;

                    case menuHeroHeal:
                        if (healingPoints > 0)
                        {
                            healingPoints--;
                            heroHealth += heroHeal;
                            heroHealth = heroHealth > heroMaxHealth ? heroMaxHealth : heroHealth;
                            heroMana = heroMaxMana;
                        }
                        break;

                    case menuHeroAttack:
                        heroDamage = heroRegularAttack;
                        break;
                }

                if (heroDamage > 0)
                {
                    bossHealth -= heroDamage;

                    if (bossHealth <= 0)
                    {
                        bossHealth = 0;
                        messageResult = messageWinBattle;
                        isFight = false;
                    }
                    else
                    {
                        messageHero = $"-{heroDamage}";
                    }
                }
                else
                {
                    messageHero = $"+{heroHeal}";
                }

                if (isFight)
                {
                    bossDamage = random.Next(bossMinimumDamage, bossMaximumDamage);
                    heroHealth -= bossDamage;

                    if (heroHealth <= 0)
                    {
                        heroHealth = 0;
                        messageResult = messageLooseBattle;
                        isFight = false;
                    }
                    else
                    {
                        messageBoss = $"-{bossDamage}";
                    }
                }
            }

            Console.WriteLine(messageResult);
            Console.ReadKey();
            break;

        case menuExit:
            isPlying = false;
            break;
    }
}
