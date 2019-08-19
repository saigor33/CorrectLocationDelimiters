using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplication_skobks
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("введите строку:");
            string str = Console.ReadLine();
            bool status_count = true;

            char[] array_skob = new char[] { '(', ')', '[', ']', '{', '}' };
            //подсчёток открывающихся и закрывающихся скобочек
            int count_open_skob = 0;
            int count_close_skob = 0;
            for (int j = 0; j < array_skob.Length; j += 2)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == array_skob[j])
                        count_open_skob++;
                    if (str[i] == array_skob[j + 1])
                        count_close_skob++;
                }
                //проверяем одинаковое ли кол-во
                if (count_open_skob != count_close_skob)
                {
                    Console.WriteLine("скобок не одинаков кол-во false");
                    status_count = false;
                    break;
                }
                count_open_skob = 0;
                count_close_skob = 0;

            }

            if (status_count)
            {
                //перебираем все открывающиеся скобочки
                for (int i = 0; i < array_skob.Length; i += 2)
                {
                    if (status_count)
                    {
                        char search_skob_close = array_skob[i + 1]; //определение закрывающейся скобочки
                        Console.WriteLine("искомая скобка = " + search_skob_close);
                        int[] position_index_open_skob = new int[str.Length - 1]; //массив местоположения открыв скобок
                        int count_skob = 0;
                        for (int j = 0; j < str.Length; j++)
                        {
                            if (str[j] == array_skob[i]) //если найдена нужная открывающаяся скобка, записываем её положение в массив
                            {
                                position_index_open_skob[count_skob] = j; //записываем индекс
                                count_skob++; //увеличиваем счётчик
                            }
                        }

                        int num_skob = count_skob;
                        //для каждой открывающейся скобки ищем закрывающуюся 
                        while (num_skob > 0)
                        {
                            int count_skob_closed = 0;
                            //перебираем массив, начиная с места открытия+1 и ищем закрывающиеся скобочки
                            for (int j = position_index_open_skob[num_skob - 1]+1; j < str.Length; j++)
                            {
                                if (str[j] == search_skob_close)
                                {
                                    count_skob_closed++;
                                }
                            }
                            //если их больше или равно кол-ву открывающихся скобочек, то продолжаем поиск
                            if (count_skob_closed >= count_skob - num_skob + 1)
                            {
                                Console.WriteLine("скобок больше count_close_skob= " + count_skob_closed + " count_skob= " + count_skob + " num_skob= " + num_skob);
                            }
                            else
                            { //иначе меняем статус на "лож" и выходим из цикла
                                Console.WriteLine("скобок меньше count_close_skob= " + count_skob_closed + " count_skob= " + count_skob + " num_skob= " + num_skob);
                                status_count = false;
                                break;
                            }
                            num_skob--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("плохо -> false. Выход из цикла");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("status_count= " + status_count);
            }

            if (status_count)
                Console.WriteLine("всё верно -> true");
            else
                Console.WriteLine("плохо -> false");

            Console.ReadKey();


        }
    }
}
