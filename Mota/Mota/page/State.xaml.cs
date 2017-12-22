using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mota.page
{
    /// <summary>
    /// 英雄状态栏的page
    /// </summary>
    public partial class State : Page
    {
        private static State instance;

        private State()
        {
            InitializeComponent();
        }
        public static State GetInstance()
        {
            if(instance == null)
            {
                instance = new State();
            }
            return instance;
        }
    }
}
