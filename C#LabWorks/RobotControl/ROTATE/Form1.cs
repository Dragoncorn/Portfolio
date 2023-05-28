using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;


namespace ROTATE
{




    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen blackPen = new Pen(Color.Black, 3);
            g.DrawPolygon(blackPen, rn);
        }

        
 
        PointF f = new PointF(0, 0);


        PointF[] o = new PointF[] { new PointF(200/4, 200/4), new PointF(300/4, 200/4), new PointF(250/4, 150/4) };
        PointF[] rn = new PointF[] { new PointF(200/4, 200/4), new PointF(300/4, 200/4), new PointF(250/4, 150/4) }; //для хранения новых координат обхекта
        float a=250/4,b=200/4;
        PointF r = new PointF(250/4, 200/4); // точка относительно которой поворачиваем

        int angle = 0;
        double angleRadian = 0;
        double lidar_angleRadian = 0; //переводим угол в радианты
        int angle_lidar = 180;

        int stepangle = 15;
        int step=10;
        int step_lidar = 1;


        float[] mass_light_angle = { };
        float[] mass_light_lenght = {40};

        bool stasuslidar = false;
        bool stasusLeft = false;
        bool stasusRight = false;
        bool stasusForward = false;


       // препятствие 
       int x_ring=200;
       int y_ring=200;
       int diam_ring = 30;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //  ЛИДАР
        {
            stasuslidar = !stasuslidar;
            Draw_All( stasuslidar,  stasusLeft,  stasusRight,  stasusForward);
        }

        public void Draw_lidar(bool stasuslidar)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen blackPen = new Pen(Color.Black, 3);


            if (stasuslidar == false)
            {
                g.Clear(Color.White);
                g.DrawPolygon(blackPen, rn);

            }
            else
            {
                g.Clear(Color.White);
                g.DrawPolygon(blackPen, rn);
                g.DrawEllipse(blackPen, a-20,b-20, 40, 40);
            }

        }

        private void button2_Click(object sender, EventArgs e)  // ВПРАВО
        {
            r = new PointF(a, b); // точка относительно которой поворачиваем
            angle = angle + stepangle; //угол поворота
            angleRadian = angle * Math.PI / 180; //переводим угол в радианты
            a = (float)((a - r.X) * Math.Cos(angleRadian) - (b - r.Y) * Math.Sin(angleRadian) + r.X);
            b = (float)((a - r.X) * Math.Sin(angleRadian) + (b - r.Y) * Math.Cos(angleRadian) + r.Y);
            r = new PointF(a, b); // точка относительно которой поворачиваем
            for (int j = 0; j < o.Length; j++)
            {
                float x = (float)((o[j].X - r.X) * Math.Cos(angleRadian) - (o[j].Y - r.Y) * Math.Sin(angleRadian) + r.X);
                float y = (float)((o[j].X - r.X) * Math.Sin(angleRadian) + (o[j].Y - r.Y) * Math.Cos(angleRadian) + r.Y);
                rn[j] = new PointF(x, y);
            }

            Draw_All(stasuslidar, stasusLeft, stasusRight, stasusForward);
        }
       

        private void button3_Click(object sender, EventArgs e) // Вперед кнопка
        {
            angleRadian = angle * Math.PI / 180; //переводим угол в радианты
            r = new PointF(a, b); // точка относительно которой поворачиваем}

            for (int j = 0; j < rn.Length; j++)
            {
                o[j].Y = o[j].Y - (float)(step * Math.Sin(angleRadian + Math.PI / 2));
                rn[j].Y = rn[j].Y - (float)(step * Math.Sin(angleRadian + Math.PI / 2));
                o[j].X = o[j].X - (float)(step * Math.Cos(angleRadian + Math.PI / 2));
                rn[j].X = rn[j].X - (float)(step * Math.Cos(angleRadian + Math.PI / 2));

            } 

            b= (float) (r.Y - (float)(step * Math.Sin(angleRadian + Math.PI / 2)));
            a= (float) (r.X - (float)(step * Math.Cos(angleRadian + Math.PI / 2)));


            r = new PointF(a, b); // точка относительно которой поворачиваем}


            Draw_All(stasuslidar, stasusLeft, stasusRight, stasusForward);



        }

        
        private void button1_Click(object sender, EventArgs e)   // ВЛЕВО кнопка
        {
            r = new PointF(a, b); // точка относительно которой поворачиваем
            angle = angle - stepangle; //угол поворота
            angleRadian = angle * Math.PI / 180; //переводим угол в радианты

            a = (float)((a - r.X) * Math.Cos(angleRadian) - (b - r.Y) * Math.Sin(angleRadian) + r.X);
            b = (float)((a - r.X) * Math.Sin(angleRadian) + (b - r.Y) * Math.Cos(angleRadian) + r.Y);
            r = new PointF(a, b); // точка относительно которой поворачиваем
            for (int j = 0; j < o.Length; j++)
            {
                float x = (float)((o[j].X - r.X) * Math.Cos(angleRadian) - (o[j].Y - r.Y) * Math.Sin(angleRadian) + r.X);
                float y = (float)((o[j].X - r.X) * Math.Sin(angleRadian) + (o[j].Y - r.Y) * Math.Cos(angleRadian) + r.Y);
                rn[j] = new PointF(x, y);
            }
            Draw_All(stasuslidar, stasusLeft, stasusRight, stasusForward);

        }

        // ОТРИСОВКА ВСЕГО И ВСЯ_____________________________________________________________________________________=======================================================================================
        
        public void Draw_All(bool stasuslidar, bool stasusLeft, bool stasusRight, bool stasusForward)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen blackPen = new Pen(Color.Black, 3);
            Pen redPen = new Pen(Color.Red, 3);
            Pen Pen = new Pen(Color.DarkKhaki, 1);
            Pen LidPen = new Pen(Color.LightPink , 1);


            // Управление лидаром
            if (stasuslidar == false) // лидар выкл Отрисовываем все кроме лучей
            {
                g.Clear(Color.White);
                g.DrawPolygon(blackPen, rn); // РОБОТ
                //g.DrawLine(blackPen, r, f); // Отладочная линия
                //g.DrawEllipse(blackPen, x_ring, y_ring, diam_ring, diam_ring);
                DRAW_RINGS();

            }
            else // Лидар вкл ОТРИСОВЫВАЕМ АБСОЛЮТНО ВСЁ
            {
                g.Clear(Color.White);
                //g.DrawLine(blackPen, r, f);// Отладочная линия


                Lidar_work();


                for (int l = 0; l < 270; l++)
                {

                    g.DrawLine(LidPen, r.X, r.Y, (float)Array_x_lidar_angle[l], (float)Array_y_lidar_angle[l]);

                }

                DRAW_RINGS();
     


                //g.DrawEllipse(blackPen, x_ring, y_ring, diam_ring, diam_ring); 
                g.DrawPolygon(blackPen, rn); // РОБОТ
                g.DrawEllipse(redPen, a - 25, b - 25, 50, 50); //ЛИДАР

                
                

            }


            //g.DrawEllipse(blackPen, x_ring, y_ring, diam_ring, diam_ring);

        }


        //МАСССИВ РАССТОЯНИЙ И угла лидара


        int[] nums = new int[4];

        double[] array_rast = new double[360];
        double[] array_engle = new double[360];
        float x_lidar_angle = 0;
        float y_lidar_angle = 0;
        double rast2ring = 0;
        double dlina_lycha = 0;



        int number_ring = 5;
        int[] Array_ring_X = new int[5];
        int[] Array_ring_Y = new int[5];
        int[] Array_ring_size = new int[5];

        double[] Array_x_lidar_angle = new double[360];
        double[] Array_y_lidar_angle = new double[360];



        private void Acceptbtn_Click(object sender, EventArgs e) // расчет координат препятствий
        {
            number_ring = Convert.ToInt16(textBox1.Text);

            if (number_ring > 1000 || number_ring < 0)
            {
                number_ring = 5;
            }

            //Status_label.Text = number_ring.ToString();

            // Массив случайных значений для кругов

            Random ran = new Random();
           Array_ring_X = new int[number_ring];
           Array_ring_Y = new int[number_ring];
           Array_ring_size = new int[number_ring];

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            g.Clear(Color.White);


            // Получение рандомных кругов _______
            for (int i = 0; i < number_ring; i++)
            {
                Array_ring_X[i] = ran.Next(0, 500);
                Array_ring_Y[i] = ran.Next(0, 400);
                Array_ring_size[i] = ran.Next(40, 50);

                Pen blackPen = new Pen(Color.Black, 3);
                Rectangle rect = new Rectangle(Array_ring_X[i], Array_ring_Y[i], Array_ring_size[i], Array_ring_size[i]);
                // Рисуем круги  
                g.DrawEllipse(blackPen, rect);
               
            }
            Draw_All(stasuslidar, stasusLeft, stasusRight, stasusForward);
        }


        int stas = 0;



        //Обработка лидаром
        public void Lidar_work()
        {
            int z = 0;
            int j = 0;

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen blackPen = new Pen(Color.Black, 3);
            Pen redPen = new Pen(Color.Red, 3);
            Pen Pen = new Pen(Color.DarkKhaki, 1);

   

                for (angle_lidar = 90; angle_lidar < 360; angle_lidar = angle_lidar + step_lidar+0) //ВРАЩАЕМ ЛИДАР    ВЕРНУТЬ     angle_lidar = 90!!!!!!!!!!!
                {
                    double lenghtlidar_lidar = 0.5; //начальная длина лидара 1.3 / макс 3.5

                    lidar_angleRadian = angle_lidar * Math.PI / 180; //переводим угол в радианты
                
                    // УВЕДИЧИВАЕМ ДЛИНУ ЛУЧ ДО МАКСИМУМА ИЛИ ОБЪЕКТА
                                    
                
                    for (lenghtlidar_lidar = 0.5; lenghtlidar_lidar <= 3.5*9; lenghtlidar_lidar = lenghtlidar_lidar + 0.01) //УВЕЛИЧИВАЕМ ДЛИНУ ЛУЧА
                    {
                        //НАХОДИМ Х и У текущей длины луча

                        x_lidar_angle = (float)((o[1].X - r.X) * lenghtlidar_lidar * Math.Cos(lidar_angleRadian + angleRadian + 0.7954) - (o[1].Y - r.Y) * lenghtlidar_lidar * Math.Sin(lidar_angleRadian + angleRadian + 0.7954) + r.X);
                        y_lidar_angle = (float)((o[1].X - r.X) * lenghtlidar_lidar * Math.Sin(lidar_angleRadian + angleRadian + 0.7954) + (o[1].Y - r.Y) * lenghtlidar_lidar * Math.Cos(lidar_angleRadian + angleRadian + 0.7954) + r.Y);


                    Lidar_work_long();
                    if (stas == 1) { break; }



                }

                //Console.Write("["); Console.Write(array_engle[z]); Console.Write("]");
                //Console.Write("["); Console.Write(z); Console.Write("]");

                Array_x_lidar_angle[z] = x_lidar_angle;
                Array_y_lidar_angle[z] = y_lidar_angle;



                //g.DrawLine(Pen, r.X, r.Y, x_lidar_angle, y_lidar_angle);
                z++;
                //Console.Write("["); Console.Write(z); Console.Write("]");
            }
      
            //Console.Write("["); Console.Write(z); Console.Write("]");
        }

        public void Lidar_work_long()
        {

            for (int m = 0; m < number_ring; m++)
            {
                rast2ring = Math.Sqrt(Math.Pow((Array_ring_X[m] + Array_ring_size[m] / 2 - x_lidar_angle), 2) + Math.Pow((Array_ring_Y[m] + Array_ring_size[m] / 2 - y_lidar_angle), 2)); // Растояние от круга до конца луча
                if (rast2ring > Array_ring_size[m] / 2 - 0.3 && rast2ring < Array_ring_size[m] / 2 + 0.3) // сравниваем с радиусом n-го препятсвия
                {

                    dlina_lycha = Math.Sqrt(Math.Pow((r.X + Array_ring_size[m] / 2 - x_lidar_angle), 2) + Math.Pow((r.Y + Array_ring_size[m] / 2 - y_lidar_angle), 2));
                    if (dlina_lycha < 30)
                    { label1.Text = "Столкновение".ToString(); }
                    else { label1.Text = " ".ToString(); }
                    //array_rast[z] = dlina_lycha;
                    stas = 1;
                    break;
                    // break; // прерываем увеличивать длину луча,  после того как нашли препятсвие

                }
                else
                {
                    stas = 0;
                }

            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen redPen = new Pen(Color.Red, 3);


            //Console.Write("["); Console.Write("ОТЛАДКА"); Console.Write("]");
            for (int l = 0; l < 270; l++)
            {

                g.DrawEllipse(redPen,(float) Array_x_lidar_angle[l],(float) Array_y_lidar_angle[l],15,15);

                //Console.Write("["); Console.Write(Array_x_lidar_angle[l]); Console.Write("]");
                //Console.Write("["); Console.Write(Array_y_lidar_angle[l]); Console.Write("]");
            }
            //Console.Write("["); Console.Write("ОТЛАДКА"); Console.Write("]");
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            gg.Clear(Color.Wheat);
            for (int j = 0; j < 269; j++)
            {
                gg.DrawLine(redPen, (float) Array_x_lidar_angle[j], (float)Array_y_lidar_angle[j],(float)Array_x_lidar_angle[j+1], (float)Array_y_lidar_angle[j+1]);


                  //ЧТО ОН ХОТЕЛ
                dlina_lycha = Math.Sqrt(Math.Pow((r.X - Array_x_lidar_angle[j]), 2) + Math.Pow((r.Y  - Array_y_lidar_angle[j]), 2));
                double dlina_lycha2 = Math.Sqrt(Math.Pow((r.X - Array_x_lidar_angle[j+1]), 2) + Math.Pow((r.Y - Array_y_lidar_angle[j+1]), 2));


                //gg.DrawLine(redPen, j, (float) dlina_lycha*(1),j+1, (float) dlina_lycha2*(1));
                

            }

        }

      
            PointF coordinates = new PointF(150, 100); // точка относительно которой поворачиваем
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Console.Write("["); Console.Write("ОТЛАДКА"); Console.Write("]");
            MouseEventArgs me = (MouseEventArgs)e;
             coordinates = me.Location;    // Координаты мышки
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen redPen = new Pen(Color.Red, 3);

            g.DrawEllipse(redPen, coordinates.X, coordinates.Y, 5, 5);
;            
            Console.Write("["); Console.Write(coordinates); Console.Write("]");

        }

        double traectory_eagle = 0;
        double traectory_eagle2 = 0;
        bool statusedem = false;
        bool statusedem2 = false;
        bool statusvpered = false;
        double traectory_eagle_grad = 0;
        private void button5_Click(object sender, EventArgs e)
        {
           
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.OrangeRed, 4);
            Pen blue = new Pen(Color.Blue, 3);
            Pen black = new Pen(Color.Black, 3);
            Pen white = new Pen(Color.White, 3);
            Pen grey = new Pen(Color.Cyan, 3);

         


          
            statusedem = true;

        }
        public void edem() 
        {
           
        }
            int steps = 0;

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.Write("["); Console.Write("ОТЛАДКА"); Console.Write("]");


            if(statusedem==true && count<kk)
            {
                angle = napravlenye[count];

                button1_Click(sender, e);
                step = shagehat[count];
                button3_Click(sender, e);
                count++;

            }
            else
            {
                statusedem = false;
                count = 0;

            }

          


        }

        public void DRAW_RINGS() //рисуем круги
        {

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            for (int i = 0; i < number_ring; i++)
            {

                Pen blackPen = new Pen(Color.Black, 3);
                Rectangle rect = new Rectangle(Array_ring_X[i], Array_ring_Y[i], Array_ring_size[i], Array_ring_size[i]);
                // Рисуем круги  
                g.DrawEllipse(blackPen, rect);
            }

        }



        //-----------------------РЕАЛИЗАЦИЯ ПОИСКА ПУТИ
        //карта 430; 390

        int[] Map_matrix_X = new int[43];    // 
        int[] Map_matrix_Y = new int[39];   //

        int[,] array = new int[4, 2]; // 4 строки 2 столбца

        int[,] map = new int[43, 39];

        
        PointF START = new Point(0, 0); // точка c


        private void button6_Click(object sender, EventArgs e)
        {
            create_map();
            astar();



        }


        // СОЗДАЕМ КАРТУ 43*39
        public void create_map()
        {
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 1);
            int mapx = 0;

            for(int i=0;i<43;i++)
            {
                for(int j=0;j<39;j++)
                {
                    map[i, j] = 0;
                }
            }



             for ( int i =0; i<43;i++)
            {
                Map_matrix_X[i] = mapx;
                mapx = mapx + 10;
                //Console.Write("["); Console.Write(Map_matrix_X[i]); Console.Write("]");
            }
            mapx = 0;
            for (int i = 0; i < 39; i++)
            {
                Map_matrix_Y[i] = mapx;
                mapx = mapx + 10;
                
                //Console.Write("["); Console.Write(Map_matrix_Y[i]); Console.Write("]");
            }

      

            for (int p = 0; p < 270-1; p++)    //точки лидара
            {
                int x =(int) Array_x_lidar_angle[p] / 10;
                int y = (int) Array_y_lidar_angle[p] / 10;
                if(x>=2 && y>=2 && x<=43-3 && y<=39-3)
                {
                    map[x,y]=1;  // НАША ТОЧКА 

                    // ЗОНА ДЛЯ РОБОТА

                    map[  x-1, y-1] = 1;
                    map[  x,   y-1] = 1;
                    map[  x+1, y-1] = 1;

                    map[  x-1, y] = 1;
                    map[  x+1, y] = 1;

                    map[  x-1, y+1] = 1;
                    map[  x,   y+1] = 1;
                    map[  x+1,   y+1] = 1;

                    //--------
                    ///*
                    map[x - 2, y - 2] = 1;
                    map[x, y - 2] = 1;
                    map[x + 2, y - 2] = 1;

                    map[x - 2, y] = 1;
                    map[x + 2, y] = 1;

                    map[x - 2, y + 2] = 1;
                    map[x, y + 2] = 2;
                    map[x + 2, y + 2] = 1;
                    //*/





                    //gg.DrawEllipse(redPen, (int)x*10, (int)y*10, 10, 10);   
                }


                



            }


            // ОТРИСОВКА ПРЕПЯТСВИЙ
            for (int i = 0; i < 43; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    //map[i, j] = 0;
                    //Console.Write("["); Console.Write(map[i,j]); Console.Write("]");
                    if (map[i, j] ==1) {
                        gg.DrawEllipse(redPen, i*10 , j*10 , 10, 10);
                    }
                    else
                    {
                        gg.DrawEllipse(greenPen, i*10, j*10, 10, 10);
                    }
                }
            }

            

        }


        //Алгоритм поиска пути

       // int[] mas = new int[1000];
        PointF[] mas = new PointF[1000] ;

        int finish_x = 0;
        int finish_y = 0;
        int start_x = 0;
        int start_y = 0;

     
        int[,] map_open = new int[3, 3]; // ОТКРЫТЫЙ СПИСОК
        int[,] map_open_total = new int[3, 3]; // растояние до точки
        int[,] map_open_f = new int[3, 3]; // растояния вправо влево и по диагонали
        int[,] map_open_g = new int[3, 3]; // Эвристическое растояние


        int[] open_list_x = new int[8];
        int[] open_list_y = new int[8];
        int[] open_list_status = new int[8];

        int[] open_list_dlinasoseda = { 14, 10, 14, 10, 14, 10, 14, 10 };
        int[] open_list_dlunaevristik = new int[8];
        int[] open_list_totaldlina = new int[8];

        int[] close_list_x = new int[1000];
        int[] close_list_y = new int[1000];
        int[] napravlenye = new int[1000];
        int[] naprlist = { 330,285,240,195,150,105,60,15};
        int[] shagehat = new int[1000];



        int minx = 0;
        int miny = 0;
        Point Activ = new Point(0, 0); //Активная точка


        public void astar()

        {
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.OrangeRed, 4);
            Pen blue = new Pen(Color.Blue, 3);
            Pen black = new Pen(Color.Black, 3);
            Pen white = new Pen(Color.White, 3);
            Pen grey = new Pen(Color.Cyan, 3);


            finish_x = (int) coordinates.X / 10;
            finish_y = (int) coordinates.Y / 10;
            start_x = (int) r.X / 10;
            start_y = (int) r.Y / 10;

            gg.DrawEllipse(blue, finish_x*10, finish_y*10, 10, 10);        // финиш
            gg.DrawEllipse(white, start_x * 10, start_y * 10, 10, 10);    // старт




            Activ = new Point(start_x, start_y); //Активная точка


            kk = 0;

            for (int z=0;z<300;z++)
            {
                funx();
                if(Activ.X==finish_x && Activ.Y==finish_y)
                {
                    break;

                }
            }

       
        }
      
        public void funx()
        {
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.OrangeRed, 4);
            Pen blue = new Pen(Color.Blue, 3);
            Pen black = new Pen(Color.Black, 3);
            Pen white = new Pen(Color.White, 3);
            Pen grey = new Pen(Color.Cyan, 3);

            

            gg.DrawEllipse(grey, Activ.X * 10, Activ.Y * 10, 10, 10);    // Активная точка

     


            //Получаем статус клеток открытого листа

            //координаты открытого списка
            open_list_x[0] = Activ.X - 1;
            open_list_x[1] = Activ.X - 1;
            open_list_x[2] = Activ.X - 1;
            open_list_x[3] = Activ.X;
            open_list_x[4] = Activ.X + 1;
            open_list_x[5] = Activ.X + 1;
            open_list_x[6] = Activ.X + 1;
            open_list_x[7] = Activ.X;

            open_list_y[0] = Activ.Y - 1;
            open_list_y[1] = Activ.Y;
            open_list_y[2] = Activ.Y + 1;
            open_list_y[3] = Activ.Y + 1;
            open_list_y[4] = Activ.Y + 1;
            open_list_y[5] = Activ.Y;
            open_list_y[6] = Activ.Y - 1;
            open_list_y[7] = Activ.Y - 1;


            //отрисовка открытых ячеек
            for (int i = 0; i < 8; i++)
            {
                gg.DrawEllipse(black, open_list_x[i] * 10, open_list_y[i] * 10, 10, 10);
            }


      

            open_list_status[0] = map[Activ.X - 1, Activ.Y - 1];
            open_list_status[1] = map[Activ.X - 1, Activ.Y];
            open_list_status[2] = map[Activ.X - 1, Activ.Y + 1];
            open_list_status[3] = map[Activ.X, Activ.Y + 1];
            open_list_status[4] = map[Activ.X + 1, Activ.Y + 1];
            open_list_status[5] = map[Activ.X + 1, Activ.Y];
            open_list_status[6] = map[Activ.X + 1, Activ.Y - 1];
            open_list_status[7] = map[Activ.X - 1, Activ.Y - 1];


            //ПРОВЕРИТЬ!!!!

            //отрисовка открытых ячеек проходимых синим, не проходимых черным
            for (int i = 0; i < 8; i++)
            {
                if (open_list_status[i] == 0) // Проходима
                {
                    gg.DrawEllipse(blue, open_list_x[i] * 10, open_list_y[i] * 10, 10, 10);

                    // найдем расстояние
                    open_list_dlunaevristik[i] = (Math.Abs(open_list_x[i] - finish_x) + Math.Abs(open_list_y[i] - finish_y)) * 10;

                    open_list_totaldlina[i] = open_list_dlunaevristik[i] + open_list_dlinasoseda[i];

                }
                else     // не проходима
                {
                    gg.DrawEllipse(black, open_list_x[i] * 10, open_list_y[i] * 10, 10, 10);
                    open_list_totaldlina[i] = 1000000;
                }
            }

            // НАЙДЕМ МИНИМАЛЬНОЕ ЗНАЧЕНИЕ В ОТКРЫТОМ СПИСКЕ

            int mindlin = open_list_totaldlina[0];

            for (int i = 0; i < 8; i++)                                                 //отрисовка открытых ячеек проходимых синим, не проходимых черным
            {
                if (mindlin > open_list_totaldlina[i])
                {
                    mindlin = open_list_totaldlina[i];
                    minx = open_list_x[i];
                    miny = open_list_y[i];
                    napravlenye[kk] =naprlist[i];
                    shagehat[kk] = open_list_dlinasoseda[i];


                }

            }

     
            gg.DrawEllipse(grey, (minx) * 10, (miny) * 10, 10, 10);   // точка с наименьшейдлинной

            //close_list_x[0] = Activ.X;
            //close_list_y[0] = Activ.Y;
            closelist();

            Activ.X = minx;
            Activ.Y = miny;


            //Console.Write("["); Console.Write(Activ.X); Console.Write("]");
            //Console.Write("["); Console.Write(Activ.Y); Console.Write("]");

            gg.DrawEllipse(black, (Activ.X) * 10, (Activ.Y) * 10, 10, 10);  // новая активная точка

        }
        int kk = 0;

        private void button7_Click(object sender, EventArgs e)  // map
        {
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.GreenYellow, 4);
            Pen blue = new Pen(Color.Blue, 3);
            Pen black = new Pen(Color.Black, 3);
            Pen white = new Pen(Color.White, 3);
            Pen grey = new Pen(Color.Cyan, 3);

            gg.Clear(Color.White);

            for (int i = 0; i < 43; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    //map[i, j] = 0;
                    //Console.Write("["); Console.Write(map[i,j]); Console.Write("]");
                    if (map[i, j] == 1)
                    {
                        gg.DrawEllipse(white, i * 10, j * 10, 10, 10);
                    }
                    else
                    {
                        gg.DrawEllipse(black, i * 10, j * 10, 10, 10);
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            Graphics gg = Graphics.FromHwnd(pictureBox2.Handle);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                gg.Clear(Color.White);
                       g.Clear(Color.White);

            o = new PointF[] { new PointF(200 / 4, 200 / 4), new PointF(300 / 4, 200 / 4), new PointF(250 / 4, 150 / 4) };
            rn = new PointF[] { new PointF(200 / 4, 200 / 4), new PointF(300 / 4, 200 / 4), new PointF(250 / 4, 150 / 4) }; //для хранения новых координат обхекта
            a = 250 / 4;
            b = 200 / 4;
            PointF r = new PointF(250 / 4, 200 / 4); // точка относительно которой поворачиваем

            angle = 0;
            angleRadian = 0;
            lidar_angleRadian = 0; //переводим угол в радианты
            angle_lidar = 180;

            stepangle = 15;
            step = 10;
            step_lidar = 1;




        }

        public void closelist()
        {


            close_list_x[kk] = Activ.X;
            close_list_y[kk] = Activ.Y;
            map[Activ.X, Activ.Y] = 1;

            
            Console.Write("["); Console.Write(close_list_x[kk]); Console.Write("]");
            Console.Write("["); Console.Write(close_list_y[kk]); Console.Write("]");
                        kk++;
        }




    }

}


