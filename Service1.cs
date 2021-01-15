using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amandapplication
{
    public partial class Service1 : ServiceBase {
               
        public Service1() {
            InitializeComponent();
        }

        public static string GenerateKey(int length) {
            StringBuilder key = new StringBuilder();
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rnd = new byte[1];
            int i = 0;
            while (i < length)
            {
                rng.GetBytes(rnd);
                rnd[0] %= 64;
                if (rnd[0] < 62)
                {
                    ++i;
                    key.Append((byte)((rnd[0] <= 9 ? '0' : rnd[0] <= 35 ? 'A' - 10 : 'a' - 36) + rnd[0]));
                }
            }
            return key.ToString();
        }

        protected override void OnStart(string[] args) {
            Timer timer = new Timer(new TimerCallback(DoSomething));
            timer.Change(0L, 60000);
            Console.WriteLine("The application is running now: {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
        }

        private static int fileNo = 1;
        private static readonly string strPath = @"C:\Users\1882316\Documents\Amandev\Key generator\key";
        
        private static void DoSomething(object state) {
            File.WriteAllText(strPath + (fileNo++).ToString() + ".txt", DateTime.Now + " - Key:" + GenerateKey(10));
        }


        protected override void OnStop()
        {
            
        }
    }
}

