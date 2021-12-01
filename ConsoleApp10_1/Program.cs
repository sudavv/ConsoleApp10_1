using System;

namespace ConsoleApp3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Program p = new Program();
            Console.WriteLine("Введите градусы, минуты и секунды через пробел");
            string str = Console.ReadLine();
            string[] split = new string[3];
            int gradus = 0;
            int min = 0;
            int sec = 0;
            try
            {
                split = str.Split(' ');
                gradus  = Convert.ToInt32(split[0]);
                min     = Convert.ToInt32(split[1]);
                sec     = Convert.ToInt32(split[2]);
            }
            catch
            {
                Console.WriteLine("Некорректные данные");
                Console.ReadLine();
                Run();
                Environment.Exit(0);
            }

            string log = "";
            if (sec > 59)
            {
                min+= Convert.ToInt32(Math.Floor(sec/ 60d));
                sec = sec % 60;
                log = "Значение секунд ";
            }
            if (min > 59)
            {
                gradus += Convert.ToInt32(Math.Floor(min / 60d));
                min = min % 60;
                if (log != "")
                {
                    log = log + "и минут задано больше 59, пересчитано";
                }
                else
                {
                    log = log + "Значение минут задано больше 59, пересчитано";
                }                
            }
            if (log.Length < 17 & log.Length > 0)
            {
                Console.WriteLine(log + "задано больше 59, пересчитано");
            }
            else
            {
                Console.WriteLine(log);
            }

            Angle angle = new Angle(gradus, min, sec);
            angle.ToRadians();

            Console.ReadLine();
            Run();
            Environment.Exit(0);
        }        
    }

    public class Angle
    {
        public int gradus = 23;
        public int min = 10; // 1/6 Градуса
        public int sec = 30; // 1/120 Градуса

        public Angle(int gradus=1,int min=1,int sec=1)
        {
            this.gradus = gradus;
            this.min = min;
            this.sec = sec; 
        }

        public void ToRadians()
        {
            double rad = (gradus + (min / 60) + (sec / 3600))*(Math.PI/180);
            Console.WriteLine("Градусы: {0}, минуты: {1}, секунды: {2} в радианах: {3}", gradus, min, sec, rad);            
        }
    }

}