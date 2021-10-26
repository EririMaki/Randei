# Randei
Welcome to Randei - a Raiden like 3D air crafts shooting game
The game is developed by Unity 3D

Game operation manual:
Single mode: Movement   Attack  Active_Skill    Wingman
    Player:     WASD        J       Space       Right Control

Duo mode:   Movement   Attack     Defensive_Missiles    Support_Wingman
    Player 1: WASD      J               Space                  None
    Player 2: ↑↓←→      Mouse Left      None                Right Control

How to run it within Unity and game rules:
1. You need to use Unity 2020.3.17f1
2. Go to Asset --> Scenes then you can see all used Scenes
3. Run UI Main, then you can start the game from the Main Menu page.
4. The UI Main contains the following buttons:
    Tutorial -- brings you to the tutorial mode, player can see which key they are using and practice the game play. There is no enemies in Tutorial
    Single -- brings you to the single player mode
    Duo -- brings you to the duo player mode, you can play with your friend
    Ranking -- always show your best 5 scores in descendant order. Challenge yourself in the game for higher marks!
    Operating -- is a page shows game operation manual includes Solo and Duo.
    Shop -- allows you use Coins to permanently upgrade your Air Craft Lifes, Fire Rate, Avaliable Skill Number
    Quit -- is the button to close the game
5. In any game you can press the Pause button at the right top corner, it gives you the following buttons:
    pause the game
    continue the game
    restart the current game
    switch aircraft skins
    back to main menu
    change music volum
    mute/unmute music
6. Player gain Scores and Coins by destroying enemy air crafts, different enemy type brings different scores. 
7. Game is endless, loger you play, hard the game will be. So please make sure you spend your Coins in the shop.
8. Please do not miss the buffs in the game, they always can help you.

What are those things?
1. The game contains 4 useful Scenes: UI Main(for the main menu), Randei (Solo mode), RandeiDuo (duo player mode) and Tutorial (tutorial mode)
2. Audio is in Asset --> Audio
3. All used prefabs are in Asset --> Prefabs
4. All used Scripts are in Asset --> Script, if you want to look the UI script or TDD folder, they are in Asset --> Script --> UI / Tests
5. Player progress is recorded in Asset --> Savedata --> byBin.txt, it is a binary file

Some Tips:
    Both Wingman and Defensive Missiles will consume Skill points, Wingman will exist for 20 seconds, Defensive Missiles have radial fan shaped attack (it is a good way to resist enemy bullets)
    Boss has 20 life points, your can only cause 1 damage per bullets
    Boss will open its Force Field for 3 seconds when you use any skills
