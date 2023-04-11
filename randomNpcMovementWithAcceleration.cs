using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNpcMovementWithAcceleration : MonoBehaviour
{
    public float baseSpeed;
    //the range in which you can get of your destination
    public float range;
    float velocity;
    public double acceleration = 1;
    public double baseAcceleration;
    //current distance from sprite to desination
    float destinationDistance;
    //total distance from sprite to destination when setting a new destination
    float totalDestinationDistance;
    public float maxDistance;
//    bool newDestinationSet = false;
    public float maxVelocity;


    Vector2 wayPoint;
    // Start is called before the first frame update
    void Start()
    {
        setNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        destinationDistance = Vector2.Distance(transform.position, wayPoint) - range;

        if (acceleration < baseAcceleration)
        {
            acceleration = baseAcceleration;
        }
        velocity = baseSpeed * (float)acceleration;
        if (velocity > maxVelocity)
        {
            velocity = maxVelocity;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, velocity * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            setNewDestination();
            

        }

        //acceleration calculation 
        else if (totalDestinationDistance/2 < destinationDistance)
        {
            acceleration += .004;
        }
        else if (2*totalDestinationDistance/3 > destinationDistance)
        {
            acceleration -= .004;
        }

    }

    void setNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
      //  newDestinationSet = true;
        totalDestinationDistance = destinationDistance = Vector2.Distance(transform.position, wayPoint) - range;
        acceleration = baseAcceleration;
    }

}
