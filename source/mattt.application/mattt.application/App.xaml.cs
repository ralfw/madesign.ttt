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
            // Build
            var ui = new Dialog();
            var moves = new Moves();
            var game = new Game();
            var mapper = new Mapper();
            var interactions = new Interactions(moves, game, mapper);

            // Bind
            ui.ResetRequest += interactions.New_game;
            ui.MoveRequest += interactions.Move;
            interactions.OnGameChanged += ui.Display;

            // Run
            interactions.Start();
            ui.Show();
        }
    }
}
