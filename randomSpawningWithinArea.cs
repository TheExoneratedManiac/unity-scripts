using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawningWithinArea : MonoBehaviour
{
    private int randX;
    private int randY;
    public int xMax;
    public int yMax;
    public int xMin;
    public int yMin;

    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(xMin, yMin);
        randY = Random.Range(yMin, yMax);
        transform.position = new Vector3((float)randX, (float)randY, (float)0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
