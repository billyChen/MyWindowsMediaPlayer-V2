using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MyWindowsMediaPlayer
{
    public partial class MediaPlayer : Window
	{
        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (list.ElementAtOrDefault(PlayListPos) != null)
            {
                try
                {
                    String musicName = list[PlayListPos].getUri;
                    nowPlaying.Text = "";
                    nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured: " + error.Message);
                }
            }
            e.CanExecute = (WmPlayer != null) && (WmPlayer.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void PreviousSong(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WmPlayer.Source != null)
                {
                    PlayListPos = PlayListPos - 1;
                    WmPlayer.Source = null;
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                    }
                    else
                    {
                        if (list.ElementAtOrDefault(0) != null)
                        {
                            PlayListPos = 0;
                            WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                            count = 0;
                            foreach (object o in listItems.Items)
                            {
                                if (count == PlayListPos)
                                    listItems.SelectedItem = o;
                                count = count + 1;
                            }
                        }
                        else
                            WmPlayer.Source = null;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void NextSong(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WmPlayer.Source != null)
                {
                    PlayListPos = PlayListPos + 1;
                    WmPlayer.Source = null;
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                    }
                    else
                    {
                        if (list.ElementAtOrDefault(0) != null)
                        {
                            PlayListPos = 0;
                            WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                            count = 0;
                            foreach (object o in listItems.Items)
                            {
                                if (count == PlayListPos)
                                    listItems.SelectedItem = o;
                                count = count + 1;
                            }
                        }
                        else
                            WmPlayer.Source = null;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }
	}
}
