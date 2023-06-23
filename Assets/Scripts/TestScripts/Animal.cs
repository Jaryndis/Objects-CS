using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public virtual void AnimalSound()
    {
        print("General animal sound");
    }

    public abstract void Move();
}


public class Dog : Animal
{
    public override void Move()
    {
        print("Dog is moving");
    }

    public override void AnimalSound()
    {
        print("Bark");
    }
}
