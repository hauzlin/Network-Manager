﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lib.Forms
{
    public partial class LoadingForm : Form
    {
        /// <summary>
        /// Starts a splash loading form on a new thread running a separate message pump
        /// </summary>
        public LoadingForm(string status)
        {
            InitializeComponent();
            label1.Text = status;
            Thread thread = new Thread(new ThreadStart(Start));
            thread.Start();
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(this);
        }

        public void UpdateStatus(string status)
        {
            while (!IsHandleCreated)
                Thread.Sleep(100);
            Invoke(new Action(() => { label1.Text = status; }));
        }

        public void Stop()
        {
            while (!IsHandleCreated)
                Thread.Sleep(100);
            Invoke(new Action(() => { Close(); }));
        }
    }
}
