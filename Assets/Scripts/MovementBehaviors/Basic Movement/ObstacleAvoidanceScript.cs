using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidanceScript : MonoBehaviour
{
    public float enemySight;

    public Transform enemySeeker;
    public Rigidbody enemyMan;

    public Vector3 laserTarget;
    public Vector3 targetDirection;
    public RaycastHit laserHit;
    
    private Vector3 leftRaycast;
    private Vector3 rightRaycast;

    private Vector3 previousVelocity;

    public float maxSpeed;
    public Vector3 desiredVelocity;

    // Start is called before the first frame update
    void Start()
    {
        previousVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    { 

        leftRaycast.Set(previousVelocity.x - enemyMan.velocity.x, 0, previousVelocity.z - enemyMan.velocity.z);
        rightRaycast.Set(previousVelocity.x - enemyMan.velocity.x, 0, previousVelocity.z - enemyMan.velocity.z);

        //Debug.DrawRay(enemySeeker.position, enemyMan.velocity, Color.green, 1);

        Debug.DrawRay(enemySeeker.position + new Vector3(1,0.2f, -1), leftRaycast, Color.red, 5);
        Debug.DrawRay(enemySeeker.position + new Vector3(-1,0.2f, -1), rightRaycast, Color.blue, 5);

        Ray leftRaything = new Ray(enemySeeker.position + new Vector3(2, 0.2f, -1), leftRaycast);
        Ray rightRayThing = new Ray(enemySeeker.position + new Vector3(-2, 0.2f, -1), rightRaycast);

        RaycastHit laserHit;

        if (Physics.Raycast(leftRaything, out laserHit, enemySight))
        {
            laserTarget = laserHit.transform.position;
            Debug.Log(laserTarget);

            targetDirection = laserTarget - (enemySeeker.position + new Vector3(2, 0.2f, -1));

            desiredVelocity = targetDirection - leftRaycast;

            desiredVelocity.Normalize();

            desiredVelocity *= maxSpeed;

            enemyMan.AddForce(desiredVelocity, ForceMode.Force);
        }
        
        if (Physics.Raycast(rightRayThing, out laserHit, enemySight))
        {
            laserTarget = laserHit.transform.position;
            Debug.Log(laserTarget);

            targetDirection = laserTarget - (enemySeeker.position + new Vector3(-2, 0.2f, -1));

            desiredVelocity = targetDirection - rightRaycast;

            desiredVelocity.Normalize();

            desiredVelocity *= maxSpeed;

            enemyMan.AddForce(targetDirection - rightRaycast, ForceMode.Force);
        }

    }

    private void LateUpdate()
    {
        previousVelocity = enemyMan.velocity;
    }

    // ((hit.point - transform. position) - velocity ) * max obstacle force
}
