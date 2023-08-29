using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxDeath : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnRoom;

    private void OnTriggerEnter(Collider possibleBullet)
    {

        if (possibleBullet.tag == "Bullet")
        {
            enemy.transform.position = Random.insideUnitSphere * spawnRoom.GetComponent<EnemySpawning>().radius + new Vector3(810, 30, 222);
        }
    }   
}
