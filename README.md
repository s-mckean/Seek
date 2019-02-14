# Seek

Goal: Find all of the objects hidden in another dimension

Press the RIGHT MOUSE BUTTON to see into the other dimension

Press the LEFT MOUSE BUTTON to spawn a platform

Press the ESC key to exit the game

Make sure to conserve your energy

# Gameplay Demo

![Image](https://user-images.githubusercontent.com/42820224/51708355-997cca00-1fd8-11e9-89e4-5dc1dd71e700.gif)

To download just the game or view the full demo video use this link:

https://drive.google.com/drive/folders/1OiCPi49hI-onYprqd-TiX3vEKE3E33ED?usp=sharing

Note: The entire "Game Download" folder must be downloaded in order to play

## File Structure

	README.md				-README

	Assets					-Folder for created Unity assets
	  -> Materials				-Folder containing Unity materials
	    -> Blue.mat				-Created blue color
	    -> Green.mat			-Created green color
	    -> Tranparent.mat			-Created transparent color

	  -> Prefabs				-Folder containing prefabs of Unity game objects
	    -> Collectable Cube.prefab		-Prefab for the cubes that are collected in the game
	    -> Platform.prefab			-Prefab for the platforms that are created by the player

	  -> Scripts				-Folder for C# scripts used in the project
	    -> CollectableScript.cs		-C# script to allow the player to collect
	    -> DeadZone.cs			-C# Script to reset the player when they fall into the area
	    -> GameManager.cs			-C# Script to control win and lose conditions and energy bar functions
	    -> MenuScript.cs			-C# Script to control menu start button
	    -> PlayerScript.cs			-A default unity asset for a 3d player controller

	  -> Standard Assets			-Folder containing default unity assets

	  -> Intro.unity			-Intro Unity scene for directions
	  -> Main.unity				-Unity scene where the entire game is played

	Seek Executables			-Folder containing the executable and everything necessary to run the game as is

	ProjectSettings				-Folder containing assets created by Unity
	UnityPackageManager			-Folder containing assets created by Unity

