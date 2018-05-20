using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2_100418
{
    class First
    {
        public int target;
        public int colour;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int rooms=0, corridors=0;//Кол-во комнат и коридоров
            StreamReader str = new StreamReader("INPUT.TXT");
            string strin;
            //Считывание из первой строки кол-ва комнат и коридоров
            strin = str.ReadLine();
            string[] mass = strin.Split(' ');
            Int32.TryParse(mass[0],out rooms);
            Int32.TryParse(mass[1], out corridors);
            List<First>[] save = new List<First>[rooms+1];//Лист массивов
            //Инициализация элементов List<First>[] save
            for (int i = 0; i <= rooms; i++)
            {
                save[i] = new List<First>();
            }
            for (int i = 0; i < corridors; i++)
            {
                mass = str.ReadLine().Split(' ');
                int k;
                Int32.TryParse(mass[0], out k);//Номер первой комнаты
                First temp = new First();
                Int32.TryParse(mass[1], out temp.target);//Номер второй комнаты
                Int32.TryParse(mass[2], out temp.colour);//Номер коридора
                save[k].Add(temp);//List[номер первой комнаты].Add(Номер второй комнаты, цвет коридора)
                First temp1 = new First();
                int buf = temp.target;
                temp1.target = k;
                temp1.colour = temp.colour;
                save[buf].Add(temp1);//List[номер второй комнаты].Add(Номер первой комнаты, цвет коридора)
            }
            strin = str.ReadLine();
            int way = Int32.Parse(strin);//Длина описания пути
            int curpos = 1;//Текущая комната (позиция)
            bool OK = true;//Корректность пути
            strin = str.ReadLine();//Считывание пути из последней строки файла
            mass = strin.Split(' ');
            for (int i = 1; i <= way && OK == true; i++)
            {
                int cor = Int32.Parse(mass[i - 1]);//Номер коридора, по которому нужно идти
                OK = false;
                //Поиск и проверка на существования коридора из комнаты с номером curpos
                //При нахождении коридора curpos меняется на номер соотв. комнаты, в которую ведет коридор
                //Если коридора заданного цвета из комнаты с номером curpos нет, но происходит выход из цикла - путь некорректен
                for (int j = 0; j < save[curpos].Count&&OK==false; j++)
                {
                    if (save[curpos][j].colour == cor)
                    {
                        curpos = save[curpos][j].target;
                        OK = true;
                    }
                }
            }
            str.Close();
            StreamWriter stw = new StreamWriter("OUTPUT.TXT");
            if (OK) stw.Write(curpos);
            else stw.Write("INCORRECT");
            stw.Close();
        }
    }
}
