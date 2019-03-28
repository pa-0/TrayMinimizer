# TrayMinimizer1
Minimize applications to the system tray

This is a fork of this project :
https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer

It is modified to accept a string on the command line, to only treat windows that contain that string. 
If you type "TrayMinimizer Sunbird" on the command line, double click on the TrayMinimizer icon 
will reduce Sunbird to the notification area. Click on the Sunbird icon will restore its window.

Version 2 authorizes the program to be launched several times, so that it can treat windows of several applications, noticed by a character chain in the command line.
This character chain appears down the tooltip, that appears when the icon in the notification area is hovered with the mouse cursor. This helps to differentiate the different icons of the different occurrences of the program.
When you double-click on a TrayMinimizer icon, all windows that have this character chain in their caption get reduced to the notification area, and do not appear when typing Alt Tab.

Still to be done :
- update the About dialog box
- user documentation
- user download of executable
- (...)
- when restoring a window by clicking on its icon, let the icon visible so that you can hide the window again with it.
This would let hide and restore a window without moving the mouse cursor
- support of the keyboard
- probably update the menu
- internationalization

Another project exists for these functionnalities and others, that I discovered recently.
