using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemySpawn;
    public Transform spawnerBlock;
    public Rigidbody targetBody;
    public Transform target;
    public int radius;
    public int spawnAmount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = spawnAmount; i > 0; i--)
        {
            spawnEnemies(i);
        }
     
    }



    public void spawnEnemies(int enemyNum)
    {
        GameObject enemy = Instantiate(enemySpawn, (Random.insideUnitSphere * radius) + spawnerBlock.position, Quaternion.identity);
        EstablishTarget(enemy);
        enemy.name = "Grillmaster " + enemyNum.ToString();
    }

    public void EstablishTarget(GameObject enemy)
    {
        enemy.GetComponent<SeekScript>().beanTarget = target;

        enemy.GetComponent<PursuitScript>().beanTarget = target;
        enemy.GetComponent<PursuitScript>().beanBody = targetBody;

        enemy.GetComponent<FleeScript>().beanTarget = target;

        enemy.GetComponent<HideScript>().beanTarget = target;
        enemy.GetComponent<HideScript>().beanBody = targetBody;

        enemy.GetComponent<EvadeScript>().beanBody = targetBody;
        enemy.GetComponent<EvadeScript>().beanTarget = target;

        enemy.GetComponent<ArriveScript>().beanTarget = target;

    }
}
