[![Home](https://codeproject.freetls.fastly.net/App_Themes/CodeProject/Img/logo250x135.gif "CodeProject")](https://www.codeproject.com/)

[Articles](https://www.codeproject.com/script/Content/SiteMap.aspx) / [Programming Languages](https://www.codeproject.com/script/Content/Tag.aspx?tags=Languages) / [C#](https://www.codeproject.com/script/Content/Tag.aspx?tags=Csharp)

# Window Tray Minimizer

[Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296)
26 Oct 2007
[CPOL](http://www.codeproject.com/info/cpol10.aspx "The Code Project Open License (CPOL)")

An article showing how to minimize any Window to the system tray

-   [Download demo project - 100.1 KB](https://www.codeproject.com/KB/cs/Trayminimizer/Article_demo.zip)
-   [Download source files - 75.6 KB](https://www.codeproject.com/KB/cs/Trayminimizer/Article_src.zip)

![](https://www.codeproject.com/KB/cs/Trayminimizer/Tray_minimzer.jpg) ![](https://www.codeproject.com/KB/cs/Trayminimizer/Tray_minimzer1.jpg)

### Contents

-   [Introduction](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Introduction0)
-   [Background](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Background1)
-   [Basic P/Invoke](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#BasicP/Invoke2)
-   [How the Program Works](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Howtheprogramworks3)
-   [Code Behind the Application](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Codebehindtheapplication4)
    -   [Enumerating Windows](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#EnumeratingWindows5)
    -   [Hiding the Window...](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Hidingthewindow...6)
    -   [... and Displaying Icon](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#...anddisplayingicon7)
    -   [The Click](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Theclick8)
    -   [Hotkeys](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Hotkeys9)
    -   [Managing Start-up](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Managingstart-up10)
    -   [Making the Application Single-instance](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#Makingtheapplicationsingle-instance11)
-   [Points of Interest](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#PointsofInterest12)
-   [References](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#References13)
-   [History](https://www.codeproject.com/Articles/19439/Window-Tray-Minimizer?display=PrintAll#History14)

## Introduction

The program presented here allows you to minimize any open Window to the system tray with just one click. After reading this article you will know how to call unmanaged code from a .NET application using `P/Invoke`.

## Background

All the functionality of this application is achieved using Windows API functions so you should be familiar with basic `winapi` programming. Consequently you should know what `P/Invoke` is and how it works.

## Basic `P/Invoke`

`P/Invoke` or Platform Invoke allows you to call unmanaged functions from managed code. To do that you need to declare a method and specify the name of the DLL file which contains the method using `DllImport` attribute. For example here is a declaration needed to call `ShowWindow` function from a C# application:

```csharp
[DllImport("user32.dll")]
public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
```

`extern` keyword is used to indicate that the method is implemented externally. Perhaps the most difficult task with P/Invoke is to know how to substitute unmanaged types with managed types. [This](http://www.pinvoke.com/) is a great website which has lots of `winapi` function declarations. There are many tutorials about P/Invoke so I won't go into more details here. See references for the links.

## How the Program Works

When you run the application it hides the main form and an icon is shown in the system tray. When you right-click the icon a list of all visible Windows is displayed. If you click one of them then that Window will disappear and a new icon will appear in the system tray. The icon is the same as the icon of the executable that launched the Window. Clicking on the icon will bring the Window back. Apart from this there are two commands available to minimize all Windows to tray or to show all minimized Windows. Both commands have hotkeys associated with them and they can be changed from the options Window. To open the options Window just double-click the main icon. Other options include adding the program to the start-up program list and ignoring Windows without a title.

## Code Behind the Application

### Enumerating Windows

When you right-click the icon a list of all visible Windows appears. To enumerate all Windows you should call `winapi` function called `EnumWindows`. The function takes two parameters. The first one is a pointer to a callback function. The code snippet below shows how this function works:

```csharp
//This function call EnumWindows and passes delegate to the callback function
private void getwindows()
{
   winapi.EnumWindowsProc callback = new winapi.EnumWindowsProc(enumwindows);
   winapi.EnumWindows(callback, 0);
}

private bool enumwindows(IntPtr hWnd, int lParam)
{
   //Ignore invisible window
   if (!winapi.IsWindowVisible(hWnd))
    return true;

   StringBuilder title = new StringBuilder(256);
   winapi.GetWindowText(hWnd, title, 256);

   if (string.IsNullOrEmpty(title.ToString())&& set.IgnoreTitle)
   {
    return true;
   }

   //Ignore statusbar and add other windows to the list
   if (title.Length != 0 || (title.Length == 0 & hWnd != winapi.statusbar))
   {
    windows.Add(new window(hWnd, title.ToString(), winapi.IsIconic(hWnd),
                                        winapi.IsZoomed(hWnd)));
   }

   return true;
}
```

`window` is a class that has just four fields:

-   `hwnd` - to uniquely identify the `window`
-   `title` - the title of the `window`
-   `isminimized` and `ismaximized` store information about the state of the `window`

`windows` is an instance of the `List<window>` class.

### Hiding the Window...

When a user clicks on one of the Windows we need to hide it. `ShowWindow()` API is used to achieve this. Just pass the handle to the Window as a first parameter and `SW_HIDE` constant (which is equal to zero) as a second parameter.

```csharp
private void showwindow(window wnd, bool hide)
{
   winapi.ShowWindow(wnd.handle, state(wnd, hide));
}

private int state(window wd, bool hide)
{
   if (hide)
   {
    return winapi.SW_HIDE;
   }

   if (wd.isminimzed)
   {
    return winapi.SW_MINIMIZE;
   }

   if (wd.ismaximized)
   {
    return winapi.SW_MAXIMIZE;
   }
    return winapi.SW_SHOW;
}
```

### ... and Displaying Icon

The Window is hidden so we need to retrieve the icon of the executable file that created this Window. To achieve this we need to get the path of the executable first. These are the required steps:

1.  Get the process id that created the specified Window using `GetWindowThreadProcessId()` function
2.  Get a handle of the process by `OpenProcess()` function
3.  Get the executable path by calling `GetModuleFileNameEx()` function

These steps were suggested by Mark Salsbery here: [retrieve executable path by hwnd](http://www.codeproject.com/script/comments/forums.asp?msg=2076785&forumid=1647&Page=3&userid=3136296&mode=all#xx2076785xx). All these functions are `winapi` functions imported by `dllimport` attribute. Here is the actual implementation ported to C#.

```csharp
private string pathfromhwnd(IntPtr hwnd)
{
   uint dwProcessId;

   //Get the process id
   winapi.GetWindowThreadProcessId(hwnd, out dwProcessId);

   //Get the handle of the process
IntPtr hProcess = winapi.OpenProcess(
 winapi.ProcessAccessFlags.VMRead | winapi.ProcessAccessFlags.QueryInformation,
                            false, dwProcessId);

   //Get the executable path
   StringBuilder path = new StringBuilder(1024);
   winapi.GetModuleFileNameEx(hProcess, IntPtr.Zero, path, 1024);

   winapi.CloseHandle(hProcess);
   return path.ToString();
}
```

To retrieve the path to the executable file you can also use `GetProcessImageFileName` API but it returns a path in device form and works on XP and higher. `GetWindowModuleFileName` seemed to be another option but it works only if the specified Window is owned by the calling process.

Now when we have the path to the executable, we can extract the icon that is displayed by explorer using the `SHGetFileInfo()` function. You need to pass the path of the executable and an instance of `SHFILEINFO` structure that will receive the result. After you have retrieved a handle to the icon you must call `DestoyIcon()` API to prevent a memory leak.

```csharp
private Icon Iconfrompath(string path)
{
   System.Drawing.Icon icon = null;

   if (System.IO.File.Exists(path))
   {
    //Retrieve SHFILEINFO type variable
    winapi.SHFILEINFO info = new winapi.SHFILEINFO();
    winapi.SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info),
                winapi.SHGFI_ICON | winapi.SHGFI_SMALLICON);

    //Create icon and destroy the handle
    System.Drawing.Icon temp = System.Drawing.Icon.FromHandle(info.hIcon);
    icon = (System.Drawing.Icon)temp.Clone();
    winapi.DestroyIcon(temp.Handle);
   }

   return icon;
}
```

At this point we have the necessary icon so we just create and show `new` `NotifyIcon` and setup its click event handler. When the click event occurs, the corresponding Window is shown and `NotifyIcon` is destroyed.

### The Click

When an icon is clicked we need to display the corresponding Window. First check if there exists a Window with the specified handle and then call `ShowWindow()` again. This time the second parameter depends on the `state` of the `window`. If the Window was `maximized` (`minimized`) while hiding it, it will be shown `maximized` (`minimized`).

```csharp
void tray_Click(object sender, EventArgs e)
{
   NotifyIcon tray = sender as NotifyIcon;
   window wnd = tray.Tag as window;
   if (winapi.IsWindow(wnd.handle))
   {
    showwindow(wnd, false);
   }
   else
    MessageBox.Show("Window does not exist");

   //Don't forget to remove event handler.
   //Otherwise GC won't collect the notifyicon.
   tray.Click -= new EventHandler(tray_Click);
   tray.Dispose();
}
```

### Hotkeys

This program allows to customize hotkeys for two commands: 'all to tray' and 'show all'. To add hotkey functionality to your application, first you need to register it. `RegisterHotKey()` is a function that is responsible for doing it. It takes four parameters:

1.  Handle to the `window` that will receive `WM_HOTKEY` messages generated by the hot key
2.  ID of the hotkey
3.  Combination of modifier keys (Alt, Ctrl, Shift etc.)
4.  The key itself that should be pressed. The code below registers hotkey for 'All to tray' command

```csharp
if (mod > 0 && key > 0)
{
   winapi.RegisterHotKey(this.Handle, 1729, mod, 64 + key);
}
```

To handle the `WM_HOTKEY` message generated by the hotkey in a .NET application you should override `WndProc` function which processes Windows messages. Don't forget to call `WndProc` method of the base class so that other messages get handled.

```csharp
protected override void WndProc(ref Message m)
{
   switch (m.Msg)
   {
      //We are interested only in WM_HOTKEY message
      case winapi.WM_HOTKEY:
      //m.WParam is the ID we used when registering the hotkey
      ProcessHotkey(m.WParam);
      break;
   }

   //Pass message to base class
   base.WndProc(ref m);
}

private void ProcessHotkey(IntPtr wparam)
{
   if (wparam.ToInt32() == 1729)
   {
      alltray_Click(null, null);
   }

   if (wparam.ToInt32() == 1730)
   {
      showall();
   }
}
```

When the application exits or hotkey changes we don't need the existing hotkey any more so we should unregister it. It is easier then registering the hotkey and is achieved by calling `UnregisterHotKey()` function. Just pass the handle of the `window` and ID of the hotkey:

```csharp
if (mod > 0 && key > 0)
{
   winapi.UnregisterHotKey(this.Handle, 1729);
}
```

### Managing Start-up

You can add the program to start-up from the options Window. To add program to start-up you need to navigate to _HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run_ key, create a new string and set its value equal to the application's path. Removing the program from start-up is easier: you just remove the value. The code snippet below shows how to do it:

```csharp
private void startup(bool add)
{
   isinstartup = add;
   RegistryKey key = Registry.CurrentUser.OpenSubKey(
              @"Software\Microsoft\Windows\CurrentVersion\Run", true);
   if (add)
   {
    //Surround path with " " to make sure that there are no problems
    //if path contains spaces.
    key.SetValue("Tray minimizer", "\"" + Application.ExecutablePath + "\"");
   }
   else
    key.DeleteValue("Tray minimizer");

   key.Close();
}
```

### Making the Application Single-instance

If you try to launch the second instance of the application you will get a message box saying that it is already running. This is achieved using `mutex` class. `Mutex` allows to share resources between threads. When the first instance of the program is launched it creates a new `mutex`. When a second instance is launched it checks the existence of the `mutex`. If it exists then it exits. When the first instance quits it releases the existing `mutex`.

```csharp
static void Main()
{
   Application.EnableVisualStyles();
   Application.SetCompatibleTextRenderingDefault(false);
   Mutex mt = null;

   //Try to open existing mutex
   try
   {
    mt = Mutex.OpenExisting("Tray minimizer");
   }
   catch (WaitHandleCannotBeOpenedException)
   {

   }

   if (mt == null)
   {
    //If the mutex doesn't exist create it and launch the application.
    mt = new Mutex(true, "Tray minimizer");
    Application.Run(new Form1());

    //Tell GC not to destroy mutex until the application is running and
    //release the mutex when application exits.
    GC.KeepAlive(mt);
    mt.ReleaseMutex();
   }
   else
   {
    //The mutex existed so exit
    mt.Close();
    MessageBox.Show("Application already running");
    Application.Exit();
   }
}
```

## Points of Interest

This application shows how powerful `winapi` is and how it can be used from a .NET application to achieve effects that would be otherwise impossible.

## References

-   [Consuming Unmanaged DLL Functions](http://msdn2.microsoft.com/en-us/library/26thfadc%28VS.80%29.aspx)
-   [Platform Invoke Tutorial](http://msdn2.microsoft.com/En-US/library/aa288468%28VS.71%29.aspx)
-   [Essential P/Invoke](https://www.codeproject.com/KB/cs/essentialpinvoke.asp)

## History

-   July 2, 2007 - Initial release

## License

This article, along with any associated source code and files, is licensed under [The Code Project Open License (CPOL)](http://www.codeproject.com/info/cpol10.aspx)


## Comments and Discussions

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | Fork for automatic action | 👤 | [Gluups](https://www.codeproject.com/script/Membership/View.aspx?mid=5328772) | 23-Jan-19 11:54 |

 
I have forked this project so that when launching, the windows that contain, in their title, the character string that is received on the command line, are automatically reduced.  
  
An icon is created in the notification area with the picture of the program attached to the window (standard function of this program). When clicking on this icon, the window is visible again.  
  
When double-clicking on the icon of TrayMinimizer, the treated windows are reduced again, as when TrayMinimizer was launched.  
  
Some work stays to be done : attach the treatment to the closing button, or at least create a button on the window. And maybe some parameterizing, and treating the case of multi-launching of Tray Minimizer (you can need it for several character strings).  
  
What do you think would be the best ? Find another hosting for this fork, or do you want to incorporate it here in a way or another ?  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
|✅ | [Re: Fork for automatic action](https://www.codeproject.com/Messages/5597239/Re-Fork-for-automatic-action) | 👤 | [Gluups](https://www.codeproject.com/script/Membership/View.aspx?mid=5328772) | 20-Feb-19 0:21 |

I created a depot on Github :  
[https://github.com/Gluups/TrayMinimizer1](https://github.com/Gluups/TrayMinimizer1)[[^](https://github.com/Gluups/TrayMinimizer1 "New Window")]  
Several steps are still necessary to obtain something really operational, but it is already possible to give on the command line the name of the window you want to reduce.  
That being said, during that time, somebody made another development that makes this obsolete :  
[4t Tray Minimizer Free/Pro - Minimize Outlook, Internet Explorer, Firefox, Chrome and any other applications to the system tray!](http://www.4t-niagara.com/tray.html)[[^](http://www.4t-niagara.com/tray.html "New Window")]  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | Nice. What about preventing from closing ? | 👤 | [Gluups](https://www.codeproject.com/script/Membership/View.aspx?mid=5328772) | 29-Oct-18 5:05 |


Hello,  
This is a nice way to minimize an application.  
Can you imagine any way to prevent its system closing button to close it, and get it to minimize it instead ?  
That would be nice for an agenda.  
The natural reaction when you finish reading a task in it is to click on the closing button. But in this case, it prevents the agenda from alerting you for the next task.  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | :)  | 👤 | [L3th4l](https://www.codeproject.com/script/Membership/View.aspx?mid=9802433) | 29-Dec-13 17:16 |

Good job! ![Thumbs Up | :thumbsup:](https://codeproject.global.ssl.fastly.net/script/Forums/Images/thumbs_up.gif) Thanx  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | My vote of 5 | ![professional](https://codeproject.freetls.fastly.net/App_Themes/CodeProject/Img/icn-pro-16.png "Professional") | [_Abhishek Pant_](https://www.codeproject.com/script/Membership/View.aspx?mid=9500198) | 24-Oct-12 8:36 |

Very Nicely written  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Thx | 👤 | [iHUPPz Rwt](https://www.codeproject.com/script/Membership/View.aspx?mid=9411414) | 7-Sep-12 15:39 |

Very Nice! I hope will be fun. Thx a lot  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | code C# | 👤 | [sajad_zero](https://www.codeproject.com/script/Membership/View.aspx?mid=8547956) | 29-Jul-12 3:03 |

very good, thanks  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | My vote of 5 | 👤 | [dapuzz](https://www.codeproject.com/script/Membership/View.aspx?mid=2322221) | 22-Jun-12 4:12 |

Clean and usefull  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Thanks | 👤 | [diegogomez86](https://www.codeproject.com/script/Membership/View.aspx?mid=7971813) | 9-Feb-12 15:17 |

I've been looking for something like this for a long time. Thanks  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | "Start" - Windows 7 specific window. | 👤 | [Vercas](https://www.codeproject.com/script/Membership/View.aspx?mid=7215321) | 29-Sep-10 10:59 |

This window assures the glow over the Windows Orb. Please do something not to allow this window to be minimized.  
  
First of all, the orb becomes smaller.  
Second, the mouse over effects and mouse click effects are gone.  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Possible Wrong URL Link | 👤 | [hakimgada](https://www.codeproject.com/script/Membership/View.aspx?mid=6368231) | 30-Nov-09 4:13 |

The link to pinvoke site is wrongly written as [**www.pinvoke.com**](http://www.pinvoke.com/).I tried the site but just to find free icon downloads. A little googling gives me result [**www.pinvoke.net**](http://www.pinvoke.net/)[[^](http://www.pinvoke.net/ "New Window")] for all the possible interop functions listing.  
  
Thanks again  
  
Regards  
Hakim  
Compunix Systems  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Thanx | 👤 | [mr_sawari](https://www.codeproject.com/script/Membership/View.aspx?mid=5966954) | 26-Sep-09 11:33 |

i was need this Article so much thank u ![Big Grin | :-D](https://codeproject.global.ssl.fastly.net/script/Forums/Images/smiley_biggrin.gif)  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Awesome! | 👤 | [shervin18](https://www.codeproject.com/script/Membership/View.aspx?mid=3744646) | 7-Oct-08 3:43 |

Thanks a lot!  
it answered a lot of questions of mine!  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Awesome!](https://www.codeproject.com/Messages/2754419/Re-Awesome) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 7-Oct-08 5:09 |

Glad you liked it 😊
  

Giorgi Dalakishvili  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | hotkey question | 👤 | [svh1985](https://www.codeproject.com/script/Membership/View.aspx?mid=4308239) | 23-Jun-08 9:39 |

hello and thank you for this great article.  
  
i would like to know if you have can tell me the numbers behind the keys on the keyboard?  
  
i found some my self:

```csharp
uint mod = 2; //1 = alt, 2 = control, 4 = shift  
uint key = 27; //1 = a, 26 = z  
```


i would like to make the hotkey CTRL + Spacebar  
  
can you tell me what "unit key" i need for that?  
  
  
thanks!!!  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
|✅ | [Re: hotkey question](https://www.codeproject.com/Messages/2609127/Re-hotkey-question) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 23-Jun-08 13:56 |

Add and event handler for the keypress event and check what you get when you press space key.  
  
Giorgi Dalakishvili  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Thanks Sooooo Much | ![professional](https://codeproject.freetls.fastly.net/App_Themes/CodeProject/Img/icn-pro-16.png "Professional") | [**Xmen Real**](https://www.codeproject.com/script/Membership/View.aspx?mid=3222480) | 1-Jan-08 22:17 |

Mutex helped me out  
  
Excellent!!!  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Gooooooooooooooooooood :) | 👤 | [eusta](https://www.codeproject.com/script/Membership/View.aspx?mid=3901018) | 30-Nov-07 10:10 |

Hello  
Sorry my English 😊
This is a fantastic application, if I am not mistaken, there is only an application that allows you to do so also pay  
  
Nice work compliments.  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Gooooooooooooooooooood :)](https://www.codeproject.com/Messages/2343588/Re-Gooooooooooooooooooood) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 30-Nov-07 12:12 |

Thanks very much 😊 If you like it please vote for the article. Thanks!  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Nice work | 👤 | [**Sandeep Akhare**](https://www.codeproject.com/script/Membership/View.aspx?mid=3035713) | 30-Oct-07 10:17 |

😊 Just got the code Project News letter and saw your article also downloaded.  
Giorgi it is very nice article man i am using it in my machine .  
Good work  
  

Thanks and Regards  
**Sandeep**  
  
If If you look at what you do not have in life, you don't have anything,  
If you look at what you have in life, you have everything... "  
 

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Nice work](https://www.codeproject.com/Messages/2296051/Re-Nice-work) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 30-Oct-07 14:05 |

Thanks very much 😊
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | Questions | 👤 | [nhc1987](https://www.codeproject.com/script/Membership/View.aspx?mid=3725379) | 30-Sep-07 3:29 |

**1. Can we get information about an icon that exists in system tray ?**  
  
For example, I have 2 icons in system tray. They're YIM and BitDefender antivirus. I want to know all information about Bitdefender notify icon. How to do that ?  
  
**2. When we've got information about that icon, how can we send it a message like WM_LBUTTONDOWN, WM_RBUTTONDOWN, ... and choose an item in pop-up menu**  
  
For example, with Bitdenfender antivirus, when we right click on its icon, it open a pop-up menu. Then, we click the item "Show" to show its GUI 😊
  
It look like an auto click program really  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
|✅ | [Re: Questions [modified]](https://www.codeproject.com/Messages/2265609/Re-Questions-modified) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 10-Oct-07 15:20 |

There is an article that describes how to do it. If I find it, I'll put the link.  
  
Here it is: http://www.codeproject.com/tools/ShellTrayInfo.asp  
-- modified at 16:26 Wednesday 10th October, 2007  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Useful tool | 👤 | [Juraj Borza](https://www.codeproject.com/script/Membership/View.aspx?mid=2904136) | 7-Aug-07 1:28 |

This is quite useful tool, and the accompanying article is well-written too. I give you 5. 😊

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Useful tool](https://www.codeproject.com/Messages/2171034/Re-Useful-tool) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 7-Aug-07 5:00 |

Thanks 😊
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Nice tool | 👤 | [Ahmad_Hashem](https://www.codeproject.com/script/Membership/View.aspx?mid=484480) | 11-Jul-07 1:50 |

Nice tool, nice article, nice of you 😊



|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Nice tool](https://www.codeproject.com/Messages/2124137/Re-Nice-tool) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 11-Jul-07 2:30 |

Thanks 😊
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Great | 👤 | [**Muammar©**](https://www.codeproject.com/script/Membership/View.aspx?mid=856406) | 10-Jul-07 0:58 |

You're truly one of the best here in the cp.. I've always wanted an article dealing with currently open windows..  
  
Thank you for sharing this with us 🌹


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Great](https://www.codeproject.com/Messages/2121748/Re-Great) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 10-Jul-07 1:18 |

> Muammar© wrote:
> 
> You're truly one of the best here in the cp.. I've always wanted an article dealing with currently open windows..
  
Thank you very much 😊
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Dood. | 👤 | [Marc Leger](https://www.codeproject.com/script/Membership/View.aspx?mid=880352) | 8-Jul-07 6:29 |

You rock.  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Dood.](https://www.codeproject.com/Messages/2120498/Re-Dood) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 9-Jul-07 7:23 |

Thanks 😊
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | About.dll embedded dll | 👤 | [stano](https://www.codeproject.com/script/Membership/View.aspx?mid=50189) | 7-Jul-07 10:43 |

You didn't include the code for the about.dll.  
  
Unfortunately the code looks good, but I won't run it asit has embedded dlls in it.  
 

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: About.dll embedded dll](https://www.codeproject.com/Messages/2118549/Re-About-dll-embedded-dll) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 7-Jul-07 13:20 |

About.dll is used to show the about box. I didn't include its source because it just a simple form. If you don't trust the DLL there are several solutions:  
1.I can e-mail you the source code  
2.You can remove about.dll from the project  
3.You can run the program but don't click about.  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: About.dll embedded dll](https://www.codeproject.com/Messages/4168770/Re-About-dll-embedded-dll) | 👤 | [sixxkilur](https://www.codeproject.com/script/Membership/View.aspx?mid=7749231) | 27-Feb-12 17:46 |

This embedded DLL About.dll is just a Public Class with a Windows Form in it containing  
about info of the author and program. 100% safe.  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| ❓❓ | The VB.NET version? | 👤 | [stevenyoung](https://www.codeproject.com/script/Membership/View.aspx?mid=622290) | 3-Jul-07 0:37 |

Good program! is there a vb.net version? can it work on 64bit OS? thank you.  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
|✅ | [Re: The VB.NET version?](https://www.codeproject.com/Messages/2110418/Re-The-VB-NET-version) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 3-Jul-07 4:19 |

No there isn't VB.net version but you can easily rewrite it for VB. As for 64bit OS if the API functions used here work in the same way on 64bit then it will work without any problems.  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | Possible error | 👤 | [Ed.Poore](https://www.codeproject.com/script/Membership/View.aspx?mid=1796977) | 2-Jul-07 13:55 |

```csharp
//Don't forget to remove event handler. 
//Otherwise GC won't collect the notifyicon.
tray.Click -= new EventHandler(tray_Click);
```

The above code doesn't remove the event handler from what I remember (you're creating a new instance), but you can accomplish the same thing in fewer characters with:  

```csharp
tray.Click -= tray_Click;
```

What the original code is doing is creating a new delegate pointing to the method and then removing it, leaving the original in tact.  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | 👤[Re: Possible error](https://www.codeproject.com/Messages/2109531/Re-Possible-error) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 2-Jul-07 14:21 |

Hello Ed,  
I just tried removing event handler from button in just the same way and it is being removed. Thanks for the shorthand method ![Wink | ;)](https://codeproject.global.ssl.fastly.net/script/Forums/Images/smiley_wink.gif)  
  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Possible error](https://www.codeproject.com/Messages/2109544/Re-Possible-error) | 👤 | [Ed.Poore](https://www.codeproject.com/script/Membership/View.aspx?mid=1796977) | 2-Jul-07 14:30 |

> Giorgi Dalakishvili wrote:
> 
> I just tried removing event handler from button in just the same way and it is being removed.

  
Odd, it's seems unintuitive but that's MS.  

> Giorgi Dalakishvili wrote:
> 
> Thanks for the shorthand method

  
Not a problem.


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Possible error](https://www.codeproject.com/Messages/2110366/Re-Possible-error) | 👤 | [Steve Hansen](https://www.codeproject.com/script/Membership/View.aspx?mid=1545213) | 3-Jul-07 3:50 |

Actually they both do the same thing 😊
The .NET 2.0 compiler just adds new EventHandler() to the short version (you can check this by using Reflector)  
In 1.0 and 1.1 you HAD to use the first version, and it does remove the handler from the click event.  
  
Easy way to test it:

```csharp
tray.Click += new EventHandler(tray_Click);
tray.Click -= new EventHandler(tray_Click);
```
  
`tray.Click` is now back `null`  
  
The trick is that the Equals method of Delegate will check if it points to the same method instead of just checking if its the same instance so  

```csharp
bool test = new EventHandler(tray_Click) == new EventHandler(tray_Click);
```

Will set test to true  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Possible error](https://www.codeproject.com/Messages/2110499/Re-Possible-error) | 👤 | [Ed.Poore](https://www.codeproject.com/script/Membership/View.aspx?mid=1796977) | 3-Jul-07 4:56 |

Interesting, just seems unintuitive to me (on the surface anyway), if I dug into the internal implementation of delegates then it'd probably be logical.  


|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
|✅ | [Re: Possible error](https://www.codeproject.com/Messages/2118249/Re-Possible-error) | 👤 | [ADLER1](https://www.codeproject.com/script/Membership/View.aspx?mid=3150751) | 7-Jul-07 5:20 |

If I'm coding the `EventHandlers` myself (so out of Windows Forms Designer), I do it in the following way:  
  
First I declare a class variable for the handler:  

```csharp
private EventHandler myCtrl_Click;
```
  
Then I create an instance of it (e.g. in the constructor):

```csharp
this.myCtrl_Click = new EventHandler(MyCtrl_OnClick);
```
  
After this I add or remove handler to/from the event where I want:  

```csharp
this.myCtrl.Click += this.myCtrl_Click;<br />
this.myCtrl.Click -= this.myCtrl_Click;
```

  
  
Doing this way I make sure that there are no unnecessary object instances.  
  

_____________________________  
The force of .NET is with me!

  

|     |     |     |     |     |
| ---: | :--- | --- | :--- | ---: |
| 📄 | [Re: Possible error](https://www.codeproject.com/Messages/2118550/Re-Possible-error) | 👤 | [Giorgi Dalakishvili](https://www.codeproject.com/script/Membership/View.aspx?mid=3136296) | 7-Jul-07 13:21 |

Interesting approach  

  
