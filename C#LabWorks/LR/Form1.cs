using System;
using System.Windows.Forms;

namespace LR
{
    public partial class Form1 : Form
    {
        static double dt = 0.01, time = 10, Za = 2.776; // 95%
        public static double x0 = 4, y0 = 1, dx0 = 0, dy0 = 0, dx1 = 0, dy1 = 0;
        static double m = 10, c = 5.19, g = 9.8;
        static double a = -0.1, b = a*-1;
        double[] arrayX = new double[(int) (time / dt)];
        double[] arrayY = new double[(int) (time / dt)];
        double[] arraydX = new double[(int)(time / dt)];
        double[] arraydY = new double[(int)(time / dt)];
        static double[,] noiseX = new double[5, (int)(time / dt)];
        static double[,] noiseY = new double[5, (int)(time / dt)];
        static double[] averageXY = new double[(int)(time / dt)];
        static double[] averageX = new double[(int)(time / dt)];
        static double[] averageY = new double[(int)(time / dt)];
        double[,] noiseXNEW = new double[5, (int)(time / dt)];
        double[,] noiseYNEW = new double[5, (int)(time / dt)];
        static double[] Delta = new double[(int)(time / dt)];


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < time / dt; i++)
            {
                arrayX[i] = x0;
                arrayY[i] = y0;
                arraydX[i] = dx0;
                arraydY[i] = dy0;
                GetCoordinate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            for (int i =0;i<time/dt;i++)
            {
                chart1.Series[0].Points.AddXY(arrayX[i], arrayY[i]);
            }            
        } // XYt

        public void button4_Click_1(object sender, EventArgs e)
        {
            Clear();
        }// Clear 

        private void button2_Click_1(object sender, EventArgs e)  //Xt
        {
            Clear();
            for (int i = 0; i < time/dt; i ++)
            {
                chart1.Series[0].Points.AddXY(i*dt, arrayX[i]);                
            }
        }

        private void button3_Click(object sender, EventArgs e) //Yt
        {
            Clear();
            for (int i = 0; i < time/dt; i ++)
            {
                chart1.Series[0].Points.AddXY(i * dt, arrayY[i] );
            }
        }
        
        Random rnd = new Random();

        private void button6_Click(object sender, EventArgs e) // NoiseX
        {
            Clear();
            for (int j = 0; j < 5; j++)
            {
                double randomValue = 0;
                for (int i = 0; i < time/dt; i ++)
                {
                    //randomValue =rnd.NextDouble() * (b - a) + a;
                    randomValue = randomValue + rnd.NextDouble() * (b - a) + a;

                    noiseX[j,i] = arrayX[i] + randomValue;


                    chart1.Series[j].Points.AddXY(i*dt, noiseX[j, i]);                    
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) // NoiseY
        {
            Clear();
            for (int j = 0; j < 5; j++)
            {
                double randomValue = 0;
                for (int i = 0; i < time / dt; i++)
                {
                    randomValue = randomValue+rnd.NextDouble() * (b - a) + a;
                    noiseY[j, i] = arrayY[i] + randomValue;
                    chart1.Series[j].Points.AddXY(i * dt, noiseY[j, i]);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e) // averageXY+noice
        {
            for (int i = 0; i < time / dt; i++)
            {
                double sumj = 0;
                for (int j = 0; j < 5; j++)
                {
                    sumj = sumj + noiseX[j, i];
                }
                averageXY[i] = sumj / 5;                
            }
            for (int i = 0; i < time / dt; i+=10)
            {
                Console.WriteLine(averageXY[i] + " ");
                chart1.Series[5].Points.AddXY(averageXY[i], arrayY[i]);
            }
            

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < time / dt; i++)
            {
                double sumj = 0;
                for (int j = 0; j < 5; j++)
                {
                    sumj = sumj + noiseX[j, i];
                }
                averageX[i] = sumj / 5;            
                chart1.Series[5].Points.AddXY(i*dt, averageX[i]);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < time / dt; i++)
            {
                double sumj = 0;
                for (int j = 0; j < 5; j++)
                {
                    sumj = sumj + noiseY[j, i];
                }
                averageY[i] = sumj / 5;
                chart1.Series[5].Points.AddXY(i * dt, averageY[i]);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 5; j++)
            {
                x0 = 4;
                y0 = 1;
                dx0 = 0;
                dy0 = 0; dx1 = 0; dy1 = 0;

                for (int i = 0; i < time / dt; i++)
                {
                    x0 = x0 + rnd.NextDouble() * (b - a) + a;
                    y0 = y0 + rnd.NextDouble() * (b - a) + a;
                    // Найдем следующий X
                    var x1 = GetValueEiler(dx0, x0);
                    // Найдем следующий Y
                    var y1 = GetValueEiler(dy0, y0);
                    // Найдем следующие производные
                    var dx1 = GetValueEiler(DDXn(x0, y0, dx0, dy0), dx0);
                    var dy1 = GetValueEiler(DDYn(x0, y0, dx0, dy0), dy0);
                    // Обновим текущие на следующие
                    x0 = x1;
                    y0 = y1;
                    dx0 = dx1;
                    dy0 = dy1;
                }
            }        
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clear();
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < time / dt; i=i+1)
                {
                    Console.WriteLine("T="+i*dt+"| | NoiseXNEW="+ noiseXNEW[j, i]);
                    chart1.Series[j].Points.AddXY(i * dt, (int)noiseXNEW[j, i]);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) // Noise XY
        {
            Clear();
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < time / dt; i++)
                {
                    var randomValue = rnd.NextDouble() * (b/4 - a/4) + a/4;
                    noiseX[j, i] = arrayX[i] + randomValue;
                    randomValue = rnd.NextDouble() * (b / 4 - a / 4) + a / 4;
                    noiseY[j, i] = arrayY[i] + randomValue;
                    chart1.Series[j].Points.AddXY(noiseX[j, i], noiseY[j,i]);
                }
            }
        }

        public void Clear() 
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();
            chart1.Series[6].Points.Clear();
            chart1.Series[7].Points.Clear();
            x0 = 4;
            y0 = 1;
            dx0 = 0;
            dy0 = 0; dx1 = 0; dy1 = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(x0, y0);
            GetCoordinate();
        } // Анимация

        private void button5_Click(object sender, EventArgs e) // Вкл/Выкл таймер
        {
            Clear();
            timer1.Enabled = !timer1.Enabled;
        }

        private void button14_Click(object sender, EventArgs e) //DIX
        {
            var deltaX = GetDeltaX();
            for (int i = 0; i < time/dt; i++)
            {
                chart1.Series[6].Points.AddXY(i * dt, averageX[i] + deltaX);
            }
            for (int i = 0; i < time/dt; i++)
            {
                chart1.Series[7].Points.AddXY(i * dt, averageX[i] - deltaX);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var deltaY = GetDeltaY();
            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[6].Points.AddXY(i * dt, averageY[i] + deltaY);
            }
            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[7].Points.AddXY(i * dt, averageY[i] - deltaY);
            }
        }

        public Form1()
        {
            InitializeComponent();        
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Дельта икс
            var Za = 2.776; // Квантиль распределения
            var N = 5;
            double sumJ = 0;
            for (int i = 0; i < time/dt; i++)
            {
                double sumI = 0;
                for (int j = 0; j < 5; j++)
                {
                    sumI = sumI + (noiseX[j, i] - averageX[i]) * (noiseX[j, i] - averageX[i]);
                    Console.WriteLine("sumI " + sumI);
                }
                double sigma = 1.0 / (N) * sumI;
                sigma = Math.Sqrt(sigma);
                Console.WriteLine("sigma " + sigma);
                var delta = sigma / Math.Sqrt(N) * Za;
                Console.WriteLine("delta " + delta);
                Delta[i] = delta;
            }
            

            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[6].Points.AddXY(i * dt, averageX[i] + Delta[i]);
            }
            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[7].Points.AddXY(i * dt, averageX[i] - Delta[i]);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Дельта икс
            var N = 5;
            for (int i = 0; i < time / dt; i++)
            {
                double sumI = 0;
                for (int j = 0; j < 5; j++)
                {
                    sumI = sumI + (noiseY[j, i] - averageY[i]) * (noiseY[j, i] - averageY[i]);
                    Console.WriteLine("sumI " + sumI);
                }
                double sigma = 1.0 / (N) * sumI;
                sigma = Math.Sqrt(sigma);
                Console.WriteLine("sigma " + sigma);
                var delta = sigma / Math.Sqrt(N) * Za;
                Console.WriteLine("delta " + delta);
                Delta[i] = delta;
            }
            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[6].Points.AddXY(i * dt, averageY[i] + Delta[i]);
            }
            for (int i = 0; i < time / dt; i++)
            {
                chart1.Series[7].Points.AddXY(i * dt, averageY[i] - Delta[i]);
            }
        }

        //Численные методы решения системы ОДУ. Метод Эйлера.

        // x с 2 точками
        public static double DDXn(double x0, double y0, double dx0, double dy)
        {
            var DDXn = ((c * x0 * dx0 - 2 * c * x0 * dy0 - 2 * c * dx0 * y0 + 8 * c * y0 * dy0 - m * dx0 * dx0 + 4 * m * dx0 * dy0
                - 8 * m * dy0 * dy0 - 4 * c * dy0 - 2 * m*g * x0 + 8 * m*g * y0 - 4 * m*g) * (x0 - 2 * y0) / (5 * x0 * x0 
                - 36 * x0 * y0 + 68 * y0 * y0 + 16 * x0 - 64 * y0 + 16) - c * dx0) / m;
            return DDXn;
        }

        // y с 2 точками
        public static double DDYn(double x0, double y0, double dx0, double dy0)
        {
            var DDYn = ((c * x0 * dx0 - 2 * c * x0 * dy0 - 2 * c * dx0 * y0 + 8 * c * y0 * dy0 - m * dx0 * dx0 + 4 * m * dx0 * dy0 -
                8 * m * dy0 * dy0 - 4 * c * dy0 - 2 * m * g * x0 + 8 * m * g * y0 - 4 * m * g) * (8 * y0 - 2 * x0 - 4) / (5 * x0 * x0 - 36 * x0 * y0
                + 68 * y0 * y0 + 16 * x0 - 64 * y0 + 16) - m * g - c * dy0) / m;
            return DDYn;
        }

        public static double GetValueEiler(double dValue0, double Value0)
        {
            return dValue0*dt+Value0;
        }

        public static void GetCoordinate()
        {
            // Найдем следующий X
            var x1 = GetValueEiler(dx0, x0);
            // Найдем следующий Y
            var y1 = GetValueEiler(dy0, y0);
            // Найдем следующие производные
            var dx1 = GetValueEiler(DDXn(x0, y0,dx0, dy0), dx0);
            var dy1 = GetValueEiler(DDYn(x0, y0, dx0, dy0), dy0);
            // Обновим текущие на следующие
            x0 = x1;
            y0 = y1;
            dx0 = dx1; 
            dy0 = dy1;
        }

        public static double GetDeltaX()
        {
            //var Za = 2.776; // Квантиль распределения
            var N = 5;
            var delta = SigmaX(N) / Math.Sqrt(N) * Za;
            Console.WriteLine("DeltaX=" + delta);
            return delta;
        }
        
        public static double SigmaX(double N)
        {
            double sumI = 0;
            //Найдемм sum((xi-xaverage)^2)
            for (int i = 0; i < time / dt; i++)
            {
                sumI = sumI + DeltaSigmaXY(noiseX[0, i], averageXY[i]);
            }
            double sigma = sumI / 1;
            return Math.Sqrt(sigma);
        }

        public static double DeltaSigmaXY(double xi, double xaverag)
        {
            var delta = (xi- xaverag) * (xi - xaverag);
            return delta;
        }

        public static double GetDeltaY()
        {
            var N = 5;
            var delta = SigmaY(N) / Math.Sqrt(N) * Za;
            return delta;
        }

        public static double SigmaY(int N)
        {
            double sumJ = 0;
            for (int j = 0; j < 5; j++)
            {
                double sumI = 0;
                for (int i = 0; i < time / dt; i++)
                {
                    sumI = sumI + (noiseY[j, i] - averageY[i]) * (noiseY[j, i] - averageY[i]);
                }
                sumJ = sumJ + sumI;
            }
            double sigma = 1 / N * sumJ;
            return sigma;
        }
    }        
}
