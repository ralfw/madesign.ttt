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
using System.Windows.Shapes;
using mattt.data;

namespace mattt.portal
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }
    
        
        public void Diaplay(GameState gameState)
        {
            throw new NotImplementedException();
        }


        public event Action ResetRequest;
        public event Action<int> MoveRequest;
    }
}
