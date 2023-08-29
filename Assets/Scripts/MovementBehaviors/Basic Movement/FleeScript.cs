using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeScript : MonoBehaviour
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

        desiredVelocity.Normalize();

        desiredVelocity *= maxSpeed;

        enemyMan.AddForce(-desiredVelocity, ForceMode.Force);

        enemySeeker.LookAt(beanTarget);
    }
}
