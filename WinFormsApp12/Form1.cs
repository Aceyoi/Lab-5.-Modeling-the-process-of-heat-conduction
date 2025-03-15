using System;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private const int N = 100; // Количество узлов
        private const float Tp = 1.0f; // Температура плавления
        private const float h = 1.0f; // Шаг по пространству
        private const float dt = 0.1f; // Шаг по времени
        private const float k1 = 0.5f; // Увеличенный коэффициент для твердой фазы
        private const float k2 = 1.0f; // Увеличенный коэффициент для жидкой фазы
        private const float q_pl = 10.0f; // Теплота плавления

        private float[] T = new float[N + 2]; // Температура в узлах
        private int phaseBoundary = 1; // Положение границы раздела фаз
        private System.Windows.Forms.Timer timer; // Таймер для анимации
        public Form1()
        {
            InitializeComponent();
            // Инициализация таймера
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; // Интервал обновления анимации (мс)
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Инициализация температуры
            for (int i = 0; i <= N; i++)
            {
                T[i] = i == 0 ? 2.0f : 0.5f; // Левый конец нагрет, остальные точки холодные
            }

            // Запуск таймера
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Обновление температуры в узлах
            for (int i = 1; i < N; i++)
            {
                float k = (T[i] >= Tp) ? k2 : k1; // Выбор коэффициента теплопроводности
                T[i] += k * (T[i + 1] - 2 * T[i] + T[i - 1]) * dt / (h * h);
            }

            // Граничные условия
            T[0] = 2.0f; // Левый конец нагрет
            T[N] = T[N - 1]; // Правый конец теплоизолирован

            // Определение новой границы раздела фаз
            for (int i = 1; i < N; i++)
            {
                if (T[i] >= Tp && T[i + 1] < Tp)
                {
                    phaseBoundary = i;
                    break;
                }
            }

            // Обновление отрисовки
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Отрисовка графика температуры
            Graphics g = e.Graphics;
            Pen tempPen = new Pen(Color.Blue, 2);
            for (int i = 1; i <= N; i++)
            {
                g.DrawLine(tempPen, (i - 1) * 8, 500 - (int)(100 * T[i - 1]), i * 8, 500 - (int)(100 * T[i]));
            }

            // Отрисовка линии границы раздела фаз
            Pen boundaryPen = new Pen(Color.Red, 2);
            g.DrawLine(boundaryPen, phaseBoundary * 8, 0, phaseBoundary * 8, 500);
        }
    }
}
