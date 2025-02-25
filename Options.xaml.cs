﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings;
using Windows.UI;
using TCD.Controls;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Brace
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Options : Brace.Common.LayoutAwarePage
    {
        public Options()
        {
            this.InitializeComponent();

            playerNameTextBox.Text = Utils.OptionsManager.GetPlayerName();
            challengeModeToggle.IsOn = Utils.OptionsManager.ChallengeModeEnabled();
            anonymousHighScores.IsOn = Utils.OptionsManager.IsAnonymous();
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

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainPage parent = this.Parent as MainPage;
            parent.Children.Remove(this);
        }

        private void challengeModeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            Utils.OptionsManager.ChallengeModeEnabled(this.challengeModeToggle.IsOn);
        }

        private void playerNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Utils.OptionsManager.SetPlayerName(this.playerNameTextBox.Text);
        }

        private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Utils.OptionsManager.SetVolume((int)e.NewValue);
        }

        private void test(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("this is a test");
        }

        private void legalButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage parent = this.Parent as MainPage;
            parent.Children.Add(new Legal());
        }

        private void anonymousHighScoresToggled(object sender, RoutedEventArgs e)
        {
            if (this.anonymousHighScores != null)
            {
                Utils.OptionsManager.SetAnonymous(this.anonymousHighScores.IsOn);
            }
        }
    }
}
