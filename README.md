# Overview

Game Name: Holes Are Bad

We wanted to create a game that would challenge the way a player thinks. For instance, in our game, if the player runs over spikes, 
they will gain more lives. Whereas in most games, spikes would damage the player. However, we didn't want to make things too simple
by merely flipping all "bad" things to be good and all "good" things to be bad. Some things still behave how the player would expect. 
Our enemies are still bad, like they are in any other game.  By not doing a straight good to bad and bad to good flip, we force the
player to think and experiment with new concepts.

The goal of the game is to collect a certain amount of collectables while avaiding holes, enemies, and other dangerous objects.
There are platform the player will move around on to progress through the game.  However, despite looking exaclty the same, not all
platforms are solid and the player will fall through them. The map segments for level 1 have different "weights" for how frequently
they will be generated.  As such, every instance of a level will be relativley unique to keep it more interesting.

When starting this project, most of our team was not familiar with C#. We all had a lot to learn before we could even get started.
As we learned more C#, the progress rate of our project increased. Due to our slower start, we opted to prioritieze functionallity over
organization with our code. Currently, we still have some organization, but we would like to make it simpler and split some of the
larger files into many smaller files.

However, thanks to this approach, we were able to acomplish all of our initial requirements except for graphic animations. For the
sake of completing other requirements, we pushed off animations. We created all our graphics froms scratch except for the background.
Drawing multiple frames to make animations possible is time consuming. We merely ran out of time to finish and implement animations,
though, we intend to continue working and implement animations in the future. As we worked on the profect, we kept a list of additional
ideas that we wanted to include. Even though we ended up not adding animations, we were able to implement slightly more than 2/3 of our 
additional ideas.

[Software Demo Video](http://youtube.link.goes.here)


# Development Environment

* Language: C#
* IDE: Visual Studio Code
* Library 1: Raylib-cs
* Library 2: WeightedRandomizer


# Collaborators

Olivia Richards, Jake Zakensy, Ben Heydorn, Nicholas Boss, Mark Van Horn, and Mike Heston


# Useful Websites

* [Weighted Randomizer Library](https://github.com/BlueRaja/Weighted-Item-Randomizer-for-C-Sharp/wiki/Getting-Started)
* [Raylib C# Library](https://github.com/ChrisDill/Raylib-cs)
* [Piskel](https://www.piskelapp.com/)
* [Itch](https://itch.io/)
* [w3schools](https://www.w3schools.com/cs/index.php)
* [Trello](https://trello.com/b/mX1blFSI/team-project-01)


# Future Work

* 'Cast' Animations (individual player and enemy movements)
* Create Level 2 with different background and map segments
* Better organize code and clean up files
