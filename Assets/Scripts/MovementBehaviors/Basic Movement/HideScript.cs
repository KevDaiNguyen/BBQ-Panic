using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    public GameObject[] obstacleList;

    public Transform beanTarget;
    public Transform enemySeeker;

    public Rigidbody beanBody;
    public Rigidbody enemyMan;

    public float maxSpeed;
    
    public float lookAheadTime;
    public float initialMaxSpeed;
    public float hidingDistanceNum;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Vector3 desiredVelocity; 
    private Vector3 clampedVelocity;

    public Vector3 hidingDistance;
    public Vector3 furtestSpot;
 
    public Vector3[] hidingSpots;
    public Vector3 bestHideSpot;

    // Start is called before the first frame update
    void Start()
    {
        obstacleList = GameObject.FindGameObjectsWithTag("Obstacle");
        Debug.Log(obstacleList);
        hidingSpots = new Vector3[obstacleList.Length];
        targetPosition = beanTarget.position;
        currentPosition = enemySeeker.position;
        bestHideSpot = Vector3.zero;
        furtestSpot = Vector3.zero;
        hidingDistance = new Vector3(hidingDistanceNum, 0, hidingDistanceNum);
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = beanTarget.position;
        currentPosition = enemySeeker.position;
        


        for (int i = 0; i < obstacleList.Length; i++)
        {
            hidingSpots[i].Set(
                (obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).x, 
                (obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).y, 
                (obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).z);

            if (Vector3.Distance((obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance), targetPosition) > Vector3.Distance(furtestSpot, targetPosition))
            {
                furtestSpot.Set((obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).x,
                (obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).y,
                (obstacleList[i].GetComponent<Transform>().position + (obstacleList[i].GetComponent<Transform>().position - targetPosition).normalized + hidingDistance).z);
            }

            if (Vector3.Distance(hidingSpots[i], furtestSpot) > Vector3.Distance(bestHideSpot, targetPosition))
            {
                bestHideSpot.Set(hidingSpots[i].x, hidingSpots[i].y, hidingSpots[i].z);
            }
        }

        desiredVelocity = bestHideSpot - currentPosition;

        desiredVelocity.Normalize();

        desiredVelocity *= maxSpeed;

        clampedVelocity = Vector3.ClampMagnitude(desiredVelocity, initialMaxSpeed);

        clampedVelocity.y = 0;

        enemyMan.AddForce(clampedVelocity, ForceMode.Force);
    }

    // calculate all possible hiding positions
    // anchor obstacle (add movment vector to obstacle position)
    // hiding psotion = obstactle position + (obstacle position - target position).normalize + c
    // add all positions into a list of all hiding positions
    //     for each position
    //        vector3.distance(target distance, enemydistance)

    // Start is called before the first frame update
}
