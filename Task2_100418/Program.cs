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
            int rooms=0, corridors=0;
            StreamReader str = new StreamReader("INPUT.TXT");
            //Int32.TryParse(str.Read(),out rooms);
            string strin;
            strin = str.ReadLine();
            string[] mass = strin.Split(' ');
            Int32.TryParse(mass[0],out rooms);
            Int32.TryParse(mass[1], out corridors);
            List<First>[] save = new List<First>[rooms+1];
            for (int i = 0; i <= rooms; i++)
            {
                save[i] = new List<First>();
            }
            for (int i = 0; i < corridors; i++)
            {
                mass = str.ReadLine().Split(' ');
                int k;
                Int32.TryParse(mass[0], out k);
                First temp = new First();
                Int32.TryParse(mass[1], out temp.target);
                Int32.TryParse(mass[2], out temp.colour);
                save[k].Add(temp);
                First temp1 = new First();
                int buf = temp.target;
                temp1.target = k;
                temp1.colour = temp.colour;
                save[buf].Add(temp1);
            }
            strin = str.ReadLine();
            int way = Int32.Parse(strin);
            int curpos = 1;
            bool OK = true;
            strin = str.ReadLine();
            mass = strin.Split(' ');
            for (int i = 1; i <= way && OK == true; i++)
            {
                int cor = Int32.Parse(mass[i - 1]);
                OK = false;
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
