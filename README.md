# Card-Game
CMP1903M – Object Oriented Programming – Assessment 3

Command line game. Showing OOP concepts in C#.

# How it works
* PvP 
* PvC (Player v Computer)
* Pack is shuffled
* Each player receives 10 cards
* Each player plays 2 cards
* Player with the highest total wins hand, then plays first in the next round
* Card values are: 2,3,4,5,6,7,8,9,10,J(11),Q(12),K(13),A(14)
  * eg: P1 plays (8,Q) total=20, P2 plays (5,K) total=18, P1 wins hand

Notes:
* If totals are the same, continue to the next hand. Winning player gets both hands
* Player with the highest number of hands wins, wins the game
* If the number of hand wins is the same, draw a random card from the remaining cards - highest wins
* If the final hands are the same value, draw a random card from the remaining cards - highest wins the hand. 

# Concepts
Used:
* Object-oriented features such as classes, object instantiation, encapsulation and methods
* Inheritance/interface alongside access modifiers
* Static polymorphism (method/operator overloading)
* Appropriate class structure

Additonal:
* Black box testing
* Input validation
