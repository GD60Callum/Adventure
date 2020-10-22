Intro to programming: A2_Adventure
GD60Callum
Callum McIsaac
23/09/2020

Running:

The player can move around the 2D array map without the ability to go outside the array boundries.
The player has a health bar that can be damaged by an enemy if they do not have the sword item.
I have a sword and key item that the player picks up at specific locations just using bools.
The only way out of the while loop is to get to the escape location (2,2), or by dying.

I also got my 'walls' to funcion for the most part. If the text says you can go up or down, but the user types 'left' then you will not move.

Not Working:

When at the healing pool room for some reason you can go through the right wall even though I have my 'Locations.canGoR' (can go right) set to false at this area

