const string title =  "#############################################################################\n" +
                      "#                                                                           #\n" +
                      "#    ###    #####  #####  #####    ###    ###   #####  #####  #      #####  #\n" +
                      "#    #  #   #   #  #      #        #  #   #  #    #      #    #      #      #\n" +
                      "#    #####  #   #  #####  #####    #####  ####    #      #    #      ###    #\n" +
                      "#    #   #  #   #      #      #    #   #  #  #    #      #    #      #      #\n" +
                      "#    #####  #####  #####  #####    #####  #  #    #      #    #####  #####  #\n" +
                      "#                                                                           #\n" +
                      "#############################################################################\n";
const string MenuFight = "1";
const string MenuExit = "2";
const string MenuHeroAttack = "1";
const string MenuHeroFireBall = "2";
const string MenuHeroExplosion= "3";
const string MenuHeroHeal = "4";
const string MessageWinBattle = "Вы победили! Босс повержен!";
const string MessageLooseBattle = "Вы проиграли! Босс победил!";

const int HeroMaxMana = 100;
const int HeroMaxHealth = 10;
const int BossMaxHealth = 50;
const int BossMinimumDamage = 1;
const int BossMaximumDamage = 5;
const int HeroFireBall = 5;
const int HeroExplosion = 15;
const int HeroFireBallMana = 10;
const int HeroExplosionMana = 50;
const int HeroHeal = 5;

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

Console.Title = $"Boss battle";

while (isPlying)
{
    Console.Clear();
    Console.WriteLine(title);
    Console.WriteLine($"{MenuFight}) Бой");
    Console.WriteLine($"{MenuExit}) Выход");

    mainMenu = Console.ReadLine() ?? "";

    switch (mainMenu)
    {
        case MenuFight:
            isFight = true;
            bossHealth = BossMaxHealth;
            heroHealth = HeroMaxHealth;
            heroMana = HeroMaxMana;

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
                Console.WriteLine($"{MenuHeroAttack} Обычная атака");

                if ((heroMana - HeroFireBall) > 0)
                    Console.WriteLine($"{MenuHeroFireBall} Огненный шар");

                if (isUseFireBall)
                    Console.WriteLine($"{MenuHeroExplosion} Взрыв");

                if (healingPoints > 0)
                    Console.WriteLine($"{MenuHeroHeal} Лечение({healingPoints})");

                mainMenu = Console.ReadLine() ?? "";
                heroDamage = 0;
                messageHero = string.Empty;
                messageBoss = string.Empty;

                switch (mainMenu)
                {
                    case MenuHeroAttack:
                        heroDamage = heroRegularAttack;
                        break;

                    case MenuHeroFireBall:
                        if (heroMana > HeroFireBall)
                        {
                            heroDamage = HeroFireBall;
                            heroMana -= HeroFireBallMana;
                            isUseFireBall = true;
                        }
                        break;

                    case MenuHeroExplosion:
                        if (isUseFireBall)
                        {
                            heroDamage = HeroExplosion;
                            heroMana -= HeroExplosionMana;
                            isUseFireBall = false;
                        }
                        break;

                    case MenuHeroHeal:
                        if (healingPoints > 0)
                        {
                            healingPoints--;
                            heroHealth += HeroHeal;
                            heroHealth = heroHealth > HeroMaxHealth ? HeroMaxHealth : heroHealth;
                            heroMana = HeroMaxMana;
                        }
                        break;
                }

                if (heroDamage > 0)
                {
                    bossHealth -= heroDamage;

                    if (bossHealth <= 0)
                    {
                        bossHealth = 0;
                        messageResult = MessageWinBattle;
                        isFight = false;
                    }
                    else
                    {
                        messageHero = $"-{heroDamage}";
                    }
                }
                else
                {
                    messageHero = $"+{HeroHeal}";
                }

                if (isFight)
                {
                    bossDamage = random.Next(BossMinimumDamage, BossMaximumDamage);
                    heroHealth -= bossDamage;

                    if (heroHealth <= 0)
                    {
                        heroHealth = 0;
                        messageResult = MessageLooseBattle;
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

        case MenuExit:
            isPlying = false;
            break;
    }
}
