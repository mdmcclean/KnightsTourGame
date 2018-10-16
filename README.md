# KnightsTourGame
A current side project I'm working on during my Tech Elevator bootcamp

Currently it is a CLI but I will soon be learning how to build web apps so I will take that knowledge to build it into that.

As a CLI, currently you have one knight. I will write code to add a second knight and do it as a game soon.

When the program starts you are asked to specify a board size i.e. 8 => 8x8 board. Then your initial starting position.
1,1 is the bottom left corner

Your knight will be placed at the position of your choosing. You will be given all the possible moves the knight can make
with a unique number for each possible move. The number that is yellow is your best possible move
according to the move that will let you "tour" across the whole board, touching each square once. 

Once a square is touched or landed on by the knight, you are unable to go back to that square again.

I created a CheckBestMove method algorithm that will guide you to every square once on the board if you follow that move for 
every move.

The vision is that a second knight will be added and two people will play until a player is unable to make a move
or a knight is captured. 

Needs exception handling
