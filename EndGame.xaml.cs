﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Brace
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class EndGame : Brace.Common.LayoutAwarePage
    {
        public EndGame()
        {
            this.InitializeComponent();

            this.gameOverScore.Text = string.Format("Final Score: {0}", Utils.HighScoreManager.LastScore.Value);

            if (!Utils.OptionsManager.hasAsked())
            {
                var messageDialog = new MessageDialog("");
                messageDialog.Title = "Do you want to submit your name with your highscore?";
                messageDialog.Content = "We will only ask this once, after this you can turn anonymous high scores on and off in the options menu.";
                messageDialog.Commands.Add(new UICommand(
                    "Yes", (uiCommand) =>
                    {
                        Utils.OptionsManager.SetAnonymous(false);
                    }));
                messageDialog.Commands.Add(new UICommand(
                   "No", (uiCommand) =>
                   {
                       Utils.OptionsManager.SetAnonymous(true);
                   }));
                messageDialog.ShowAsync();

                Utils.OptionsManager.hasAsked(true);
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void gameOverRetry_Click(object sender, RoutedEventArgs e)
        {
            MainPage parent = this.Parent as MainPage;
            parent.Children.Remove(this);
            parent.StartGame();
        }

        private void gameOverMenu_Click(object sender, RoutedEventArgs e)
        {
            MainPage parent = this.Parent as MainPage;
            parent.Children.Add(new MainMenu());
            parent.Children.Remove(this);
        }
    }
}
