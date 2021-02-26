# CM 01/02 Starter Kit

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/02ba97d5f1664fe4af4accab27cd770f)](https://www.codacy.com/gh/JonBetts/CM0102-Starter-Kit/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=JonBetts/CM0102-Starter-Kit&amp;utm_campaign=Badge_Grade)

Welcome to the CM 01/02 Starter Kit!

The purpose of this little tool is to get you up and running as quickly as possible with CM 01/02. No need for worrying about downloading files, installing anything, applying patches or changing compatibility settings - this tool does everything required to get you setup on an original or updated version of CM!
Please note that this tool works with **Windows XP, Vista, 7, 8 and 10** and now all **Mac OSX** versions from **High Sierra** all the way up to **Big Sur**. Whilst I have done my best to test on each operating system, there will undoubtedly be scenarios and configurations I haven't managed to cater for. Also if you do use an older operating system
(i.e. XP or Vista) performance may be choppy as it's hard to cater for a 20 year old operating system! I've attempted to make the tool look and feel like the game interface so it's a bit more familiar.

For the Windows version, you will need to make sure you have the **Microsoft .NET 4.0** runtime or higher on your computer before running the tool. This should come pre-installed on Windows 7, 8 and 10, but XP and Vista may require you to manually install it. I've included the installation file with this tool (dotNetFx40setup.exe). Just run that to install it, and you should be good to go (you will need an Internet connection for this though). If you don't install .NET 4.0 or higher, it will come up with an error message saying that the application "**failed to initialise properly**".

To get started, all you have to do is extract the zip file anywhere you like. Click in to the folder that just got created and then double click on **CM0102StarterKit.exe** to start the tool up. Give it anywhere up to 30 seconds the first time you run it, as it needs to unpack the **Game** folder which contains everything needed for the tool to work. If you have an existing installation of CM 01/02 installed in the default location (**C:\Program Files (x86)\Championship Manager 01-02**) then it will automatically copy all of your existing save games across for use with the tool. Please be aware that to play them through this tool, your existing installation needs to have been running with the official 3.9.68 patch installed.

## Mac version notes

Please be aware that the Mac version is a port of the original Windows application. Because of that, certain things won't work in exactly the same way as the Windows version. Here are the important things you need to know:

-   If the app doesn't open for you after you've unzipped it and clicked on it, and it says "CM0102StarterKit is damaged and can't be opened", it's because Apple requires all apps to be "code signed" for authenticity. To get around this, you need to open up Terminal and run the following:
`cd ~/Downloads` (or wherever you downloaded the app to) followed by `sudo xattr -cr CM0102StarterKit.app` (this requires your login password). This may reset the logo on the Starter Kit, but it should fix it so you can run it.

-   In High Sierra (and potentially other versions), when you play the game in windowed mode, there is a black border around the game, and you cannot see the rest of your windows and applications. Unfortunately there isn't a way around this, unless you upgrade to Big Sur as the behaviour isn't present on there.

-   Switching from full screen to windowed mode in-game causes the game to minimise, and then when you click on it, it is now displayed strangely. All you have to do then is exit the game, and then re-open it via the Starter Kit and it should be fine.

-   Please **DO NOT** use the option in Nick's Patcher to change the resolution to 1280x800 if you are using windowed mode - the game will not display properly! It is fine to use in full screen though.

## The basics

It's all very straightforward, but I will give a quick explanation about everything just in case. The main thing you might notice if you've seen the tool before is that it no longer requires any installation at all! Everything is contained within the folder that you create when you unzip the tool after downloading it. So you can easily play CM between different computers without having to install it!

Here's a few screenshots and then an explanation of everything the tool does:

<p align="left"><img src="https://i.ibb.co/qmdQFVh/Main-Menu-v1-1-1.png"/></p>

<p align="left"><img src="https://i.ibb.co/nCH9tc1/Nick-Patcher-Menu-v1-1-1.png"/></p>

<p align="left"><img src="https://i.ibb.co/wcN1HQD/Switch-Versions-Menu-v1-1-1.png"/></p>

<p align="left"><img src="https://i.ibb.co/prt62rJ/Play-Menu-v1-1-1.png"/></p>

-   **Switch Data Update** - This is one of the main features of the tool - you can seamlessly switch between different data updates here. The choices are: original (3.9.60), patched (3.9.68), March 2020, November 2020, Luessenhoff and the 1993/94 database.
All you have to do is click on whichever one you want to use, and wait for a confirmation of it successfully switching. Then you can start a new game and hey presto it's using the data update you wanted!

-   **Install VAR Commentary File** - Adds VAR related commentary to the game - but only for the English language. Shoutout to samsami for creating this!

-   **Nick's Patcher** - Allows you to change a few things in the game using Nick's Patcher, which has been integrated into the tool. The default settings are pre-selected when you navigate to the menu. It is a decent selection of settings for people that want to play vanilla CM with some nice changes that improve the overall experience.
More details about Nick's Patcher, including what each option does, can be found on the website forum here: https://champman0102.net/viewtopic.php?f=35&t=1943 and https://champman0102.net/viewtopic.php?f=72&p=5218.
Big thanks for Nick for his permission to use the Patcher as part of this. It's an incredible piece of kit that we're all very lucky to have available to us!

-   **Official Editor** - Allows you to use the official editor without having to hunt down the file and change the permissions on it, etc.

-   **Play Game** - Allows you to play the game without faffing around with compatibility settings and admin options, and pick between just using standard CM01/02 or applying Nick's Patcher to it and running that. And now of course the beautiful CM93. Do whatever makes you happy!

-   **Back Up Save Games** - This backs up all your save games to the following folder: 'C:\CM0102'.

-   **CM Scout** - Launches CM Scout. It's a nice little tool that means you don't have to rely on your rubbish in-game scouts to find players. Most people think it ruins the game a bit though, so use with caution!

-   **Generated Player Finder** - Launches GPF2. If you run this tool against your save game as early as possible, it will keep a track on which players certain regens were in their previous life! That's pretty much all it does...

## Important note

-   When you are using the Starter Kit, please do not restart the game from the in-game main menu. The game will restart outside of the Starter Kit, and require you to insert the CD, etc, whereas you don't need to do this when you play the game via this tool. You will need to 'Exit Game' and then launch the game again via the Starter Kit when required.

## Troubleshooting

The Starter Kit was made to limit the number of issues you get when setting CM 01/02 up. However, different setups and operating systems may result in unforeseen issues. Please have a look at the support thread for the tool if you need help: https://champman0102.net/viewtopic.php?f=43&t=2449

## Future improvements

As we are only in the early stages of the Starter Kit's life, there are definitely ways in which it can be improved:

-   Ensure the last saved settings for Nick's Patcher are persisted when you next access the page/tool.
-   Allow modified databases to be kept and named, for switching back to at a later date.
-   Change the popup boxes and loader image to fit with the rest of the tool and the game.
-   ... and many more...

## Credit

Let us take a second to remember that we wouldn't all be sitting here today still playing the game if it wasn't for a select group of people.
The infamous Nick for providing us with a user friendly tool that enhances and fixes a lot of things that make the game so much better and give it so much replayability! Also to those that came before him: Saturn and Tapani - the original modders. These guys have provided patches for the game year upon year, and it wouldn't be in it's current state without them.
All the other talented techies that have done their fair share too - John Locke, Tri Wasano, Graeme Kelly, Michael Nygreen (author of the infamous CM Scout), Luessenhoff and Cam for providing us with their fantastic databases that took years of dedication, and anyone else I have forgotten that have helped in any way whatsoever.
We must also not forget Dermot and the update team, who work tirelessly to get every data update delivered as quickly as possible after every transfer window.
Those guys put their hearts and souls into these changes (and hundreds of hours of their own time), and without them, the game wouldn't have half the user base that it still has today. I don't really know any of them by name except Steve Harle (but he's a Spurs fan), but they should know that we are hugely grateful for their efforts!
Special thanks to Ebun Faturoti and Steve Harle for being my beta testers - without you guys, there'd likely still be some bugs lurking in the app!
Quick shoutouts to Mark who keeps the CM01/02 website running smoothly and as a valuable resource to all of us. To my fellow admins of the Facebook group for doing their best to keep the game alive and help others to enjoy it as much as we all do!
