using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheta
{
    public class SchetVBanke
    {

        private int nom;
        private string name;
        private float sum;
        public List<int> nomera;

        public void choose(int otvet, List<SchetVBanke> scheta)
        {
            switch (otvet)
            {
                case 1:

                    otk(this.nom, this.name, this.sum, scheta);
                    break;
                case 2:
                    output();
                    break;
                case 3:
                    dob(this.sum);
                    break;
                case 4:
                    umen(this.sum);
                    break;
                case 5:
                    obnul();
                    break;


            }


        }
        public void choose(SchetVBanke schet, int chosen)
        {
            switch (chosen)
            {
                case 6:
                    perenos(schet);

                    break;


            }


        }



        private void otk(int nom, string name, float sum, List<SchetVBanke> scheta)
        {

            Console.WriteLine("Введите ФИО: ");
            this.name = Console.ReadLine();
            Console.WriteLine("Введите номер счета: ");
            this.nom = Convert.ToInt32(Console.ReadLine());
            bool checkNom = true;
            int count = 1;
            if (scheta.Count > 1)
            {

                while (count != 0)
                {
                    count = 0;

                    for (int i = 0; i < scheta.Count - 1; i++)
                    {


                        if (this.nom == scheta[i].nom)
                        {
                            count += 1;

                        }

                    }
                    if (count != 0)
                    {
                        Console.WriteLine("Такой номер уже есть. Попробуйте заново, введите новый номер");
                        this.nom = Convert.ToInt32(Console.ReadLine());

                    }

                }

            }


            Console.WriteLine("Введите сумму, которую хотите перевести на счет: ");
            this.sum = Convert.ToInt32(Console.ReadLine());
            if (this.sum < 0)
            {
                Console.WriteLine("Баланс не может быть отрицательным. Баланс 0");
                this.sum = 0;
            }

        }

        private void output()
        {
            Console.WriteLine("Информация о счете: \n Имя, на которое зарегистрирован счет: " + this.name + "\n Номер счета: " + this.nom + "\n Сумма на счету: " + this.sum);

        }

        private void dob(float sum)
        {
            Console.WriteLine("Введите сумму, которую хотите положить на счет: ");
            float top = float.Parse(Console.ReadLine());
            if (top <= 0)
            {
                while (top <= 0)
                {
                    Console.WriteLine("Сумма не может быть отрицательной. Введите положительное число ");
                    top = float.Parse(Console.ReadLine());

                }

            }
            this.sum += top;
            Console.WriteLine("Новая сумма на вашем счету: " + this.sum);

        }



        private void umen(float sum)
        {
            Console.WriteLine("Введите сумму, которую хотите снять со счета: ");
            float umen = float.Parse(Console.ReadLine());
            if (umen > this.sum)
            {
                Console.WriteLine("Вы хотите снять больше, чем имеется. Сняли все, что осталось. Баланс 0");
                this.sum = 0;

            }
            else if (umen <= 0)
            {
                while (umen <= 0)

                {
                    Console.WriteLine("Сумма не может быть отрицательной или нулевой. Введите положительное число ");
                    umen = float.Parse(Console.ReadLine());


                }
                this.sum -= umen;
                Console.WriteLine("Новая сумма на вашем счету: " + this.sum);
            }
            else
            {
                this.sum -= umen;
                Console.WriteLine("Новая сумма на вашем счету: " + this.sum);


            }

        }

        private void obnul()
        {
            this.sum = 0;
            Console.WriteLine("Ваш счет: 0");


        }

        private void perenos(SchetVBanke schet)
        {

            Console.WriteLine("Какую сумму?");
            float summa = float.Parse(Console.ReadLine());
            if (summa > this.sum)
            {

                Console.WriteLine("Сумма превышает баланс");
                schet.sum += this.sum;
                this.sum = 0;
                Console.WriteLine("Новая сумма счета " + this.nom + " = " + this.sum + "\n Новая сумма счета " + schet.nom + " = " + schet.sum);
            }
            else if (this.sum == 0)
            {
                Console.WriteLine("Невозможно перевести какую-либо сумму, т.к. баланс счета 0");

            }
            else if (summa <= 0)
            {

                while (summa <= 0)
                {
                    Console.WriteLine("Сумма не может быть отрицательной или нулевой. Повторите попытку");
                    Console.WriteLine("Какую сумму перевсти?");
                    summa = float.Parse(Console.ReadLine());

                }
                schet.sum += summa;
                this.sum -= summa;
                Console.WriteLine("Новая сумма счета " + this.nom + " = " + this.sum + "\n Новая сумма счета " + schet.nom + " = " + schet.sum);
            }
            else
            {
                schet.sum += summa;
                this.sum -= summa;
                Console.WriteLine("Новая сумма счета " + this.nom + " = " + this.sum + "\n Новая сумма счета " + schet.nom + " = " + schet.sum);

            }



        }





    }
}