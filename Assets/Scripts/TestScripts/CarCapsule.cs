using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCapsule : MonoBehaviour
{
    private string make;
    private string model;
    private int year;
    private float speed;

    public CarCapsule(string _make, string _model, int _year)
    {
        make = _make;
        model = _model;
        year = _year;

        speed = 0;
    }

    public string Make
    {
        get { return make; }
        set{ make = value; }
    }

    public string Model
    {
        get { return make; }
        set { make = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Acceleration(float acceleration)
    {
        speed += acceleration;
    }

    public void Brake(float deceleration)
    {
        speed -= deceleration;

        if (speed < 0)
        {
            speed = 0;
        }
    }
}
