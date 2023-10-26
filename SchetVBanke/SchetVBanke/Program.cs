using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Scheta;

namespace Scheta
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<SchetVBanke> scheta = new List<SchetVBanke>();

            int otvetSchet = 1;

            int otvetMenu = 1;
            int nomer;
            while (otvetSchet == 0 || otvetSchet == 1)
            {
                Console.WriteLine("Введите 1, чтобы создать новый счет или введите 0, чтобы перейти в меню уже существующего");
                otvetSchet = Convert.ToInt32(Console.ReadLine());

                if (otvetSchet == 1)
                {
                    SchetVBanke schet = new SchetVBanke();
                    scheta.Add(schet);
                    otvetSchet = 0;
                    nomer = scheta.IndexOf(schet) + 1;

                    schet.choose(1, scheta);




                }

                else if (otvetSchet == 0)
                {
                    Console.WriteLine("У вас " + scheta.Count + " счетов ");
                    Console.WriteLine("Введите номер (1, 2...) счета, в меню которого хотите перейти");
                    nomer = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
                bool check2 = false;

                for (int i = 0; i < scheta.Count; i++)
                {
                    if (nomer == i + 1)
                    {
                        check2 = true;
                        otvetMenu = 1;

                        while (otvetMenu >= 1 && otvetMenu < 6)
                        {

                            Console.WriteLine("Меню счета " + (i + 1) + ": \n 1 - показать информацию о счете \n 2 -  положить на счет  \n 3 - снять со счета\n 4 - взять всю сумму  \n 5 - перенести сумму с одного счета на другой " +
                                  " \n 6 - перейти в меню другого счета или создать новый");
                            otvetMenu = Convert.ToInt32(Console.ReadLine());
                            switch (otvetMenu)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    scheta[i].choose(otvetMenu + 1, scheta);
                                    break;
                                case 5:

                                    Console.WriteLine("Введите номер счета (1, 2...), на который хотите перевести сумму с этого");
                                    nomer = Convert.ToInt32(Console.ReadLine());
                                    bool check = false;
                                    for (int j = 0; j < scheta.Count; j++)
                                    {
                                        if (nomer == j + 1 && nomer != (i + 1))
                                        {
                                            check = true;
                                            scheta[i].choose(scheta[j], otvetMenu + 1);
                                            break;

                                        }
                                        else if (nomer == i + 1)
                                        {
                                            check = true;
                                            Console.WriteLine("Вы пытаетесь перевести на тот же счет");
                                            break;
                                        }

                                    }
                                    if (check == false)
                                    {
                                        Console.WriteLine("Такого счета нет");
                                        break;
                                    }
                                    break;
                                case 6:
                                    break;




                            }

                        }

                    }
                    else
                    {
                        continue;
                    }



                }
                if (check2 == false)
                {
                    Console.WriteLine("Такого счета нет");
                }



            }
        }
    }
}