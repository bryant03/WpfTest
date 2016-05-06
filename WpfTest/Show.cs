using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WpfTest
{
    public class Student : INotifyPropertyChanged
    {
        private string a1;
        private string a2;
        private string a3;
        private string a4;
        private string a5;
        private string a6;
        private string a7;
        private string a8;
        private string a9;
        private string a10;

        //Id text primary key,
        //Collage text,
        //Grade text,
        //Major text,
        //Name text,
        //Sex text,
        //Birthday text,
        //Polity text,
        //IdCard text,
        //StudentId text,
        //Phone text,
        //QQ Text,
        //WeChat Text,
        //Mail text,
        //GPA text,
        //Position text,
        //Credit text,
        //Type text,
        //Constellation text,
        //Address text,
        //Feature text
        public event PropertyChangedEventHandler PropertyChanged;

        //public string CollageId { set; get; }
        //public string Id { set; get; }
        public string Collage {
            get { return a1; }
            set
            {
                a1 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Collage"));
                }
            }
        }

        public string Grade {
            get { return a2; }
            set
            {
                a2 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Grade"));
                }
            }
        }

        public string Major {
            get { return a3; }
            set
            {
                a3 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Major"));
                }
            }
        }
        public string Name
        {
            get { return a4; }
            set
            {
                a4 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Sex
        {
            get { return a5; }
            set
            {
                a5 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sex"));
                }
            }
        }
        public string Birthday
        {
            get { return a6; }
            set
            {
                a6 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Birthday"));
                }
            }
        }
        public string Polity
        {
            get { return a7; }
            set
            {
                a7 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Polity"));
                }
            }
        }
        public string IdCard
        {
            get { return a8; }
            set
            {
                a8 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IdCard"));
                }
            }
        }
        public string StudentId
        {
            get { return a9; }
            set
            {
                a9 = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("StudentId"));
                }
            }
        }
        public string Phone
        {
            get { return a10; }
            set
            {
                a10 =value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Phone"));
                }
            }
        }
        //public string Sex { set; get; }
        //public string Birthday { set; get; }
        //public string Polity { set; get; }
        //public string IdCard { set; get; }
        //public string StudentId { set; get; }
        //public string Phone { set; get; }
        //public string QQ { set; get; }
        //public string WeChat { set; get; }

        //public string Mail { set; get; }

        //public string GPA { set; get; }
        //public string Position { set; get; }
        //public string Credit { set; get; }
        //public string Type { set; get; }

        //public string Constellation { set; get; }
        //public string Address { set; get; }
        //public string Feature { set; get; }
    }
}
