using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace await_async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_click: Początek");
            Task<long> zadanie = DoSomethingAsync("async/await");
            MessageBox.Show("Akcja została uruchomiona");
            long wynik = await zadanie;
            MessageBox.Show("Wynik: " + wynik);
            MessageBox.Show("button1_click: Koniec");
        }

        Task<long> DoSomethingAsync(object argument) 
        {
            Func<object, long> akcja =
                (object _argument) =>
                {
                    MessageBox.Show("Akcja: Początek, argument: " + _argument.ToString());
                    Thread.Sleep(10000);
                    MessageBox.Show("Akcja: Koniec");
                    return DateTime.Now.Ticks;
                };
            Task<long> zadanie = new Task<long>(akcja, argument);
            zadanie.Start();
            return zadanie;
        }
    }
}
