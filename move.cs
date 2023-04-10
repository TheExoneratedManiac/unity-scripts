using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      distance = (Math.Abs(mousePosition.x - transform.position.x) + Math.Abs(mousePosition.y - transform.position.y)) / 2;
      if (distance > maxDistance)
      {
        distance = maxDistance;
      }
      transform.position = Vector2.MoveTowards(transform.position, mousePosition, distance * moveSpeed * Time.deltaTime);

    }
}
