# Championship Manager 01/02 Starter Kit

Welcome to the Championship Manager 01/02 Starter Kit!

The purpose of this little tool is to get you up and running as quickly as possible with CM 01/02. No need for worrying about downloading files, installing anything, using external patchers or tools, or changing compatibility settings - this tool does everything required to get you setup on an original or updated version of CM!
Please note that this tool works with **Windows XP, Vista, 7, 8 and 10** and now (should) work on all **Mac OSX** versions from **High Sierra** all the way up to **Big Sur**. Whilst I have done my best to test on each operating system, there will undoubtedly be scenarios and configurations I haven't managed to cater for. Also if you do use an older operating system
(i.e. XP or Vista) performance may be choppy as it's hard to cater for a 20 year old operating system! I've attempted to make the tool look and feel like the game interface so it's a bit more familiar.

For the Windows version, you will need to make sure you have the **Microsoft .NET 4.0** runtime or higher on your computer before running the tool. This should come pre-installed on Windows 7, 8 and 10, but XP and Vista may require you to manually install it. I've included the installation file with this tool (dotNetFx40setup.exe). Just run that to install it, and you should be good to go (you will need an Internet connection for this though). If you don't install .NET 4.0 or higher, it will come up with an error message saying that the application "**failed to initialise properly**".

To get started, all you have to do is extract the downloaded zip file anywhere you like. I recommend doing that somewhere you know that your user account has full access to/permission for, like the Desktop or somewhere in your user folder. Click in to the folder that just got created and then double click on **CM0102StarterKit.exe** to start the tool up (if you want to, you can right click and run as an administrator, but it shouldn't be necessary). Give it anywhere up to 30 seconds the first time you run it, as it needs to unpack the **Game** folder which contains everything needed for the tool to work.

If you have any issues upon first usage of the tool, please head to the support thread on the forum to see if the FAQs can help you: https://champman0102.net/viewtopic.php?p=14458#p14458

## Mac version notes

Please be aware that the Mac version is a port of the original Windows application. Because of that, certain things won't work in exactly the same way as the Windows version. Here are the important things you need to know:

- I have had confirmation from someone that the Starter Kit does indeed run well on the new M1 Macbooks.

-   Previously, I gave advice about removing the quarantine flag ("the app is damaged" message) from the Starter Kit application after unzipping the file, etc. Well it's actually easier to do this before doing anything else. So as soon as the Starter Kit zip file has been downloaded, open up Terminal, and run the following command:
`xattr -drs com.apple.quarantine ~/Downloads/CM0102.Starter.Kit.Mac.v1.2.2.zip`.
This should now allow you to unzip and run the application properly without any messages about the application being "damaged". If you have changed where your download folder is located, then adjust the command above accordingly. Once that command has run successfully, extract the zip file and double click on the CM0102StarterKit app, and give it 20-30 seconds to load for the first time. **DO NOT** extract the zip file using Keka!

-   In High Sierra (and potentially other versions), when you play the game in windowed mode, there is a black border around the game, and you cannot see the rest of your windows and applications. Unfortunately there isn't a way around this, unless you upgrade to Big Sur as the behaviour isn't present on there.

-   Switching from full screen to windowed mode in-game causes the game to minimise, and then when you click on the icon on the taskbar, it is now displayed strangely. All you have to do then is exit the game, and then re-open it via the Starter Kit and it should be fine.

-   Please **DO NOT** use the option in Nick's Patcher to change the resolution to 1280x800 if you are using windowed mode - the game will not display properly! It is fine to use in full screen mode though, and I would recommend it in that scenario.

-   There is a very minor bug when using the trackpad in Mac - if you're scrolling with it, it scrolls all the way to the bottom of the page, and won't stop until you click somewhere. In short, if you are going to use your trackpad, you'll be better off clicking and dragging the scrollbars as you would on Windows. An alternative (and better) solution is to use an external mouse, as you won't have this issue.

-   If you want to browse the game folder, you will need to right click on the app, then click "Show Package Contents". Then you need to navigate to `drive_c -> Program Files -> Starter Kit v*.*.* -> Game`. This is where you can find your saved games, or copy content across like tactic folders, menu bars, etc.

-   If, after reading all of the above, you cannot get the tool running on your Mac, then the last resort would be to upgrade to Big Sur as that is the best version to experience the tool on. It's always better to stay up-to-date with these things anyway, and it may alleviate certain issues.

## The basics

It's all very straightforward, but I will give a quick explanation about everything just in case. The main thing you might notice if you've seen the tool before is that it no longer requires any installation at all! Everything is contained within the folder that you create when you unzip the tool after downloading it. So you can easily play CM between different computers without having to install it - you can just run it directly via a USB stick! Here's a few screenshots and then an explanation of everything the tool does.

#### Main Menu

<p align="left"><img src="https://i.ibb.co/fXYCPXg/MainMenu.png" alt="MainMenu" border="0"/></p>

-   **Data Updates** - This is one of the main features of the tool - you can seamlessly switch between different data updates here.
All you have to do is click on whichever one you want to use, and wait for a confirmation of it successfully loading. Then you can start a new game and hey presto it's using the data update you wanted! Massive thank you to everyone involved in all of the data updates - some of them are years and years of hard work from one person, others are 6 months of hard work from a handful of people. All of them heroes!

-   **Install VAR Commentary** - Adds VAR related commentary to the game (only for the English language). Once installed, it can easily be uninstalled by pressing the same button again. Shoutout to samsami for creating this!

-   **Nick's Patcher** - Allows you to change a few things in the game using Nick's Patcher, which has been integrated into the tool. The default settings are pre-selected when you navigate to the menu. It is a decent selection of settings for people that want to play vanilla CM with some nice changes that improve the overall experience. Big thanks to Nick for his permission to use the Patcher as part of this tool. It's an incredible piece of kit that we're all very lucky to have available to us! Shoutout to Tapani and Saturn who came before him and were the original geniuses behind the first patchers.

-   **Official Editor** - Allows you to use the official editor without having to hunt down the file and change the admin permissions or compatibility settings on it, etc. Just ensure when you load up the data that it is pointing to the Data folder within the Starter Kit, and not another version of CM 01/02 that you have on your computer!

-   **Play Game** - Allows you to play the game without faffing around with compatibility settings and admin options, and pick between just using standard CM or applying Nick's Patcher to it and running that. Do whatever makes you happy!

-   **Android** - Gives a list of instructions for getting CM 01/02 running on your Android device. I did try to automate some things but it proved harder than anticipated. However, the Starter Kit generates all the files you need, and you then manually copy them onto your device.

-   **CM Scout** - Launches CM Scout. It's a nice little tool that means you don't have to rely on your rubbish in-game scouts to find players. Most people think it ruins the game a bit though, so use with caution!

-   **Generated Player Finder** - Launches GPF2. If you run this tool against your save game as early as possible, it will keep a track on which players certain regens were in their previous life! That's pretty much all it does...

-   **Back Up Save Games** - Backs up all your save games to the following folder: 'C:\Users\YOUR_USER\Desktop\CM0102 Backups'.

-   **Restore Save Games** - Allows you to easily restore any save games that have been backed up to the above location. Please note it will overwrite any existing save games with the same name within the Starter Kit itself so be careful!

#### Data Updates

<p align="left"><img src="https://i.ibb.co/9tLH40P/Data-Updates-Menu.png" alt="Data-Updates-Menu" border="0"/></p>

You have the choice of 10 different databases on the latest version of this tool. These data updates are what keep the game fresh and enjoyable for a lot of people, so I'm chuffed to be able to include them all here. A massive thank you again to everyone who spent so much time putting these databases together for others enjoyment.

I have also added the ability to save and load your own custom databases. Previously if you made any edits to any of the databases (using the Official Editor), these changes would get overwritten the next time you loaded a different database. You can now save a database with whatever name you like, and then reload it again at any point in the future if you want to use it again. All you need to do is load the desired default database, make some changes via the editor, and then press "Save Custom Database" and give it a name. The tool will then store that database somewhere for you to re-use (and will obviously keep it as the currently loaded database as well).

As of version 1.2.2, the Custom Database functionality will allow you to load up any CM 01/02 database you like, provided it is in a zip file. So if there's a particular database you want to play that isn't on the Starter Kit, just download it from the forum for example, and then find the zip file via the Load Custom Database button. This _should_ work completely fine, provided the database you have downloaded does not have it's own executable file. Having to cater for that would have been far beyond the initial purpose of the Starter Kit, and thus is not supported! Also, another word of warning - if you load a custom database such as April 2022, and attempt to start in a year other than 2001, don't be surprised if you end up with errors. This is becase none of the "year specific patches" that Nick and other patchers have put together will be applied.

**Please note:** The April 2021 database should _not_ be started in the year 2021 - although the database has been updated up until the end of the winter transfer windows of early 2021, any fixes the tech wizards have made (for competitions, etc) were based on a 2020 starting year. Of course, you can start in 2001 as per normal so you won't have to worry about any of this! Equally, the October 2021 database _should_ be either started in 2021 or 2001 for the same reasons, and the November 2020 database in 2020 or 2001 too.

#### Nick's Patcher Menu

<p align="left"><img src="https://i.ibb.co/D4q68nQ/Nick-Patcher-Menu.png" alt="Nick-Patcher-Menu" border="0"/></p>

Most of the options here are pretty straightforward, but for those that aren't, I'll give a brief explanation.

-   **Starting Year** - It's quite obvious what this option does. However, please note that changing the start year can be prone to errors as certain magic is done in the background in order to get it working properly. If you want to take as little risk as possible, start in the year 2001 regardless as to the database you are using! Although bear in mind certain custom databases don't allow you to change the starting year, so ignore this advice in that instance. *Please note* if you have loaded the November 2020 or April 2021 databases, and want to start in the year 2020 rather than 2001, you should apply the year change and any other patches via Nick's Patcher _*before*_ editing any of the data. This is because changing the year will trigger a copy of a different dataset that includes Nick's "year specific patches" and thus the transfer windows and competition name patches. Once you've applied the patches you want, then feel free to edit the database after that point! The same goes for the October 2021 database being started in the year 2021. One last thing - once you have applied patches with the above databases and years, the year input field will become disabled due to the above extra patches and dataset being applied. If you still want to use the same database but with a different starting year, then just re-load said database from the Data Updates menu, and re-apply any patches that you want.

-   **Increase To 9 Substitutes** - All competitions should now allow 9 subs to be named, and 5 to be used.

-   **Add Regen Fixes** - Fixes a few minor things related to regens - only clubs with 45 or less players in the squad will now have regens generated (to keep AI squads free for other transfers), and it also fixes the issue of older regens (25+) being generated within smaller nations.

-   **Load All Players** - Ensures as many players from your chosen database are loaded into the game as possible, regardless as to how many leagues you select. Very useful if you normally select lots of leagues just to increase the number of available players, as having more leagues makes the game much slower. Loading all players doesn't seem to slow down performance, but it does make save game files around 25% larger. Loading all leagues also means a much higher chance of a game-breaking bug occurring at any point, so it's a nice, different option to have. Obviously if you select the "minimum database" in the game options, then all players won't load, but there will be more than there were before you had selected it! Just to confirm, some databases will have more players than the game can cope with, so in that situation using this feature will still not load every single player, but it will load as many as it can.

-   **Add Tapani Regens** - Fixes an issue where regens get an ever increasing 'Positioning' attribute, which eventually leads to very low scoring games years down the line (basically every defender becomes Maldini!). I believe it also makes changes so that regens are created to be more balanced (supposedly by default regens can generate with low physical attributes, etc - I think this patch attempts to fix that).

-   **Uncap Attributes** - Removes the upper attribute limit of 20 set in the game, allowing you to see a much more accurate value when certain players have some extremely good attributes. The values can now range from 1 to 46 (as far as I remember!). A prime example is of course Maxim Tsigalko where his Finishing attribute is actually much higher than 20 under the bonnet,  due to his low current ability and high attacking attributes.

-   **Show Hidden Attributes** - This adds a 4th column to the player attributes screen that let's you see attributes that would otherwise remain hidden. Seeing attributes such as Big Matches, Consistency, Injury Proneness and Penalties can really have a bearing on who you buy and sell!

-   **Use Miscellaneous Patches** - I have put together a collection of patches provided by Nick (including contributions from Saturn, Tapani, John Locke, xeno, et al) that I feel enhance the game quite a bit. You can either have all of them or have none of them - there's no room to list them all individually on the Starter Kit interface! I'll try to briefly describe each of them here:

    * **AiSquadStatus** - You can now see the squad status of every player from every team on each team's Squad page and from each player's Contract page.

    * **AllJobsTogether** - All available manager jobs are now grouped onto the same page. Please note this means _all_ jobs show against _every_ nation's job page. 

    * **AllowInstantSquadStatusBiddingReset** - Allows you to instantly change the squad status offered to a player you are trying to sign.

    * **AllowJanuaryTransfersInChampionsLeague** - Allows players you sign in January to be included in your Champions League squad.

    * **AllowLoansToPlayInEurope** - Allows players on loan to be able to play in European games.

    * **AllowNonEULoans** - You can now loan players from any country. Please note, this doesn't make much difference if you have already selected the "No Work Permits" option on the main patcher menu!

    * **AllowYoungAndOld** - The original game had lower and higher limits on manager/non-player ages. These days managers start younger and finish later, so this patch removes that limit.

    * **BackgroundHires** - Teams in leagues loaded in the background will hire managers where they previously didn't.

    * **BosmanCountries** - Bosman signings are now allowed in Croatia and Poland, and have been removed from Israel and Ukraine.

    * **BTeamsIncreaseTo50Players** - Teams that have B teams only have 48 players taken from the database by default. This fixes that to the normal 50 players you would get with a reserve team.

    * **ChairmanAttributes** - The ability to see the attributes of every chairman in the game. Please note this doesn't include other non-players like Managing Directors.

    * **DontRejectOffers** - The board/chairman will no longer interfere in your transfers.

    * **EnableSeasonTicketMoneyOnFirstYear** - The original game didn't give you season ticket money in the first season. This patch ensures you get season ticket revenue every year, including the first.

    * **GiveMoreOptionsInOfferDropDown** - When offering to buy players this gives more options in the dropdown so you can quickly get to the value you want to offer. It now includes: 0, 100k, 250k, 500k, 1m, 2.5m, 5m, 10m, 15m, 20m, 30m, 50m and 75m.

    * **HalveSigningOnFees** - On the original game, AI clubs were spending a significant amount of revenue just on signing-on fees, especially for contract renewals. This halves the amount players ask for in signing-on fees, putting less of a burden on the AI clubs (and your own).

    * **HideLanguageError** - Hides any error messages arising from playing the game in any non-English language.

    * **HumanManagerAttributes** - You can now see your own attributes on your Manager Profile page. These were always there in the background, but now you can see how they develop.

    * **JobsAbroadBoost** - Makes some minor changes so that you should now find it easier to get a job in a different country to the one you started in.

    * **LoadContinentalComps** - Loads all continental club competitions regardless as to what leagues you have selected.

    * **LoadPresetTactics** - Gives you the choice to use any of the default AI tactics built in to the game.

    * **LoansBoost** - Increases the likelihood of more loan deals being made in the game.

    * **LoansUpdateIncreaseLoans** - Increases the number of loans that teams in England, Scotland, Ireland and France can make at any one time from 2 to 9.

    * **ManageAnyTeam** - You can now apply for any job (club or nation) that currently does not have a manager. This includes clubs in inactive leagues. It also includes u21 teams. Please note, when applying for jobs at very small clubs or countries without enough players, you'll receive an error message (_manager_manager..cpp 12456_). Managers won't be appointed for those clubs/nations but the error is harmless beyond that.

    * **NicksFitnessPatch** - Removes the pre-defined period of the year whereby player fitness is greatly decreased.

    * **NoTransferFundCountryBias** - The percentage of bank balance available for transfer funds for teams in each nation is equal.

    * **ObsceneGestureSuspensions** - Suspensions given for players making obscene gestures will now take effect immediately instead of after 14 days. The description given for the ban now shows 'Misconduct' rather than 'Use of an illegal substance'.

    * **PageDownPatch** - You can use the Page Down key on your keyboard to go through your newsfeed rather than the mouse (please note it won't work when it comes to an item you need to action).

    * **PauseOnMinorInjury** - The game now pauses during a match for an injury, no matter the severity of an injury, including minor knocks or strains.

    * **ReduceWorkPermitWait** - Reduces the wait for a work permit application from 18-25 days to 7-14 days.

    * **RegensMegaBoost** - Regens with high potential abilities should come back with better attributes than before.

    * **RegisterForEuropeAgeIncrease** - This raises the age for which players need to be registered for European competitions from 19 to 21.

    * **ReserveSidesEnabled** - This enables reserve teams for German, Portuguese and Spanish clubs without a B team.

    * **RetirePatch** - This ensures that players will not retire until they are at least 34.

    * **RevealMatchErrors** - If you have any errors due to match engine issues, the game will attempt to tell you what the problem is (e.g. specify the team that cannot field enough players).

    * **ScoutRoleOffer** - Assistant Managers and Coaches can now be offered roles as Scouts.

    * **SeeAnyTeamFinances** - You can now see any team's finances.

    * **SeeAnyTeamTrainingFacilities** - You can now see any team's training ground level (out of 20). Please note, in any language other than English, this means that the quality description will display in English.

    * **StopYoungstersRejectingOffers** - Players younger than 18 will sometimes reject all offers no matter how famous your club is. This will disable that.

    * **TransferButtonSensitivity** - This _should_ fix the contract and transfer buttons being too sensitive and not allowing you to select the values you want to.

    * **Under21CapsNonBinding** - Players can be called up by a national team even if they have under-21 caps for another nation.

    * **UnlockYourCreativity** - This fixes a major bug in the game, where the Reflexes attribute is used for the Creativity of players with a Current Ability above 124 and intrinsic Creativity above 10.

    * **UnlockYourPotential** - This sets your own Potential Ability to 200, which I believe means you are more likely to get better job offers, the higher this attribute increases. Still haven't confirmed this myself.

If you really do want to pick and choose which of these you use, after applying the **Misc Patches**, you can go into the **Patches** folder and remove some of the files there, and they then won't be loaded by the game.

-   **Applying Protection Patches** - This functionality is no longer displayed directly in the Starter Kit, as too many people were just applying it willy nilly! So if you need to use it, manually copy it from the **Optional -> Unused** subfolder of the **Patches** folder to the **Patches** folder itself. Only use this if you are coming across error messages in your game that you cannot continue or 'holiday' past. It protects against specific crashes where the Argentinian league being loaded causes a crash, or a null pointer crash that usually occurs when all leagues are selected (which is never recommended!). There is also a fix for a "virtual_staff 195" error - if you get that error message, exit the game, apply these patches, and then when you reload the game, you should be able to continue past the error message. Like I said before, only apply these fixes if you desperately need to and cannot continue with your game otherwise.

-   **Unused Patches** - There is a subfolder of the **Patches** folder called **Unused** which contains a few minor patches that the Starter Kit never applies itself. As always, use any patches with caution. The following patches are included here:

    * **ExpiringContracts** - When searching for players whose contracts are expiring, it now only returns players who have 6 months left rather than 12 months. Useful if you only want to see players you are able to negotiate with right away.

    * **FindAllPlayers** - A lot more players are now shown in the player search results list, so you are able to find many more players based on attributes, etc. *DO NOT* use this alongside the *LoadAllPlayers* patch as it might break the game.

    * **GoldCupCrashFix** - Only one issue seems to keep cropping up on the October 2021 database when being used alongside Nick's Patcher, and that's a problem with the Gold Cup that causes error messages to occur. Use this patch to resolve this.

    * **NoComplainingAboutTrainingNewPositions** - Simply put, players will never moan about being trained in a new position.

    * **RemoveBasqueRestrictions** - Removes restrictions from any Spanish teams that can only buy Basque players.

    * **UnlimitedWages** - Allows you to offer players any amount you like on the contract screen. This is completely untested, so use with caution!

**Please note:** When certain databases are loaded, some of the options in Nick's Patcher will be disabled ("greyed out"). This is because they have already been pre-applied to that database's executable file. Therefore, they were disabled to avoid 'double patching'.

The **Apply Separate Patch** button allows you to manually load patches contained in patch files. These are basically text files (with a _.patch_ file extension), that contain the instructions used to apply different changes to the game. This can be useful, for example, if someone on the forum comes up with a patch that is not on the Starter Kit, that you think might be useful to have - you just download the patch file they have (hopefully) created, and apply it to the Starter Kit here. There may also be patch files that fix or workaround certain errors that can be applied this way too.

**PLEASE, PLEASE NOTE!!** You need to remember the exact patches that were applied when you first created a save game, and ensure no other patches are applied on top or those, or any removed, whenever you want to play that same save game. This is because you can corrupt the save quite easily when adding and removing patches, and we all hate the dreaded error messages. If necessary, just screenshot the settings on the patcher menu, and also screenshot the contents of the *Patches* folder if you have been manually removing or adding any. I won't be able to assist with any issues that have arisen due to patching problems. I've seen far too many people have problems as they have applied patches and expected them to work on existing save games - obviously some patches are fine to use on save games, but others (most of them) can kill it off!

More details about Nick's Patcher, including what each of the standard options do, can be found on the website forum here: https://champman0102.net/viewtopic.php?f=35&t=1943 and https://champman0102.net/viewtopic.php?f=72&p=5218.

#### Play Game Menu

<p align="left"><img src="https://i.ibb.co/nCctHty/PlayMenu.png" alt="PlayMenu" border="0"/></p>

This is simply where you decide whether you want to play standard CM, or you want to apply the options selected on Nick's Patcher. Please note, that the Starter Kit now detects what database you have loaded, and only allows you to select the correct options for playing, to save on any confusion.

There is now also a 'retro' option when playing the 89/90 database. If you use this it applies a few minor changes to bring the game more inline with how football was back then. The changes include old school match day shirt numbers, 5 substitutes for every competition, 3 foreign players for domestic competitions, all English finals to be played at Wembley, and a few more. Shoutout to jukilo1888 from the forum for adding these changes.

#### Android Menu

<p align="left"><img src="https://i.ibb.co/hfCvhXK/Android-Menu.png" alt="Android-Menu" border="0"/></p>

If you have used the Starter Kit before, you will notice that this page is relatively new. I wrote it in order to try to help people get up and running on their Android phone or tablet. I wanted to automate some of the process but there were a lot of restrictions on what I could do, so I had to resort to mainly just adding a list of instructions. Saying that, the tool will generate the exact files you need to copy across to your device in order to get it working. Just make sure you tick whether you want to add Nick's Patcher settings or not, and whether or not you are using Android 11 (there is a patch it adds if so). Make sure you follow the instructions as carefully as possible, but do bear in mind that Exagear Strategies (the software that gets installed on your Android device) doesn't always work on every phone - I have a Huawei P30 Pro and it doesn't work on there even though I'm on Android 10, because of the custom version of Android that they use. So don't be too disheartened if it turns out you cannot get it running!

If you already have Exagear running OK on your phone then you can skip the second part of step 4 (copying the OBB file across), and also step 5. But if anything goes wrong, it might be worth starting from scratch.

**Please note:** You cannot use the "load all players" and "change resolution to 1280x800" patches on Android as the former makes the game too slow to use, and the latter means that it doesn't display properly. If you have selected these options in Nick's Patcher, it will just ignore them when generating the files for Android.

Nick (of Nick's Patcher fame) has written up some notes on how to get Exagear Windows working on Android devices. It is a more complete solution, but as I cannot run Exagear on my phone, I'm not able to test it all out, so haven't included it on the Starter Kit. Maybe I can add a release in the future for an actual Android version! Anyway, Nick's notes can be found here, although bear in mind they are quite technical: https://champman0102.net/viewtopic.php?p=46511#p46511

## Important notes

When you are using the Starter Kit, please do not restart the game from the in-game main menu. The game will restart outside of the Starter Kit, and require you to insert the CD, etc, whereas you don't need to do this when you play the game via this tool. You will need to 'Exit Game' and then launch the game again via the Starter Kit when required.

I have fixed the language issues occurring on 3.9.60 and Luessenhoff so that you can now play these databases in many languages other than English. However, due to some poor coding in the 3.9.68 patch, unfortunately nations and nationality names will always be in English regardless. Any error messages due to language translations not working should now be suppressed so they can't be seen.

## Troubleshooting

The Starter Kit was made to limit the number of issues you get when setting CM 01/02 up. However, different setups and operating systems may result in unforeseen issues. Please have a look at the support thread for the tool (specifically the FAQ post) if you need help: https://champman0102.net/viewtopic.php?f=43&t=2449
