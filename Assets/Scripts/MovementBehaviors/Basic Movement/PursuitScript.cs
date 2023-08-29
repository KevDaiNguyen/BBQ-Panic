using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitScript : MonoBehaviour
{
    public Transform beanTarget;
    public Transform enemySeeker;

    public Rigidbody beanBody;
    public Rigidbody enemyMan;
    
    public float maxSpeed;
    public float lookAheadTime;
    public float initialMaxSpeed;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 desiredVelocity;
    private Vector3 clampedVelocity;

    // Start is called before the first frame update
    void Start()
    {
        initialMaxSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = beanTarget.position;
        currentPosition = enemySeeker.position;

        desiredVelocity = (targetPosition + (beanBody.velocity * lookAheadTime)) - currentPosition;

        desiredVelocity.Normalize();

        desiredVelocity *= maxSpeed;

        clampedVelocity = Vector3.ClampMagnitude(desiredVelocity, initialMaxSpeed);

        enemyMan.AddForce(clampedVelocity, ForceMode.Force);

        enemySeeker.LookAt(beanTarget);
    }
}
