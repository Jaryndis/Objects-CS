using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int Score;
    // Start is called before the first frame update
    void Start()
    {

    Player player = new Player();

    //create 2 enemy
    Enemy enemy1 = new Enemy();
    Enemy enemy2 = new Enemy();

    //create weapons
    Weapon gun1 = new Weapon("Gun", 25);
    Weapon gun2 = new Weapon("Assault Rifle", 50);
    Weapon machineGun = new Weapon("Machine Gun", 100);
    
    
    }
}