using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveScript : MonoBehaviour
{
    public Transform beanTarget;
    public Transform enemySeeker;

    public Rigidbody enemyMan;

    public float maxSpeed;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 desiredVelocity;



    // Start is called before the first frame update
    void Start()
    {
        targetPosition = beanTarget.position;
        currentPosition = enemySeeker.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = beanTarget.position;
        currentPosition = enemySeeker.position;

        desiredVelocity = targetPosition - currentPosition;

        if (Vector3.Distance(targetPosition, currentPosition) > 10)
        {
            maxSpeed = 11;
        }
        else if (Vector3.Distance(targetPosition, currentPosition) > 5)
        {
            maxSpeed = 8;
            
            //Apply slow down
            
            desiredVelocity.Normalize();

            desiredVelocity *= ((maxSpeed * 2) * 0.7f);

            enemyMan.AddForce(-desiredVelocity, ForceMode.Force);
        }
        else
        {
            maxSpeed = 7;
        }

        desiredVelocity.Normalize();

        desiredVelocity *= maxSpeed;

        enemyMan.AddForce(desiredVelocity, ForceMode.Force);

        enemySeeker.LookAt(beanTarget);
    }
}
