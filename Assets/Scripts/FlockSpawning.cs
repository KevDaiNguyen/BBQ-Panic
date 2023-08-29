using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlockSpawning : MonoBehaviour
{
    public GameObject fishSpawn;
    public int radius;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 30; i > 0; i--)
        {
            spawnEnemies(i); 
        }
    }
    
    public void spawnEnemies(int fishNameNumber)
    {
        GameObject fishName = Instantiate(fishSpawn, Random.insideUnitSphere * radius + (transform.position + new Vector3(-75, 0 ,0)), new Quaternion(0,90,90,0));
        fishName.name = "Fish " + fishNameNumber.ToString();
        fishName.GetComponent<FlockFlight>().externalForce = new Vector3(Random.Range(-2, 2), Random.Range(-3, -1), -5);
        fishName.GetComponent<FlockFlight>().fishSelfNum = fishNameNumber;
    }
}
