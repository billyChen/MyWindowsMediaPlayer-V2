﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;

namespace MyWindowsMediaPlayer
{
    public partial class MediaPlayer : Window
    {
        private void saveXML(object sender, RoutedEventArgs e)
        {
            if (numberItems > 0)
            {
                try
                {
                    System.Windows.Forms.SaveFileDialog sfd;
                    string name;
                    List<Media> mediaList;
                    FileInfo f;
                    sfd = new System.Windows.Forms.SaveFileDialog();
                    sfd.Filter = "xml (*.xml)|*.xml";
                    if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        name = sfd.FileName;
                        f = new FileInfo(name);
                        if (f.Extension.EndsWith(".xml"))
                        {
                            mediaList = new List<Media>();
                            foreach (Media data in list)
                                mediaList.Add(data);
                            if (xmlClass.CreateXml(name, mediaList))
                            {
                                MessageBox.Show("Sucessfully saved your items");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can only save to xml files", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured: " + error.Message);
                }
            }
            else
                MessageBox.Show("No items to save");
        }

        private void loadXML(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Filter = "xml (*.xml)|*.xml";
                WmPlayer.Source = null;
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    string filename = ofd.FileName;
                    FileInfo f = new FileInfo(filename);
                    if (f.Extension.EndsWith(".xml"))
                    {
                        if (numberItems == 0)
                        {
                            listItems.Items.Clear();
                            list.Clear();
                        }
                        List<Media> mediaList = xmlClass.ReadXml(filename);
                        if (mediaList.Count > 0)
                        {
                            foreach (Media mi in mediaList)
                            {
                                list.Add(mi);
                                listItems.Items.Add(mi);
                                numberItems = numberItems + 1;
                            }
                            WmPlayer.Source = new Uri(list.First().getUri);
                            if (list.ElementAtOrDefault(PlayListPos) != null)
                            {
                                String musicName = list[PlayListPos].getUri;
                                nowPlaying.Text = "";
                                nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                            }
                            MessageBox.Show("Sucessfully loaded your items");
                        }
                        else
                        {
                            MessageBox.Show("There were no items found to load");
                        }
                    }
                    else
                        MessageBox.Show("Can only open xml files", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }
    }
}
