# TrayMinimizer1
Minimize applications to the system tray

This is a fork of this project :
https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer

It is modified to accept a string on the command line, to only treat windows that contain that string. 
If you type "TrayMinimizer Sunbird" on the command line, double click on the TrayMinimizer icon 
will reduce Sunbird to the notification area. Click on the Sunbird icon will restore its window.

Still to be done :
- authorize several sessions, to reduce several different windows
- when restoring a window by clicking on its icon, let the icon visible so that you can hide the window again with it.
This would let hide and restore a window without moving the mouse cursor
- support of the keyboard
- probably update the menu
- documentation
- internationalization

Another project exists for these functionnality and others, that I discovered recently.
