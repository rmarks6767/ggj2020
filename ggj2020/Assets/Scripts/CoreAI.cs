using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreAI : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moveRight;
    private bool moveLeft;
    private bool stop;
    public int speed;
    private GameObject roomCenter;
    public int wanderRange;

    void Start()
    {
        stop = true;
        moveRight = false;
        speed = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        if (stop)
        {
            speed = 0;
        }
        else if (moveRight)
        {
            gameObject.transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else if (moveLeft)
        {
            gameObject.transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    } 
    public void Stop()
    {
        stop = true;
        moveRight = false;
        moveLeft = false;
    }
    public void MoveRight()
    {
        stop = false;
        moveRight = true;
        moveLeft = false;
    }

    public void MoveLeft()
    {
        stop = false;
        moveRight = false;
        moveLeft = true;
    }

    public void MoveTo(Vector3 positionGo)
    {
        if((gameObject.transform.position.x - positionGo.x) < 2)
        {
            gameObject.transform.position = positionGo;
            Stop();
        }
        else
        {
            if (gameObject.transform.position.x < positionGo.x)
            {
                MoveRight();
            }
            else if (gameObject.transform.position.x > positionGo.x)
            {
                MoveLeft();
            }
        }
        
    }

    public void Wander()
    {
        if((transform.position.x - roomCenter.transform.position.x) > wanderRange)
        {
            MoveLeft();
        }
        if ((transform.position.x) < -wanderRange)
        {
            MoveRight();
        }
    }
}
