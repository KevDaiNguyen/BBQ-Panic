using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour
{
    public Transform enemySeeker;

    public Rigidbody enemyMan;

    public float maxSpeed;

    public float wanderAngle;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 desiredVelocity;

    private Vector3 circleTarget;
    private Vector3 circleCenter;
    private Vector2 baseCircle;

    public bool circleCheck = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (circleCheck)
        {
            circleCenter = enemySeeker.position + (enemySeeker.forward * 2);
            wanderAngle = Random.Range(-90, 90);
            baseCircle = new Vector3(Mathf.Sin(wanderAngle) * 2, 0, Mathf.Cos(wanderAngle) * 2);
            circleTarget = circleCenter + new Vector3(baseCircle.x, 0, baseCircle.y);
            circleCheck = false;
        }

        targetPosition = circleTarget;
        currentPosition = enemySeeker.position;

        desiredVelocity = targetPosition - currentPosition;

        desiredVelocity.Normalize();

        desiredVelocity *= maxSpeed;

        desiredVelocity.y = (Vector3.ClampMagnitude(desiredVelocity, 0)).y;

        enemyMan.AddForce(desiredVelocity, ForceMode.Force);

        if (Vector3.Distance(enemySeeker.position, circleTarget) < 1)
        {
            circleCheck = true;
        }
    }
}
