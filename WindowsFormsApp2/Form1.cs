using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Системная информация";
            label1.ForeColor = Color.Blue;
            label2.Text = "Укажите диск:";
            label3.Text = "Задайте маску поиска :";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] aboba = System.Environment.GetLogicalDrives();
            foreach (string disk in aboba)
                listBox1.Items.Add(disk);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.DriveInfo drvive = new System.IO.DriveInfo(textBox1.Text);
                listBox1.Items.Clear();
                listBox1.Items.Add("Диск: " + drvive.Name);
                if (drvive.IsReady)
                {
                    listBox1.Items.Add("Тип диска: " + drvive.DriveType.ToString());
                    listBox1.Items.Add("Файловая система: " + drvive.DriveFormat.ToString());
                    listBox1.Items.Add($"Свободного места: {drvive.TotalFreeSpace / Math.Pow(1024, 3)} gb".ToString());
                }
            }
            catch { MessageBox.Show("Укажите диск"); }
        }

        public string disk;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            disk = textBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string[] astrFolders = System.IO.Directory.GetDirectories(disk);
                foreach (string folder in astrFolders)
                    listBox1.Items.Add(folder);
            }
            catch { MessageBox.Show("Укажите диск"); }
        }
 
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
              string  disk = textBox1.Text;
              string papka = textBox2.Text;

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(disk);

                System.IO.DirectoryInfo[] folders = di.GetDirectories();
                foreach (System.IO.DirectoryInfo maskdirs in folders)
                {
                    if (maskdirs.Name.Contains(papka))
                    {
                        listBox1.Items.Add(maskdirs);
                    }
                }
                }
            catch { MessageBox.Show("Укажите диск и  или маску"); }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                ManagementObjectSearcher gpu = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject obj in gpu.Get())
                {
                    listBox1.Items.Add("информация о марке видеоадаптера: " + obj["Name"].ToString());
                    listBox1.Items.Add("объеме памяти : " + obj["AdapterRAM"].ToString());
                    listBox1.Items.Add("версии драйвера : " + obj["DriverVersion"].ToString());
                    listBox1.Items.Add("названии : " + obj["Caption"].ToString());
                    listBox1.Items.Add("описании : " + obj["Description"].ToString());
                    listBox1.Items.Add("марке видеопроцессора : " + obj["VideoProcessor"].ToString());
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Ошибка получения данных " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                ManagementObjectSearcher gpu = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject obj in gpu.Get())
                {
                    listBox1.Items.Add("информация о идентификаторе : " + obj["DeviceID"].ToString());
                    listBox1.Items.Add("информация о типе интерфейса : " + obj["InterfaceType"].ToString());
                    listBox1.Items.Add("информация о производителе : " + obj["Manufacturer"].ToString());
                    listBox1.Items.Add("информация о модели : " + obj["Model"].ToString());
                    listBox1.Items.Add("информация о серийном номере : " + obj["SerialNumber"].ToString());
                    listBox1.Items.Add("информация о объеме (в байтах) : " + obj["Size"].ToString());
                    listBox1.Items.Add("информация о марке  : " + obj["Caption"].ToString());
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Ошибка получения данных " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                ManagementObjectSearcher baseBoard = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject obj in baseBoard.Get())
                {
                    listBox1.Items.Add("информация о производителе материнской платы: " + obj["Manufacturer"].ToString());
                    listBox1.Items.Add("информация о модели материнской платы: " + obj["Product"].ToString());
                    listBox1.Items.Add("информация о серийном номере материнской платы: " + obj["SerialNumber"].ToString());
                    listBox1.Items.Add("информация о версии материнской платы: " + obj["Version"].ToString());
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("Ошибка получения данных " + ex.Message);
            }
        }
    }
    }
