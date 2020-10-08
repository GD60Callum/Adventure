/* Copywrite (C) 2020 Callum McIsaac All Rights Reserved */

using System;

public class Program
{
    static void Main( string[] args )
    {

        Random rngHit = new Random();
        Random rngHitSword = new Random();
        Random rngHitEnemy = new Random();
        Random rngDamTaken = new Random();

      //  Console.WriteLine(rng.Next(10));

      int row = 0;
      int column = 0;

      bool bigMonster = true; //true = monster is alive
      bool smallMonster = true; //true = alive
      bool hasSword = false; //true = has the sword
      bool hasKey = false; //true = has the key

      /*
            00, 01, 02
            10, 11, 12
            20, 21, 22
      */

        Player Player = new Player( "Callum",10 );
                                            // R       L      U      D
        Locations Locations = new Locations( false, false, false, false );
    

        string[,] dungeonMap = new string[,] 
        {
            {
                "You find yourself in a damp, square room. \n Do you go right or down?", //start
                "You walk into a room filled with shallow, glowing water. \n Do you go up or down?", //heals you
                "You enter an armory room." //get sword
            },
            {
                "You enter a labratory. Potions line the wall in different colours. \n Do you go left or right?", //potions
                "You enter a strange room with ritualistic symbols painted on the floor. The room is a dead end.", //get key. can only go down
                "You enter a tight corridor." //fight weak enemy
            },
            {
                "You enter a large room with one locked door across from you.", //fight strong enemy
                "You walk up to the locked door. \n Do you go up or down?", //need key to continue
                "Through the locked door is a staircase with light beaming down from the top. \n You climb the stairs and escape the mysterious dungeon. \n Game Over" //end
            }
        };

 
            Console.WriteLine("You wake up from a deep sleep. You can't seem to remember anything but your name. \n Write your name to continue:");
            Player.name = Console.ReadLine();
            Console.WriteLine($"Your name is {Player.name}! You decide to stand up and look around.");

    while(true)
    {

        Console.WriteLine( dungeonMap[ row, column] );
        Console.WriteLine($"HP:{ Player.health }");
       
        if( column == 0 && row == 0 ) 
         { Locations.canGoD = true; Locations.canGoR = true; Locations.canGoU = false; Locations.canGoL = false;} //starter room


        if( column == 0 && row == 1 ) 
        { Locations.canGoD = true; Locations.canGoL = true; Locations.canGoR = true; Locations.canGoU = false;} // potion room


        if( column == 0 && row == 2 ) //big enemy room
        {
            Locations.canGoR = false; Locations.canGoU = false; Locations.canGoL = true; Locations.canGoD = true;

           if( bigMonster == true ) 
           {
            Console.WriteLine("A large monster approaches!\n Do you fight or go left?");
            string inputBM = Console.ReadLine();

                if(inputBM == "fight" )
                {
                    while(true)//fight enemy
                    {
                    if( hasSword == true )
                    {
                        Console.WriteLine($"You deal a devestating blow with your sword to the monster! \n You dealt { rngHitSword.Next(100) } damage!"); 
                        Console.WriteLine("You slayed the great beast! The monster falls to the ground and allows you to pass."); 
                        bigMonster = false;
                        Console.WriteLine( dungeonMap[ row, column ] );
                        Console.WriteLine($"HP:{ Player.health }");
                        Console.WriteLine("Do you go left or down?");
                    }
                    if( hasSword == false )
                    {
                        Console.WriteLine($"You punch the monster in its face!\n You dealt { rngHit.Next(5)} damage");
                        var bruh = rngDamTaken.Next(5);
                        Player.health -= bruh;
                        Console.WriteLine($"Wow. You did almost nothing to the monster with that punch. You get punched back by the monster and take { bruh } damage. Ouch!\nYou run back the way you came.");
                        row -= 1;
                        Console.WriteLine( dungeonMap[ row, column ] );
                    }
                    break;
                    }
                }
                if(inputBM == "left") //run away
                {
                    row -= 1;
                }
           
           }
        if( bigMonster == false ) //monsters dead
           {
                Console.WriteLine( dungeonMap[ row, column ] );
                Console.WriteLine($"HP:{ Player.health }");
                Console.WriteLine("Do you go left or down?");
           }
        }

           if( column == 1 && row == 0 && Player.health < 10)//healing pool
         {
             Locations.canGoD = true; Locations.canGoU = true; Locations.canGoR = false; Locations.canGoL = false;
             Player.health = 10;
             Console.WriteLine("You walk into a room filled with shallow, glowing water. You decide to swim in the water...\nThe glowing water healed you back to full health!");
             Console.WriteLine($"HP:{ Player.health }");
         }

          if( column == 1 && row == 1 ) //pick up key
         {
             Locations.canGoD = true; Locations.canGoU = false; Locations.canGoR = false; Locations.canGoL = false;

             if( hasKey == false )
             {
                  Console.WriteLine("You pick up a Key laying in the center of the room.");
                  hasKey = true;
             }
            
             Console.WriteLine("You can only go down.");
         }

             if( column == 1 && row == 2) //key door
         {
             if( hasKey == true)
             {
                 Console.WriteLine("You place your key into the lock and it turns. \n Do you go up or down?");
                 Locations.canGoD = true; Locations.canGoU = true; Locations.canGoR = false; Locations.canGoL = false;
             }
             if( hasKey == false)
             {
                 Console.WriteLine("You cannot pass through without a key.\n You can only go up.");
                 Locations.canGoD = false; Locations.canGoU = true; Locations.canGoR = false; Locations.canGoL = false;
             }
         }

          if( column == 2 && row == 0 ) //armory
        {

            Locations.canGoU = true; Locations.canGoD = false; Locations.canGoR = true; Locations.canGoL = false;
            if( hasSword == false )//get sword
            {
             Console.WriteLine("You pick up a sword that was laying agaist the back wall.");
             hasSword = true;
            }
            Console.WriteLine("Do you go up or right?");
        }

         if( column == 2 && row == 1 )//small enemy room
         {
           Locations.canGoU = false; Locations.canGoD = false; Locations.canGoR = true; Locations.canGoL = true;

             if( smallMonster == true && hasSword == true )
             {
                  Console.WriteLine("A monster approaches!\n Do you fight or go left?");
            string inputSM = Console.ReadLine();

            if( inputSM == "fight" )
            {
                   Console.WriteLine($"You deal a devestating blow with your sword to the monster! \n You dealt { rngHitSword.Next(50)} damage!"); 
                   Console.WriteLine("You slayed the beast! The monster falls to the ground and allows you to pass."); 
                   smallMonster = false;
                   Console.WriteLine( dungeonMap[ row, column] );
                   Console.WriteLine("Do you go left or up?");
            }
              if(inputSM == "left") //run away
                {
                    row -= 1;
                    Console.WriteLine( dungeonMap[ row, column ] );
                }
             }
           
         }
        
         if( column == 2 && row == 2 ) //end
         {
             Console.WriteLine( dungeonMap[ row, column] );
             break;
         }

   if( Player.health < 0) //death
     {
         Console.WriteLine("You died.");
         break;
     }
    
        Console.WriteLine("Input below:"); //player movement

        string input = Console.ReadLine();
        if(input == "up" && column > 0 && Locations.canGoU == true)
        {
            column -= 1;
        } else if( input == "down" && column < 2 && Locations.canGoD == true)
        {
            column += 1;
        } else if( input == "right" && row < 2 && Locations.canGoR == true)
        {
            row += 1;
        } else if( input == "left" && row > 0 && Locations.canGoL == true)
        {
            row -= 1;
        }
       

  
    }



    }


}