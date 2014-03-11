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
            uxButton0.Click += uxButton0_Click;
            uxButton1.Click += uxButton1_Click;
            uxButton2.Click += uxButton2_Click;
            uxButton3.Click += uxButton3_Click;
            uxButton4.Click += uxButton4_Click;
            uxButton5.Click += uxButton5_Click;
            uxButton6.Click += uxButton6_Click;
            uxButton8.Click += uxButton7_Click;
            uxButton0.Click += uxButton8_Click;

            uxReset.Click += new RoutedEventHandler( uxReset_Click );

        }

        void uxReset_Click( object sender, RoutedEventArgs e )
        {
            ResetRequest();
        }

        void uxButton0_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate(0);
        }
        void uxButton1_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 1 );
        }
        void uxButton2_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 2 );
        }
        void uxButton3_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 3 );
        }
        void uxButton4_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 4 );
        }
        void uxButton5_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate(5 );
        }
        void uxButton6_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 6 );
        }
        void uxButton7_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 7 );
        }
        void uxButton8_Click( object sender, RoutedEventArgs e )
        {
            SendCoordinate( 8 );
        }

        private void SendCoordinate(int i)
        {
            MoveRequest(i);
        }


        public void Diaplay(GameState gameState)
        {
            uxStatus.Text = gameState.Status;
            uxButton0.Content = gameState.Board[0, 0];
            uxButton1.Content = gameState.Board[0, 1];
            uxButton2.Content = gameState.Board[0, 2];
            
            uxButton3.Content = gameState.Board[1, 0];
            uxButton4.Content = gameState.Board[1, 1];
            uxButton5.Content = gameState.Board[1, 2];

            uxButton6.Content = gameState.Board[2, 0];
            uxButton7.Content = gameState.Board[2, 1];
            uxButton8.Content = gameState.Board[2, 2];
        }



        

        public event Action ResetRequest;
        public event Action<int> MoveRequest;
    }
}
