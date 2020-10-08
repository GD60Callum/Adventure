/* Copywrite (C) 2020 Callum McIsaac All Rights Reserved */

using System;

public class Player
{
    //health, postion
    public string name;
    public int health = 10;

    public Player(string name, int health)
    {
        this.name = name; 
        this.health = health;
    }

    //damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        Console.WriteLine($"{name} took {damage} damage!");
    }
    
    public void HealUp(int heal)
    {
        health += heal;
        Console.WriteLine($"{name} healed {heal} HP!");
    }
}