using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using matt.contract;
using mattt.data;

namespace mattt.portal
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        private readonly List<Button> _buttons;

        public Dialog()
        {
            InitializeComponent();

            uxReset.Click += uxReset_Click;

            PlayingField.Columns = Configuration.Instance.Dimension;
            _buttons = new List<Button>();

            for (int i = 0; i < Configuration.Instance.Dimension * Configuration.Instance.Dimension; i++)
            {
                var button = new Button { Tag = i };
                button.Click += ButtonClicked;
                _buttons.Add(button);
                PlayingField.Children.Add(button);
            }
        }

        void uxReset_Click(object sender, RoutedEventArgs e)
        {
            ResetRequest();
            foreach (var button in _buttons)
            {
                button.IsEnabled = true;
            }
        }

        void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var index = Int32.Parse(button.Tag.ToString());
                SendCoordinate(index);
            }
        }


        private void SendCoordinate(int i)
        {
            MoveRequest(i);
        }

        public void Display(GameState gameState)
        {
            uxStatus.Text = gameState.Status;

            for (int y = 0; y < Configuration.Instance.Dimension; y++)
            {
                for (int x = 0; x < Configuration.Instance.Dimension; x++)
                {
                    _buttons[x + y * Configuration.Instance.Dimension].Content = gameState.Board[x, y];
                }
            }

            if (gameState.Status.Contains("gewonnen"))
            {
                // someone won
                foreach (var button in _buttons)
                {
                    button.IsEnabled = false;
                }
            }
        }

        public event Action ResetRequest;
        public event Action<int> MoveRequest;
    }
}
