using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using mattt.game;
using mattt.mapping;
using mattt.moves;
using mattt.portal;

namespace mattt.application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var ui = new Dialog();

            var moves = new Moves();
            var game = new Game();
            var mapper = new Mapper();
            var interactions = new Interactions(moves, game, mapper);

            ui.ResetRequest += () => { };
            ui.MoveRequest += coord => { };
            interactions.OnGameChanged += ui.Diaplay;

            interactions.Start();

            ui.Show();
        }
    }
}
