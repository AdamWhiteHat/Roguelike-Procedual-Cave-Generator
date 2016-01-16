# Rougelike-Procedual-Cave-Generator

![Screenshot](http://burningbunny.webs.com/ScreenShots/DungeonGenerator.png)

==================================

 http://www.csharpprogramming.tips/2013/07/Rouge-like-dungeon-generation.html
 
  This software provides procedural content generation of cave-like dungeons/maps for rouge-like games using what is known as the Cellular Automata method. 

  To understand what I mean by cellular automata method, imagine Conway's Game of Life. Many algorithms use what is called the '4-5 method', which means a tile will become a wall if it is a wall and 4 or more of its nine neighbors are walls, or if it is not a wall and 5 or more neighbors are walls. I start by filling the map randomly with walls or space, then visit each x/y position iteratively and apply the 4-5 rule. Usually this is preceded with 'seeding' the map by randomly filling each cell of the map with a wall or space, based on some weight (say, 40% of the time it chooses to place a wall). Then the automata step is applied multiple times over the entire map, precipitating walls and subsequently smoothing them. About 3 rounds is all that is required.

  One of the major problems developers run into while employing this technique is the formation of isolated caves. Instead of one big cave-like room, you may get section of the map that is inaccessible without digging through walls. Isolated caves can trap key items or (worse) stairs leading to the next level, preventing further progress in the game. I have seen many different approaches proposed to solve this problem. Some suggestions I've seen include: 1) Discarding maps that have isolated caves, filling in the isolated sections, or finely tweaking the variables/rules to reduce occurrences of such maps. None of these are ideal (in my mind), and most require a way to detect isolated sections, which is another non-trivial problem in itself.

  Despite this, I consider the problem solved because I have discovered a solution that is dead simple and almost** never fail because of the rules of the automata generation itself dictate such. I call my method 'Horizontal Blanking' because you can probably guess how it works now just from hearing the name. This step comes after the random filling of the map (initialization), but before the cellular automata iterations. After the map is 'seeded' with a random fill of walls, a horizontal strip in the middle of of the map is cleared of all walls. The horizontal strip is about 3 or 4 block tall (depending on rules). Clearing a horizontal strip of sufficient width will prevent a continuous vertical wall from being created and forming isolated caves in your maps. After horizontal blanking, you can begin applying the cellular automata method to your map.

** I say 'almost' because although it it not possible to get whole rooms that are disconnected from each other, it is possible to get tiny squares of blank space in the northern or southern walls that consist of about 4-5 blocks in total area. Often, these little holes will resolve themselves during the rounds of automata rules, but there still exists the possibility that one may persist. My answer to this edge case would be to use some rules around the placement of stairwells (and other must-find items) dictating that such objects must have a 2-3 block radius clear of walls to be placed.
