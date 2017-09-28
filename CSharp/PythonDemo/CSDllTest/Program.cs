using System;
using System.Collections.Generic;
using System.Text;
namespace CSDllTest
{
    public class TestDll
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class TestDll1
    {
        private int aaa = 11;
        public int AAA
        {
            get { return aaa; }
            set { aaa = value; }
        }
        public void ShowAAA()
        {
            global::System.Windows.Forms.MessageBox.Show(aaa.ToString());
        }

    }
}