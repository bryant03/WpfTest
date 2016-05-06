using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Interop.Word;

namespace WpfTest
{
    class Print
    {
        private Application wordApp = null;
        private Document wordDoc = null;
        public Application Application
        {
            get
            {
                return wordApp;
            }
            set
            {
                wordApp = value;
            }
        }
        public Document Document
        {
            get
            {
                return wordDoc;
            }
            set
            {
                wordDoc = value;
            }
        }

        //通过模板创建新文档
        public void AddDocModel()
        {

            killWinWordProcess();
            wordApp = new ApplicationClass();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            string src = System.IO.Directory.GetCurrentDirectory() + "\\src\\1.doc";
            string srcc = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\学生信息表";
            Console.WriteLine(srcc);
            object missing = System.Reflection.Missing.Value;
            object templateName = srcc;///Application.StartupPath + @"\Report\a";//最终的word文档需要写入的位置
            object ModelName = src; //Application.StartupPath + @"\Report\1.doc";//word模板的位置
            object count = 1;
            object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
            wordDoc = wordApp.Documents.Open(ref ModelName, ref missing, ref missing,
               ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
               ref missing);//打开word模板

            //保存word
            object format = WdSaveFormat.wdFormatDocument;//保存格式 
            wordDoc.SaveAs(ref templateName, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //关闭wordDoc，wordApp对象              
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }

        public void AddDocModel2(string [] str)
        {

           
            string [] s = new string[20];
            for (int i = 1; i <= 14; i++)
            {
                s[i] = "t" + i.ToString();
            }

            killWinWordProcess();
            wordApp = new ApplicationClass();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            string src = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\学生信息表";
            string srcc = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\学生信息表";
            object missing = System.Reflection.Missing.Value;
            object templateName = srcc;///Application.StartupPath + @"\Report\a";//最终的word文档需要写入的位置
            object ModelName = src; //Application.StartupPath + @"\Report\1.doc";//word模板的位置
            object count = 1;
            object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
            wordDoc = wordApp.Documents.Open(ref ModelName, ref missing, ref missing,
               ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
               ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
               ref missing);//打开word模板

            //在书签处插入文字
            for(int i = 1; i <= 14; i++)
            {
                object oStart = s[i];//word中的书签名 
                Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//表格插入位置 
                range.Text = str[i];//在书签处插入文字内容
            }


            //保存word
            object format = WdSaveFormat.wdFormatDocument;//保存格式 
            wordDoc.SaveAs(ref templateName, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //关闭wordDoc，wordApp对象              
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }
        // 杀掉winword.exe进程          
        public void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
}
