# CM 01/02 Starter Kit

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/02ba97d5f1664fe4af4accab27cd770f)](https://www.codacy.com/gh/JonBetts/CM0102-Starter-Kit/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=JonBetts/CM0102-Starter-Kit&amp;utm_campaign=Badge_Grade)

Welcome to the CM 01/02 Starter Kit!

The purpose of this little tool is to get you up and running as quickly as possible with CM 01/02. No need for worrying about downloading files, applying patches or changing compatibility settings - this tool does everything required to get you setup on an original or updated version of CM!
Please note the standard version only works with Windows 7, 8 and 10. I have an XP specific version I can upload if there is any desire for it.
If you do use the Windows XP version, performance may be choppy as it's hard to cater for a 20 year old operating system! I've attempted to make it look and feel like the game interface so it's a bit more familiar.

To get started, all you have to do is extract the zip file anywhere you please - the tool is completely portable. Please read through this document before starting. One thing I need to highlight now is that for any of this to work you need to install CM in the default folder.
If you don't, the tool will not work properly. I'll hopefully release a version further down the line that can cope with a custom installation location.

If you've downloaded the XP version of the tool, then you will need to make sure you have the Microsoft .NET 3.5 runtime on your computer before running it (https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1). If you don't, it will come up with an error message saying that the application "failed to initialise properly".
If you have the normal version of the tool, you will need the Microsoft .NET 4.5 runtime. This will usually already be pre-installed on Windows 7, 8 and 10, but if not, you may be advised to
install it by Windows, so just follow the instructions. Failing that, it can be found here: https://dotnet.microsoft.com/download/dotnet-framework/net45

## The basics

It's all very straightforward, but I will give a quick explanation about everything just in case. Here's a few screenshots and then an explanation of everything the tool does:

<p align="left"><img src="https://i.ibb.co/NrWspVh/Main-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/28Zw20G/Nick-Patcher-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/FVCHRmZ/Version-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/rmPXHB1/Play-Menu.png"/></p>

-   **Insert CD** - On Windows XP and 7 this will install a small virtual drive on your computer that allows us to mount the image file that the game is on. All you need to do is accept the installation of the driver. This isn't necessary on Windows 8 and 10 as they come with this feature built-in.
On all versions, it then adds a virtual CD drive to your system and then mounts the CD image onto it. Equivalent to inserting the CD back in the day.

-   **Install Game** - Opens up the installation procedure for the game. As I said above, _please_ ensure you install CM 01/02 in the default folder. All other options are fine to change, but it needs to be in the default location! After installation, the official 3.9.68 patch is automatically installed.
Please don't cancel this - the patch is vital to running the game free of errors!

-   **Install Official Patch** - Opens up the installation procedure for the official 3.9.68 patch, if for whatever reason you need to have the patch re-installed.

-   **Install VAR Commentary File** - Adds VAR related commentary to the game - but only for the English language. Shoutout to samsami for creating this!

-   **Nick's Patcher** - Allows you to change a few things in the game using Nick's Patcher, which has been integrated into the tool. The default settings are pre-selected when you navigate to the menu. It is a decent selection of settings for people that want to play vanilla CM with some nice changes that improve the overall experience.
However, if you are confident you know what you're doing with Nick's Patcher, and want to customise it properly yourself, then feel free to just download and use the full version of Nick's Patcher.
However please be aware that if you do that and you still want to use the Starter Kit, you will need to ensure you select the CM01/02 "Standard" version when it comes to choosing which version you want to play.
More details about Nick's Patcher, including what each option does, can be found on the website forum here: https://champman0102.net/viewtopic.php?f=35&t=1943 and https://champman0102.net/viewtopic.php?f=72&p=5218.
Big thanks for Nick for his permission to use the Patcher as part of this. It's an incredible piece of kit that we're all very lucky to have available to us!

-   **Editor** - Allows you to use the official editor without having to hunt down the file and change the permissions on it, etc.

-   **Switch Data Update** - This is one of the main features of the tool - you can seamlessly switch between different data updates here. The choices are: original database (3.9.60), patched database (3.9.68), March 2020 database, November 2020 database and the Luessenhoff database.
All you have to do is click on whichever one you want to use, and wait for a confirmation of it successfully switching. Then you can start a new game and hey presto it's using the data update you wanted!

-   **Play Game** - Allows you to play the game without faffing around with compatibility settings and admin options, and pick between just using standard CM01/02 or applying Nick's Patcher to it and running that. Do whatever makes you happy!

-   **Website** - Launches the website in your default browser in case you need to go there for advice, downloads or some CM-related banter.

-   **Back Up Save Games** - This backs up all your save games to the following folder: 'C:\CM0102'. It copies your saves, and also adds an extra copy with a '.bk' file extension just in case Windows Update magically deletes all your '.sav' files (which it has been known to do).

If you're unsure you what to do, just attempt a basic setup at first. Basic steps would be: **Insert CD** -> **Install Game** -> **Play Game** -> **CM01/02 Standard**
Hopefully it's all straightforward enough.

## Important things to note - PLEASE READ THIS BEFORE STARTING

-   You don't need to use any of the standard shortcuts that get added when CM gets installed. Always use the Starter Kit and you'll be grand. If you have any issues because you've been running the game outside of this package then there isn't too much I can do to help.
-   As stated earlier, please, please do not install the game anywhere but the default folder that the installer selects, otherwise nothing will work.
-   On Windows XP and 7, DO NOT eject the CD image manually (i.e. via the Windows context menu). You won't be able to use the Starter Kit again until you restart your computer. It's a minor bug with the virtual drive application I've used.
-   This is an important one! If you are using Nick's Patcher integrated within the kit, the patcher settings won't stay applied when restarting the game from the in-game main menu. To keep playing with Nick's Patcher applied, you will need to 'Exit Game' and then launch the game again via the Starter Kit.

## Troubleshooting

The Starter Kit was made to limit the number of issues you get when setting CM 01/02 up. However, different setups and operating systems may result in unforeseen issues. One thing I've come across on Windows XP/8/10 is when your resolution isn't set to some scale of 800x600,
it doesn't like starting up in windowed mode ("cannot initialise graphics bla bla"). What I mean is, your main screen resolution (both height and width) have to be the same multiple of the original 800x600 pixels for it to run windowed. I.e. if your resolution's height is 1600 pixels,
then the width has to be 1200 (both of them have twice (x2) the amount of pixels than the original 800 by 600). If this all sounds too complex, just try changing your screen resolution in the Windows settings until one of them runs with CM 01/02 windowed! Or just run it full screen.
If that doesn't work, you may have some DirectX files missing, so try installing them from the following link: https://www.microsoft.com/en-gb/download/details.aspx?id=35

## Future improvements

As this is the first iteration of the Starter Kit, there are definitely ways in which it can be improved:

-   Ensure the last saved settings for Nick's Patcher are persisted when you next access the page/tool.
-   Ensure the tool can work with CM 01/02 being installed in a non-default location.
-   Allow modified databases to be kept and named, for switching back to at a later date.
-   Change the popup boxes and loader image to fit with the rest of the tool and the game.
-   ... and many more...

## Credit

Let us take a second to remember that we wouldn't all be sitting here today still playing the game if it wasn't for a select group of people.
The infamous Nick for providing us with a user friendly tool that enhances and fixes a lot of things that make the game so much better and give it so much replayability! Also to those that came before him: Saturn and Tapani - the original modders. These guys have provided patches for the game year upon year, and it wouldn't be in it's current state without them.
All the other talented techies that have done their fair share too - John Locke, Tri Wasano, Graeme Kelly, Michael Nygreen (author of the infamous CM Scout), Luessenhoff for providing us with his fantastic database, and anyone else I have forgotten that have helped in any way whatsoever.
We must also not forget Dermot and the update team, who work tirelessly to get every data update delivered as quickly as possible after every transfer window.
Those guys put their hearts and souls into these changes (and hundreds of hours of their own time), and without them, the game wouldn't have half the user base that it still has today. I don't really know any of them by name except Steve Harle (but he's a Spurs fan), but they should know that we are hugely grateful for their efforts!
Special thanks to Ebun Faturoti and Steve Harle for being my beta testers - without you guys, there'd likely still be some bugs lurking in the app!
Quick shoutouts to Mark who keeps the CM01/02 website running smoothly and as a valuable resource to all of us. To my fellow admins of the Facebook group for doing their best to keep the game alive and help others to enjoy it as much as we all do!
