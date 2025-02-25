﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using Windows.UI.Core;
using TCD.Controls;
using Windows.UI;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Brace
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Highscores : Brace.Common.LayoutAwarePage
    {


        ApplicationDataContainer localSettings;

        public Highscores()
        {
            localSettings = ApplicationData.Current.LocalSettings;
            this.InitializeComponent();   
            loadScores();
        }

        private void loadScores()
        {
            SerializableDictionary<DateTime, int> scores = Utils.HighScoreManager.Scores;

            this.pageTitle.Text = "High Scores: Local";
            this.scoreList.Items.Clear();

            if (scores == null)
            {
                this.scoreList.Items.Add("Error loading scores");
            }

            else if (scores.Count > 0)
            {
                List<KeyValuePair<DateTime, int>> list = scores.ToList();

                list.Sort((firstPair, nextPair) =>
                {
                    return -firstPair.Value.CompareTo(nextPair.Value);
                }
                );

                int i = 1;
                foreach (var item in list)
                {
                    var str = string.Format("{0}:\t{1}\t{2}", i, item.Value, item.Key);
                    this.scoreList.Items.Add(str);
                    i++;
                }
            }

            else
            {
                this.scoreList.Items.Add("No scores yet!");
            }
        }

        private void loadOnlineScores()
        {
            KeyValuePair<int, string>[] scores = Utils.HighScoreManager.OnlineScores;

            this.pageTitle.Text = "High Scores: Global";
            this.scoreList.Items.Clear();

            if (scores == null)
            {
                this.scoreList.Items.Add("Error loading scores");
            }

            else if (scores.Length > 0)
            {
                int i = 1;
                foreach (var item in scores)
                {
                    var str = string.Format("{0}:\t{1}\t{2}", i, item.Key, item.Value);
                    this.scoreList.Items.Add(str);
                    i++;
                }
            }

            else
            {
                this.scoreList.Items.Add("No scores yet!");
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

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainPage parent = this.Parent as MainPage;
            parent.Children.Remove(this);
        }

        private void localButton_Click(object sender, RoutedEventArgs e)
        {
            loadScores();
        }

        private void onlineButton_Click(object sender, RoutedEventArgs e)
        {
            loadOnlineScores();
        }

    
    }
}
