using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "системная информация";
            label1.ForeColor =Color.Blue;

            label2.Text = "Список дисков";
            label2.ForeColor = Color.Blue;
        }

                private void button1_Click(object sender, EventArgs e)
        {
            OperatingSystem os = Environment.OSVersion;
            listBox1.Items.Add(os.Version);
            listBox1.Items.Add(os.Platform);
            listBox1.Items.Add(os.ServicePack);
            listBox1.Items.Add(os.VersionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] astrLogicalDrives = System.Environment.GetLogicalDrives();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Выводим информацию о диске
            System.IO.DriveInfo drv = new System.IO.DriveInfo(@"c:\");
            listBox1.Items.Clear();
            listBox1.Items.Add("Диск: " + drv.Name);
            if (drv.IsReady)
            {
                listBox1.Items.Add("Тип диска: " + drv.DriveType.ToString());
                listBox1.Items.Add("Файловая система: " + drv.DriveFormat.ToString());
                listBox1.Items.Add("Свободное место на диске: " + drv.AvailableFreeSpace.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Получаем список папок на диске C:
            listBox1.Items.Clear();
            string[] astrFolders = System.IO.Directory.GetDirectories(@"c:\");
            foreach (string folder in astrFolders)
                listBox1.Items.Add(folder);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Получаем список папок, где встречается буквосочетание "pro"
            listBox1.Items.Clear();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"c:\");
            System.IO.DirectoryInfo[] folders = di.GetDirectories("*pro*");
            foreach (System.IO.DirectoryInfo maskdirs in folders)
                listBox1.Items.Add(maskdirs);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Получаем разрешение экрана
            listBox1.Items.Clear();
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            listBox1.Items.Add("По горизонтали: " + resolution.Width + " пиксесей");
            listBox1.Items.Add("По вертикали: " + resolution.Height + " пиксесей");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Количество процессоров (ядер): " + Environment.ProcessorCount.ToString());

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                //Информация о процессоре
                ManagementObjectSearcher proc = new ManagementObjectSearcher("SELECT * FROM WIN32_Processor");
                foreach (ManagementObject obj in proc.Get())
                {
                    listBox1.Items.Add("Текущая частота: " + obj["CurrentClockSpeed"].ToString());
                    listBox1.Items.Add("Марка: " + obj["Name"].ToString());
                    listBox1.Items.Add("Производитель: " + obj["Manufacturer"].ToString());
                    listBox1.Items.Add("Количество ядер: " + obj["NumberOfCores"].ToString());
                    listBox1.Items.Add("Серийный номер: " + obj["ProcessorId"].ToString());
                    listBox1.Items.Add("Описание: " + obj["Description"].ToString());
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Ошибка получения данных " + ex.Message);
            }

        }
    }
}

