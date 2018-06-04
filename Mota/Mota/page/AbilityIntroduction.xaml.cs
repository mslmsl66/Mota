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
    /// AbilityIntroduction.xaml 的交互逻辑
    /// </summary>
    public partial class AbilityIntroduction : Page
    {
        private static AbilityIntroduction instance;
        private AbilityIntroduction()
        {
            InitializeComponent();
        }

        public static AbilityIntroduction GetInstance()
        {
            if (instance == null)
            {
                instance = new AbilityIntroduction();
            }
            return instance;
        }
    }
}
