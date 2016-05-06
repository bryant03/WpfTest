using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.IO;

namespace WpfTest
{

    public partial class MainWindow : Window
    {
        private int CurrentLeft;     //当前
        public DataTable dataTable2, dataTable;  //dataTable2为直接表现层，dataTable为后台的数据提供层
        private int[] a;
        private List<int> list;     //记录dataTable2中选中的行
        public Student stu;         //一个学生对象
        private BitmapImage imageTemp1;
        SQLiteConnection con;
        SQLiteConnectionStringBuilder constr;
        private int current;  //当前选项卡所指的值
        private string[] str;
        private SQLiteCommand cmd;
        private int[] ve;
        private int aa;
        Boolean[] HaveBeenChanged;
        public MainWindow()
        {
            InitializeComponent();
            HaveBeenChanged = new Boolean [500];
            str = new string[101];
            current = 1;
            imageTemp1 = new BitmapImage(new Uri("src\\bg.png", UriKind.Relative));
            image1.ImageSource = imageTemp1;
            BitmapImage imageTemp3 = new BitmapImage(new Uri("/source/2.jpg", UriKind.Relative));
            image3.Source = imageTemp3;
            BitmapImage imageTemp4 = new BitmapImage(new Uri("/source/3.jpg", UriKind.Relative));
            image4.Source = imageTemp4;
            BitmapImage imageTemp5 = new BitmapImage(new Uri("/source/4.jpg", UriKind.Relative));
            image5.Source = imageTemp5;
            BitmapImage imageTemp6 = new BitmapImage(new Uri("/source/5.jpg", UriKind.Relative));
            image6.Source = imageTemp6;

            ve = new int[300];
            aa = 0;

            stu = new Student();
            this.ShowMessage.DataContext = stu;

            CurrentLeft = 0;

            //que = new List<int>();
            list = new List<int>();
            a = new int[1000];
            string sql;
            con = new SQLiteConnection();
            constr = new SQLiteConnectionStringBuilder();
            constr.DataSource = "src/data.db";
            con.ConnectionString = constr.ToString();
            con.Open();
            sql = "SELECT * FROM student;";
            cmd = new SQLiteCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            SQLiteDataReader reader = cmd.ExecuteReader();
            dataTable = new DataTable();

            if (reader.HasRows)
            {
                dataTable.Load(reader);
            }
            DataColumn dc = new DataColumn("check", Type.GetType("System.Boolean"));
            dataTable.Columns.Add(dc);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                aa++;
                ve[i + 1] = i;
                list.Add(i);
                dataTable.Rows[i]["check"] = true;
            }
            dataTable2 = dataTable.Copy();
            this.listView1.ItemsSource = dataTable2.DefaultView;

            //con.Close();
            //reader.Close();
        }
        //滑轮
        private void stackPanel1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            stackPanel1.Focus();
            //SendKeys.Send(e.Delta.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            CurrentLeft = 0;
            dataTable2.Clear();
            dataTable2 = dataTable.Copy();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            list.Clear();
            CurrentLeft = 1;
            //this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '1'");
            for (int i = 0; i < dr.Count(); i++) {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 2;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '2'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 3;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '3'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 4;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '4'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 5;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '5'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 6;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '6'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 7;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '7'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 8;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '8'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 9;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '9'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 10;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '10'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 11;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '11'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 12;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '12'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            CurrentLeft = 13;
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '13'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            DataRow[] dr = dataTable.Select("CollageId = '15'");
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++) list.Add(i);

        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                dataTable2.Rows[i]["check"] = true;
                list.Add(i);
            }
        }

        private void All_Unchecked(object sender, RoutedEventArgs e)
        {
            list.Clear();
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                dataTable2.Rows[i]["check"] = false;
            }
            //sh.Sex = "d";
        }

        private void PrintWord(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("确认要打印这个文档吗","提醒");

            if (list.Count == 1) {
                string ss = MessageBox.Show("确定要打印这份文件么", "提醒", MessageBoxButton.OKCancel).ToString();
                if (ss == "OK")
                {
                    //MessageBox.Show(ss);
                    Print pri = new Print();

                    string[] s = new string[20];
                    for (int i = 1; i <= 15; i++)
                    {
                        if (dataTable2.Rows[list[0]]["a" + i.ToString()].ToString().Length > 0)
                        {
                            s[10] += dataTable2.Rows[list[0]]["a" + i.ToString()].ToString();
                            s[10] += '\n';
                        }
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        if (dataTable2.Rows[list[0]]["b" + i.ToString()].ToString().Length > 0)
                        {
                            s[11] += dataTable2.Rows[list[0]]["b" + i.ToString()].ToString();
                        }
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        if (dataTable2.Rows[list[0]]["c" + i.ToString()].ToString().Length > 0)
                        {
                            s[12] += dataTable2.Rows[list[0]]["c" + i.ToString()].ToString();
                        }
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        if (dataTable2.Rows[list[0]]["d" + i.ToString()].ToString().Length > 0)
                        {
                            s[13] += dataTable2.Rows[list[0]]["d" + i.ToString()].ToString();
                        }
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        if (dataTable2.Rows[list[0]]["e" + i.ToString()].ToString().Length > 0)
                        {
                            s[14] += dataTable2.Rows[list[0]]["e" + i.ToString()].ToString();
                        }
                    }
                    s[4] = stu.Collage;
                    s[5] = stu.Grade;
                    s[6] = stu.Major;
                    s[1] = stu.Name;
                    s[3] = stu.Birthday;
                    s[2] = stu.Sex;
                    s[7] = stu.StudentId;
                    s[8] = stu.Phone;
                    s[9] = stu.IdCard;

                    try
                    {
                        pri.AddDocModel();
                        pri.AddDocModel2(s);
                        MessageBox.Show("打印完成");
                    }
                    catch (Exception ee) {
                        MessageBox.Show(ee.ToString());
                    };
                }
            }
            else MessageBox.Show("您这次选中的学生只能是一个，请重新选择");

            //foreach (DataColumn column in dataTable2.Columns)
            //{
            //    if (i == 9) break;
            //    pri.InsertText(s[i] ,dataTable2.Rows[0][column.ColumnName].ToString());
            //    i++;
            //}
        }

        public void cl()
        {
            stu.Collage = null;
            stu.Grade = null;
            stu.Major = null;
            stu.Name = null;
            stu.Sex = null;
            stu.StudentId = null;
            stu.IdCard = null;
            stu.Phone = null;
            stu.Polity = null;
            stu.Birthday = null;

        }
        private void Single_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (dataTable2.Rows[list[i]]["check"].ToString() == false.ToString())
                {
                    list.Remove(list[i]);  //将这一项从链表中移出
                }
            }
            if (list.Count == 1)
            {
                stu.Collage = dataTable2.Rows[list[0]]["Collage"].ToString();
                stu.Grade = dataTable2.Rows[list[0]]["Grade"].ToString();
                stu.Major = dataTable2.Rows[list[0]]["Major"].ToString();
                stu.Name = dataTable2.Rows[list[0]]["Name"].ToString();
                stu.Birthday = dataTable2.Rows[list[0]]["Birthday"].ToString();
                stu.Sex = dataTable2.Rows[list[0]]["Sex"].ToString();
                stu.StudentId = dataTable2.Rows[list[0]]["StudentId"].ToString();
                stu.Phone = dataTable2.Rows[list[0]]["Phone"].ToString();
                stu.IdCard = dataTable2.Rows[list[0]]["IdCard"].ToString();
                stu.Polity = dataTable2.Rows[list[0]]["Polity"].ToString();
            }
            else cl();

        }


        private void Single_Checked(object sender, RoutedEventArgs e)
        {
            int j;
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                if (dataTable2.Rows[i]["check"].ToString() == false.ToString()) continue;
                for (j = 0; j < list.Count; j++)
                {
                    if (list[j].ToString() == i.ToString()) break;
                }
                if (j == list.Count)
                {
                    list.Add(i);
                }
            }
            if (list.Count == 1)
            {
                stu.Collage = dataTable2.Rows[list[0]]["Collage"].ToString();
                stu.Grade = dataTable2.Rows[list[0]]["Grade"].ToString();
                stu.Major = dataTable2.Rows[list[0]]["Major"].ToString();
                stu.Name = dataTable2.Rows[list[0]]["Name"].ToString();
                stu.Birthday = dataTable2.Rows[list[0]]["Birthday"].ToString();
                stu.Sex = dataTable2.Rows[list[0]]["Sex"].ToString();
                stu.StudentId = dataTable2.Rows[list[0]]["StudentId"].ToString();
                stu.Phone = dataTable2.Rows[list[0]]["Phone"].ToString();
                stu.IdCard = dataTable2.Rows[list[0]]["IdCard"].ToString();
                stu.Polity = dataTable2.Rows[list[0]]["Polity"].ToString();
            }
            else cl();
        }

        //在表现层进行课程的修改
        private void SAVE(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定要保存这些修改到缓存么", "提醒", MessageBoxButton.OKCancel).ToString() == "OK".ToString())
            {
                //MessageBox.Show(list[0].ToString());
                int out1;
                string s = "ABCDE";
                if (t1.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "1"] = t1.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "1"] = t1.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }
                if (t2.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "2"] = t2.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "2"] = t2.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t3.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "3"] = t3.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "3"] = t3.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t4.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "4"] = t4.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "4"] = t4.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t5.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "5"] = t5.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "5"] = t5.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t6.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "6"] = t6.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "6"] = t6.Text;
                        HaveBeenChanged[out1] = true;
                    }

                }

                if (t7.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "7"] = t7.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "7"] = t7.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t8.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "8"] = t8.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "8"] = t8.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t9.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "9"] = t9.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "9"] = t9.Text;
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t10.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "10"] = t10.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "10"] = t10.Text;

                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t11.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "11"] = t11.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "11"] = t11.Text;
                        //que.Add(out1);
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t12.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "12"] = t12.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "12"] = t12.Text;
                        //que.Add(out1);
                        HaveBeenChanged[out1] = true;
                    }
                }

                if (t13.Text.Length != 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);
                        dataTable2.Rows[list[i]][s[current - 1] + "13"] = t13.Text;
                        dataTable.Rows[out1 - 1][s[current - 1] + "13"] = t13.Text;
                        //que.Add(out1);
                        HaveBeenChanged[out1] = true;
                    }
                }

                MessageBox.Show("本次共修改:  " + list.Count.ToString());

                MessageBox.Show("保存成功", "提醒");
                //MessageBox.Show(current.ToString());
                t1.Text = "";
                t2.Text = "";
                t3.Text = "";
                t4.Text = "";
                t5.Text = "";
                t6.Text = "";
                t7.Text = "";
                t8.Text = "";
                t9.Text = "";
                t10.Text = "";
                t11.Text = "";
                t12.Text = "";
                t13.Text = "";
            }
        }

        private void StackPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            current = 1;

        }
        private void StackPanel_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            current = 2;
        }
        private void StackPanel_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            current = 3;
        }

        private void StackPanel_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            current = 4;
        }

        private void StackPanel_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            current = 5;
        }




        //保存到数据库
        private void SaveToDatabase(object sender, RoutedEventArgs e)
        {
            //if(MessageBox.Show("sure？",""))
            string sql = "UPDATE student SET ";
            string tmp;
            
            for (int i=1;i<=300;i++)
            {
                
                if (HaveBeenChanged[i] == false) continue;
                HaveBeenChanged[i] = false;
                DataRow[] dr = dataTable.Select("Id = '" + i.ToString() + "'");
                if (dr.Count() == 0) continue;
                tmp = sql;
                int count = 0;
                Boolean f = false;
                foreach (DataColumn column in dataTable.Columns)
                {
                    count++;
                    if (count <= 23) continue;
                    if (count >= 120) continue;
                    
                    if (dr[0][column].ToString().Length != 0)
                    {
                        if (f) tmp += " , ";
                        f = true;
                        tmp += column.ColumnName + " = ' " + dr[0][column] + "'  ";
                    }
                    //if (count < 119) tmp += " , ";
                }
                tmp += "WHERE Id = " + i.ToString() + ";";
                this.cmd.CommandText = tmp;
                this.cmd.ExecuteNonQuery();
                //MessageBox.Show(tmp);
            }
            MessageBox.Show("保存完成");  
        }
        //删除学生信息
        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定要删除么", "提醒", MessageBoxButton.OKCancel).ToString() == "OK".ToString())
            {
                list.Sort();
                for (int i = list.Count-1; i >=0; i--)
                {
                    string sql = "delete from  student where  id ='" +dataTable2.Rows[list[i]]["Id"].ToString()+"';";
                    //int.TryParse(dataTable2.Rows[list[i]]["Id"].ToString(), out out1);  //删除应该删除的Id
                    //que.Remove( out1);
                    this.cmd.CommandText = sql;
                    this.cmd.ExecuteNonQuery();
                    dataTable.Rows.RemoveAt(list[i]);
                    dataTable2.Rows.RemoveAt(list[i]);

                }
                list.Clear();
                cl();
                for (int i = 0; i < dataTable2.Rows.Count; i++) dataTable2.Rows[i]["check"] = false;
                MessageBox.Show("删除完成");
            }
        }
        private void ComboBoxItemLeft1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("选择了第一批");
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            string sql;
            if (CurrentLeft != 0)
            {
                sql = "CollageId = '" + CurrentLeft.ToString() + " ' and Batch = '第一批'";
            }
            else sql= "Batch = '第一批'";
            DataRow[] dr = dataTable.Select(sql);
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
        }
        private void ComboBoxItemLeft2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("选择了第二批");
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            string sql;
            if (CurrentLeft != 0)
            {
                sql = "CollageId = '" + CurrentLeft.ToString() + " ' and Batch = '第二批'";
            }
            else sql = "Batch = '第二批'";
            DataRow[] dr = dataTable.Select(sql);
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }

        }
        private void ComboBoxItemLeft3(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("选择了第三批");
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            string sql;
            if (CurrentLeft != 0)
            {
                sql = "CollageId = '" + CurrentLeft.ToString() + " ' and Batch = '第三批'";
            }
            else sql = "Batch = '第三批'";
            DataRow[] dr = dataTable.Select(sql);
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
        }
       
        private void ComboBoxItemLeft4(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("选择了第四批");
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            string sql;
            if (CurrentLeft != 0)
            {
                sql = "CollageId = '" + CurrentLeft.ToString() + " ' and Batch = '第四批'";
            }
            else sql = "Batch = '第四批'";
            DataRow[] dr = dataTable.Select(sql);
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }

        }


        private void ComboBoxItemLeft5(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("选择了第五批");
            list.Clear();
            this.listView1.ItemsSource = dataTable2.DefaultView;
            dataTable2.Clear();
            string sql;
            if (CurrentLeft != 0)
            {
                sql = "CollageId = '" + CurrentLeft.ToString() + " ' and Batch = '第五批'";
            }
            else sql = "Batch = '第五批'";
            DataRow[] dr = dataTable.Select(sql);
            for (int i = 0; i < dr.Count(); i++)
            {
                DataRow ddr = dataTable2.NewRow();
                foreach (DataColumn column in dataTable2.Columns)
                {
                    ddr[column.ColumnName] = dr[i][column.ColumnName];
                }
                dataTable2.Rows.Add(ddr);
            }
        }

        public void ucDepartmentView()
        {
            InitializeComponent();
            this.PreviewMouseWheel += new MouseWheelEventHandler(ucDepartmentView_PreviewMouseWheel);
        }

        public void ucDepartmentView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer viewer = scrollViewer1;  //scrollview 为Scrollview的名字，在Xaml文件中定义。
            if (viewer == null)
                return;
            double num = Math.Abs((int)(e.Delta / 2));
            double offset = 0.0;
            if (e.Delta > 0)
            {
                offset = Math.Max((double)0.0, (double)(viewer.VerticalOffset - num));
            }
            else
            {
                offset = Math.Min(viewer.ScrollableHeight, viewer.VerticalOffset + num);
            }
            if (offset != viewer.VerticalOffset)
            {
                viewer.ScrollToVerticalOffset(offset);
                e.Handled = true;
            }
        }
    }
}




