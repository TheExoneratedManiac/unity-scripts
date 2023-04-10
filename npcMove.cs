using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove : MonoBehaviour
{
    public double moveSpeed;
    public int counter = 1;
    public int lastRan;
    public double maxMoveSpeed = 8.0;
    public int roundedMoveSpeed;
    public int timeSinceIncrease = 0;
    public int acceleration;
    public bool directionChange = false;
    public int timeSinceDirectionChange = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Random.Range(0,2000);
        if (counter % 2000 == 0 && timeSinceDirectionChange > 100)
        {
            timeSinceDirectionChange = 0;
            //direction changes
         int ran = Random.Range(0,4);
          if (ran == 0)
          {
             goUp();
             lastRan = 0;
             moveSpeed = 3;
           }
           else if (ran == 1)
            {
             goRight();
             lastRan = 1;
             moveSpeed = 3;
            }
           else if (ran == 2)
         {
             goLeft();
             lastRan = 2;
             moveSpeed = 3;
         }
           else if (ran == 3)
         {
             goDown();
             lastRan = 3;
             moveSpeed = 3;
             
         }
        }
        else
        {
            //direction doesn't change
            timeSinceDirectionChange++;
            if (moveSpeed < maxMoveSpeed && timeSinceIncrease == acceleration)
            {
                moveSpeed = moveSpeed + .2;
                timeSinceIncrease = 0;
            }
            else if (timeSinceIncrease > acceleration)
            {
                timeSinceIncrease = 0;
            }
            else
            {
                timeSinceIncrease++;
            }
            if (lastRan == 0)
            {
                goUp();
            }
            else if (lastRan == 1)
            {
                goRight();
            }
            else if (lastRan == 2)
            {
                goLeft();
            }
            else if (lastRan == 3)
            {
                goDown();
            }
        }
        roundedMoveSpeed = (int)(moveSpeed + .5);

    }
    void goUp()
    {
        transform.Translate(Vector2.up * roundedMoveSpeed * Time.deltaTime);
    }
    void goRight()
    {
        transform.Translate(Vector2.right * roundedMoveSpeed * Time.deltaTime);
    }
    void goLeft()
    {
        transform.Translate(Vector2.left * roundedMoveSpeed * Time.deltaTime);
    }
    void goDown()
    {
        transform.Translate(Vector2.down * roundedMoveSpeed * Time.deltaTime);
    }
}
