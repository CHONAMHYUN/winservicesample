using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace HypervAgnetService
{
    public partial class HypervAgent : ServiceBase
    {
        private Timer tm = null;

        public HypervAgent()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tm = new Timer();
            this.tm.Interval = 30000;
            this.tm.Elapsed += new System.Timers.ElapsedEventHandler(this.tm_Tick);
            tm.Enabled = true;
            Library.WriteError("Test window service started");
        }

        private void tm_Tick(object sender, ElapsedEventArgs e)
        {
            Library.WriteError("Timer ticked and some job has been done successfully");
        }

        protected override void OnStop()
        {
            tm.Enabled = false;
            Library.WriteError("Test window service stopped");

        }
    }
}
