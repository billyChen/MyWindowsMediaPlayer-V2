   M S B A M L   `   `   `  ����  MyWindowsMediaPlayer&     MyWindowsMediaPlayer.MediaPlayer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$   My Windows Media Player V2��5   	   $	��840��5   	   $	��500��6   $	��840��6(    � WindowStyle$ SingleBorderWindow=�5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5	   
   -   5           Command$ ApplicationCommands.Open��5	      6Y     5
   
   -   5        $ MediaCommands.Play��5
      6S     5   
   -   5        $ MediaCommands.Pause��5      6U     5   
   -   5        $ MediaCommands.Stop��5      6S    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Resources/Templates.xaml?�6%   �� 5      $ Resources/Styles.xaml?�6%   %    5      .��5      ]� .+�5      c� -   5        $��mainTb��5   +   $	��Top=�6   .@�5      ��  � ToolTip$ 	Open file��6   $��	Wingdings)�6.   
���� ��$��20(�6^   $��ApplicationCommands.Open��6l   .��6�   15      �� 5      -   5        $ 
Clear list��5      $��	Wingdings)�6/   
���� ��$��25(�6_   .��6   û5       �� 5!      -   5        $ 	Save list��5!      $��	Wingdings)�6-   
���� ��$��20(�6]   .��6{   =5#      �� 5$      -	   5        $ Load xml file��5$      $��	Wingdings)�61   
���� ��$��20(�6a   .��6   65&      �� 5'      -
   5        $ 
fullscreen��5'      $��Webdings)�6.   
���� ��$��20(�6]   .��6~   25)      �� 5*      -   5        $ Change themes��5*      $��	Wingdings)�6.   
���� ��$��20(�6^   .��6�   o5,      5-      �� 5.      -   5        $��bottomStackPanel��5.   2   $��Bottom=�6   .+�50      �� ��51      �� 52      .R�53      �  � ColumnDefinitions 54      �� 55   "   $
��Auto �63   �� 56   "   $��* �63   �� 57   "   $
��Auto �63   5:      5;      .@�5=      �� .��5>      �� -   5        $��lblProgressStatus��5>       
00:00:006C   5?      �� 5@      $��1��6    $��Stretch=�60   .��5A      �� -   5        $��sliProgress��5A      6�   5B      �� 5C      $��2��6    .��5D      � -   5        $��pbVolume��5D   "   $��50��62   $��12��6=   	 � Maximum$	 1Q�6I   
 � Value
 6U   ��  �� ElementName$ WmPlayer�� �� Path$ Volume�5E      5F      �� 5G      -   5         ��Name$ 
nowPlaying��5G      
������� �� TextAlignment$ Center=�6C   6\   � 5H       5I      �� 5J      $	��200 �6'   �� 5K      $��* �6'   �� 5L      $	��200 �6'    � RowDefinitions 5O      �� 5P      $��* �6$   �� 5Q      $��* �6$   �� 5R      $��* �6$   .+�5T      �� $��Center=�6    �� Orientation$ 
Horizontal=�6:   $��1��6S   .+�5U      �� -   5        $��PreviousSongButton��5U         controlLastButtonTemplate#��[  6L   $��Webdings)�6�   
���iii�$��25(�6�   $
��Bold"�6�   $��9��6�   6�   �� 5V      -   5        $��
StopButton��5V      $��MediaCommands.Stop��6/    " controlButtonSecondaryTemplate#��[ 6L   $��Webdings)�6�   
���iii�$��35(�6�   $
��Bold"�6�   $��<��6�   6�   �� 5W      -   5        $��
PlayButton��5W      $��MediaCommands.Play��60     controlButtonTemplate#��[ 6M   $��Webdings)�6�   $��45(�6�   $
��Bold"�6�   $��4��6�   $��1,1,1,1q�6�   6�   �� 5X      -   5        $��PauseButton��5X      $��MediaCommands.Pause��60   #��[ 6N   
���iii�$��Webdings)�6�   $��35(�6�   $
��Bold"�6�   $��;��6�   6�   �� 5Y      -   5        $��NextSongButton��5Y      #��[  6E   $��Webdings)�6|   
���iii�$��25(�6�   $
��Bold"�6�   $��:��6�   6�   5Z      5[      5\      � 5]   
   -   5        $
��Left=�5]       J� 	AllowDrop .  5^      �� 5_      $	��200 �6#    5b      �� 5c      $��* �6    .+�5f      �� 
�������
�������$��1q�6E   ._�5g      �� .��5h      �� -   5         ��Name$ 	listItems��5h      .@�5i      �� .��6&   Drag Item Here66   5j      5k      5l      5m      r� 5n   
   -   5        $��WmPlayer��5n       r� Stretch$ Uniform=�6'    r� LoadedBehavior$ Manual=�6P   5o      5p      