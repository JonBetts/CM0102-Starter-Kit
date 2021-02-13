# CM 01/02 Starter Kit

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/02ba97d5f1664fe4af4accab27cd770f)](https://www.codacy.com/gh/JonBetts/CM0102-Starter-Kit/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=JonBetts/CM0102-Starter-Kit&amp;utm_campaign=Badge_Grade)

Welcome to the CM 01/02 Starter Kit!

The purpose of this little tool is to get you up and running as quickly as possible with CM 01/02. No need for worrying about downloading files, installing anything, applying patches or changing compatibility settings - this tool does everything required to get you setup on an original or updated version of CM!
Please note that this tool only works with **Windows XP, Vista, 7, 8 and 10**. Whilst I have done my best to test on each operating system, there will undoubtedly be scenarios and configurations I haven't managed to cater for. Also if you do use an older operating system
(i.e. XP or Vista) performance may be choppy as it's hard to cater for a 20 year old operating system! I've attempted to make the tool look and feel like the game interface so it's a bit more familiar.

You will need to make sure you have the **Microsoft .NET 3.5** runtime on your computer before running the tool. This should come pre-installed on Windows 7, 8 and 10, but XP and Vista may require you to manually install it. I've included the installation file with this tool (dotNetFx35setup.exe). Just run that to install it, and you should be good to go (you will need an Internet connection for this though). If you don't install .NET 3.5, it will come up with an error message saying that the application "**failed to initialise properly**".

To get started, all you have to do is extract the zip file anywhere you like. Click in to the folder that just got created and then double click on **CM0102StarterKit.exe** to start the tool up. Give it anywhere up to 30 seconds the first time you run it, as it needs to unpack the **Game** folder which contains everything needed for the tool to work. If you have an existing installation of CM 01/02 installed in the default location (**C:\Program Files (x86)\Championship Manager 01-02**) then it will automatically copy all of your existing save games across for use with the tool. Please be aware that to play them through this tool, your existing installation needs to have been running with the official 3.9.68 patch installed.

## The basics

It's all very straightforward, but I will give a quick explanation about everything just in case. The main thing you might notice if you've seen the tool before is that it no longer requires any installation at all! Everything is contained within the folder that you create when you unzip the tool after downloading it. So you can easily play CM between different computers without having to install it!

Here's a few screenshots and then an explanation of everything the tool does:

<p align="left"><img src="https://i.ibb.co/BwSr9nV/Main-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/28Zw20G/Nick-Patcher-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/FVCHRmZ/Version-Menu.png"/></p>

<p align="left"><img src="https://i.ibb.co/rmPXHB1/Play-Menu.png"/></p>

-   **Switch Data Update** - This is one of the main features of the tool - you can seamlessly switch between different data updates here. The choices are: original database (3.9.60), patched database (3.9.68), March 2020 database, November 2020 database and the Luessenhoff database.
All you have to do is click on whichever one you want to use, and wait for a confirmation of it successfully switching. Then you can start a new game and hey presto it's using the data update you wanted!

-   **Install VAR Commentary File** - Adds VAR related commentary to the game - but only for the English language. Shoutout to samsami for creating this!

-   **Nick's Patcher** - Allows you to change a few things in the game using Nick's Patcher, which has been integrated into the tool. The default settings are pre-selected when you navigate to the menu. It is a decent selection of settings for people that want to play vanilla CM with some nice changes that improve the overall experience.
More details about Nick's Patcher, including what each option does, can be found on the website forum here: https://champman0102.net/viewtopic.php?f=35&t=1943 and https://champman0102.net/viewtopic.php?f=72&p=5218.
Big thanks for Nick for his permission to use the Patcher as part of this. It's an incredible piece of kit that we're all very lucky to have available to us!

-   **Official Editor** - Allows you to use the official editor without having to hunt down the file and change the permissions on it, etc.

-   **Play Game** - Allows you to play the game without faffing around with compatibility settings and admin options, and pick between just using standard CM01/02 or applying Nick's Patcher to it and running that. Do whatever makes you happy!

-   **Back Up Save Games** - This backs up all your save games to the following folder: 'C:\CM0102'.

-   **Website** - Launches the website in your default browser in case you need to go there for advice, downloads or some CM-related banter.

-   **CM Scout** - Launches CM Scout. It's a nice little tool that means you don't have to rely on your rubbish in-game scouts to find players. Most people think it ruins the game a bit though, so use with caution!

## Important note

-   When you are using the Starter Kit, please do not restart the game from the in-game main menu. The game will restart outside of the Starter Kit, and require you to insert the CD, etc, whereas you don't need to do this when you play the game via this tool. You will need to 'Exit Game' and then launch the game again via the Starter Kit when required.

## Troubleshooting

The Starter Kit was made to limit the number of issues you get when setting CM 01/02 up. However, different setups and operating systems may result in unforeseen issues. One thing I've come across is occassionally the game might not load as it doesn't like starting up in full screen/windowed mode ("cannot initialise graphics bla bla"). This has been an issue with CM for a long time, so there are numerous fixes on the forums for this, so have a look at those and see if you can solve it.

## Future improvements

As this is only the second iteration of the Starter Kit, there are definitely ways in which it can be improved:

-   Ensure the last saved settings for Nick's Patcher are persisted when you next access the page/tool.
-   Allow modified databases to be kept and named, for switching back to at a later date.
-   Change the popup boxes and loader image to fit with the rest of the tool and the game.
-   Somehow get it working on Mac OSX.
-   ... and many more...

## Credit

Let us take a second to remember that we wouldn't all be sitting here today still playing the game if it wasn't for a select group of people.
The infamous Nick for providing us with a user friendly tool that enhances and fixes a lot of things that make the game so much better and give it so much replayability! Also to those that came before him: Saturn and Tapani - the original modders. These guys have provided patches for the game year upon year, and it wouldn't be in it's current state without them.
All the other talented techies that have done their fair share too - John Locke, Tri Wasano, Graeme Kelly, Michael Nygreen (author of the infamous CM Scout), Luessenhoff for providing us with his fantastic database, and anyone else I have forgotten that have helped in any way whatsoever.
We must also not forget Dermot and the update team, who work tirelessly to get every data update delivered as quickly as possible after every transfer window.
Those guys put their hearts and souls into these changes (and hundreds of hours of their own time), and without them, the game wouldn't have half the user base that it still has today. I don't really know any of them by name except Steve Harle (but he's a Spurs fan), but they should know that we are hugely grateful for their efforts!
Special thanks to Ebun Faturoti and Steve Harle for being my beta testers - without you guys, there'd likely still be some bugs lurking in the app!
Quick shoutouts to Mark who keeps the CM01/02 website running smoothly and as a valuable resource to all of us. To my fellow admins of the Facebook group for doing their best to keep the game alive and help others to enjoy it as much as we all do!
