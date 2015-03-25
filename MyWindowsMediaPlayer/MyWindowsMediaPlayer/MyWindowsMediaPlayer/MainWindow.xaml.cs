using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;

namespace MyWindowsMediaPlayer
{
    public partial class MediaPlayer : Window
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        private int numberItems = 0;
        private int PlayListPos = 0;
        private int themePos = 1;
        private bool isFullscreen = false;
        private int count = 0;
        private List<Media> list = new List<Media>();
        List<String> ressourceName;
        List<String> ressourceButton;
        List<String> ressourceSecondaryButton;
        List<String> ressourceLastButton;
        List<String> ressourceTB;

        private bool ValidateMediaItem(string data)
        {
            string extension;
            bool isValid = false;

            try
            {
                extension = data.Substring(data.LastIndexOf("."));
                foreach (string value in Media.allTypes)
                {
                    if (value.Equals(extension, StringComparison.CurrentCultureIgnoreCase))
                        isValid = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return (isValid);
        }

        public MediaPlayer()
        {
            ressourceName = new List<String>();
            ressourceButton = new List<String>();
            ressourceSecondaryButton = new List<String>();
            ressourceLastButton = new List<String>();
            ressourceTB = new List<String>();

            ressourceLastButton.Add("controlLastButtonTemplate");
            ressourceLastButton.Add("controlLastButtonTemplateTheme1");
            ressourceLastButton.Add("controlLastButtonTemplateTheme2");
            ressourceLastButton.Add("controlLastButtonTemplateTheme3");

            ressourceSecondaryButton.Add("controlButtonSecondaryTemplate");
            ressourceSecondaryButton.Add("controlButtonSecondaryTemplateTheme1");
            ressourceSecondaryButton.Add("controlButtonSecondaryTemplateTheme2");
            ressourceSecondaryButton.Add("controlButtonSecondaryTemplateTheme3");

            ressourceButton.Add("controlButtonTemplate");
            ressourceButton.Add("controlButtonTemplateTheme1");
            ressourceButton.Add("controlButtonTemplateTheme2");
            ressourceButton.Add("controlButtonTemplateTheme3");

            ressourceName.Add("MainTheme");
            ressourceName.Add("Theme1");
            ressourceName.Add("Theme2");
            ressourceName.Add("Theme3");

            ressourceTB.Add("MainThemeTB");
            ressourceTB.Add("Theme1TB");
            ressourceTB.Add("Theme2TB");
            ressourceTB.Add("Theme3TB");
            
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if ((WmPlayer.Source != null) && (WmPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
                {
                    sliProgress.Minimum = 0;
                    sliProgress.Maximum = WmPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    sliProgress.Value = WmPlayer.Position.TotalSeconds;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void mediaEnd(object sender, RoutedEventArgs e)
        {
            try
            {
                if (list.ElementAtOrDefault(PlayListPos + 1) != null)
                {
                    PlayListPos = PlayListPos + 1;
                    WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                    count = 0;
                    foreach (object o in listItems.Items)
                    {
                        if (count == PlayListPos)
                            listItems.SelectedItem = o;
                        count = count + 1;
                    }
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        String musicName = list[PlayListPos].getUri;
                        nowPlaying.Text = "";
                        nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                    }
                }
                else
                {
                    PlayListPos = 0;
                    if (list.ElementAtOrDefault(0) != null)
                    {
                        WmPlayer.Source = new Uri(list[0].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                        if (list.ElementAtOrDefault(PlayListPos) != null)
                        {
                            String musicName = list[PlayListPos].getUri;
                            nowPlaying.Text = "";
                            nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                        }
                    }
                    else
                        WmPlayer.Source = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }
    }
}