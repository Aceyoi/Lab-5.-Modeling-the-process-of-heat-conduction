using System;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private const int N = 100; // ���������� �����
        private const float Tp = 1.0f; // ����������� ���������
        private const float h = 1.0f; // ��� �� ������������
        private const float dt = 0.1f; // ��� �� �������
        private const float k1 = 0.5f; // ����������� ����������� ��� ������� ����
        private const float k2 = 1.0f; // ����������� ����������� ��� ������ ����
        private const float q_pl = 10.0f; // ������� ���������

        private float[] T = new float[N + 2]; // ����������� � �����
        private int phaseBoundary = 1; // ��������� ������� ������� ���
        private System.Windows.Forms.Timer timer; // ������ ��� ��������
        public Form1()
        {
            InitializeComponent();
            // ������������� �������
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; // �������� ���������� �������� (��)
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ������������� �����������
            for (int i = 0; i <= N; i++)
            {
                T[i] = i == 0 ? 2.0f : 0.5f; // ����� ����� ������, ��������� ����� ��������
            }

            // ������ �������
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // ���������� ����������� � �����
            for (int i = 1; i < N; i++)
            {
                float k = (T[i] >= Tp) ? k2 : k1; // ����� ������������ ����������������
                T[i] += k * (T[i + 1] - 2 * T[i] + T[i - 1]) * dt / (h * h);
            }

            // ��������� �������
            T[0] = 2.0f; // ����� ����� ������
            T[N] = T[N - 1]; // ������ ����� ���������������

            // ����������� ����� ������� ������� ���
            for (int i = 1; i < N; i++)
            {
                if (T[i] >= Tp && T[i + 1] < Tp)
                {
                    phaseBoundary = i;
                    break;
                }
            }

            // ���������� ���������
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // ��������� ������� �����������
            Graphics g = e.Graphics;
            Pen tempPen = new Pen(Color.Blue, 2);
            for (int i = 1; i <= N; i++)
            {
                g.DrawLine(tempPen, (i - 1) * 8, 500 - (int)(100 * T[i - 1]), i * 8, 500 - (int)(100 * T[i]));
            }

            // ��������� ����� ������� ������� ���
            Pen boundaryPen = new Pen(Color.Red, 2);
            g.DrawLine(boundaryPen, phaseBoundary * 8, 0, phaseBoundary * 8, 500);
        }
    }
}
