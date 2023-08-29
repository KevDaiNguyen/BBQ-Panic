using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatcher : MonoBehaviour
{
    public GameObject fishSpawner;

    private void OnTriggerEnter(Collider fish)
    {

        fish.gameObject.transform.position = Random.insideUnitSphere * fishSpawner.GetComponent<FlockSpawning>().radius + (fishSpawner.transform.position + new Vector3(-75, 0, 0));
    }
}
