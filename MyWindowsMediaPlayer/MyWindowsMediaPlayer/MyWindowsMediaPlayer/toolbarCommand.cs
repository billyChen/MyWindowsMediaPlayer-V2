﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Controls;

namespace MyWindowsMediaPlayer
{
    public partial class MediaPlayer : Window
    {
        private void clearList(object sender, RoutedEventArgs e)
        {
            listItems.Items.Clear();
            list.Clear();
            WmPlayer.Source = null;
            WmPlayer.Stop();
            mediaPlayerIsPlaying = false;
            listItems.Items.Add(new Media("Drag Item Here"));
            nowPlaying.Text = "";
            PlayListPos = 0;
            numberItems = 0;
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename;
            string filenameSub;

            try
            {
                openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    filename = openFileDialog.FileName;
                    filenameSub = filename.Substring(filename.LastIndexOf(@"\") + 1);
                    if (numberItems == 0)
                        listItems.Items.Clear();
                    numberItems = numberItems + 1;
                    listItems.Items.Add(new Media(filename));
                    list.Add(new Media(@filename));
                    if (WmPlayer.Source == null)
                    {
                        WmPlayer.Source = new Uri(list[0].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                    }
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        String musicName = list[PlayListPos].getUri;
                        nowPlaying.Text = "";
                        nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void ResizeScreen(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11 && isFullscreen == true)
            {
                this.MinWidth = 840;
                this.MinHeight = 500;
                this.Height = 500;
                this.Width = 840;
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.Topmost = false;
                isFullscreen = false;
            }
        }

        private void fullScreen(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.MinWidth = System.Windows.SystemParameters.PrimaryScreenWidth + 10;
            this.MinHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.WindowState = WindowState.Maximized;
            this.Topmost = true;
            isFullscreen = true;
        }

        private void changeThemes(object sender, RoutedEventArgs e)
        {
            Style s;
            Style tb;
            ControlTemplate buttonT;
            ControlTemplate SButtonT;
            ControlTemplate LButtonT;
            
            s = new Style();
            tb = new Style();
            buttonT = new ControlTemplate();
            SButtonT = new ControlTemplate();
            LButtonT = new ControlTemplate();
            try
            {
                s = this.FindResource(ressourceName[themePos]) as Style;
                tb = this.FindResource(ressourceTB[themePos]) as Style;
                buttonT = this.FindResource(ressourceButton[themePos]) as ControlTemplate;
                SButtonT = this.FindResource(ressourceSecondaryButton[themePos]) as ControlTemplate;
                LButtonT = this.FindResource(ressourceLastButton[themePos]) as ControlTemplate;

                mainTb.Style = tb;
                bottomStackPanel.Style = s;
                PlayButton.Template = buttonT;
                StopButton.Template = SButtonT;
                PauseButton.Template = SButtonT;
                NextSongButton.Template = LButtonT;
                PreviousSongButton.Template = LButtonT;
                themePos = themePos + 1;
                if (themePos == ressourceName.Count)
                    themePos = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("An error occured: " + err.Message);
            }
        }

    }
}
