using System;
using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour
{

    public float acceleration;
    public float speed;
    public float angleSpeed;
    public float angle = 0.0f;

	// Use this for initialization
	void Start ()
	{
	    acceleration = 10.0f;
	    speed = 0.0f;
	    angleSpeed = 100.0f;
	}

    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration*Time.deltaTime;
        }
        else if(speed > 0)
        {
            speed -= acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= acceleration*Time.deltaTime;
        }
        else if(speed < 0)
        {
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle -= Time.deltaTime * angleSpeed;
            transform.localRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle += Time.deltaTime * angleSpeed;
            transform.localRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        transform.localPosition += (transform.forward * speed * Time.deltaTime);
    }

    
}
