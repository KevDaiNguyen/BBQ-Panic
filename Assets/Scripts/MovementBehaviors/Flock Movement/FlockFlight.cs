using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlockFlight : MonoBehaviour
{

    // Self Reference
    public Rigidbody fishBody;
    public Transform fishTransform;
    public GameObject fishObject;

    public GameObject[] fishList;

    public float fishSight;
    public float maxSpeed;
    public int fishSelfNum;

    public Vector3 currentFishPos;

    public float cohesionWeight;
    public float separationWeight;
    public float alignmentWeight;

    private float[] closestFish = new float[30];

    // Target Fish
    public Vector3 closestFishPos;

    public string targetFishName;
    public Vector3 fishTarget;

    // Velocities
    public Vector3 sumOfForces;
    public Vector3 externalForce;

    public Vector3 desiredVelocity;

    private Vector3 alignmentVector;
    private Vector3 cohesionVector;
    private Vector3 separationVector;

    public GameObject flockSpawner;


    private void Start()
    {
        fishList = GameObject.FindGameObjectsWithTag("Fish");
        for (int i = 29; i > 0; i--)
        {
            closestFish[i] = 99999;
        }
    }

    // Update is called once per frame
    void Update()
    {

        alignmentVector = AlignmentVector(fishList);
        cohesionVector = CohesionVector(fishList);
        separationVector = SeparationVector(fishList);

        alignmentVector -= fishBody.velocity;
        alignmentVector.Normalize();

        sumOfForces = (1.05f * (alignmentVector * alignmentWeight)) + (0.90f * (cohesionVector * cohesionWeight)) + (1.05f * (-separationVector * separationWeight));

        sumOfForces.Normalize();

        sumOfForces *= maxSpeed;

        fishBody.AddForce(sumOfForces, ForceMode.Force);
        fishBody.AddForce(externalForce, ForceMode.Force);

        fishTransform.LookAt(closestFishPos);
    }


    public Vector3 AlignmentVector(GameObject[] importFish)
    {
        Vector3 totalAlign = Vector3.zero;
        Vector3 alVector = Vector3.zero;

        int fishCount = 0;

        for (int i = 0; i < 30; i++)
        {
            float currentDistance = Vector3.Distance(importFish[i].GetComponent<Rigidbody>().position, fishBody.position);

            if (currentDistance > 0 && currentDistance < fishSight)
            {
                totalAlign += (importFish[i].GetComponent<Rigidbody>().velocity);
                fishCount++;
            }

            if (fishCount > 0)
            {
                 alVector = totalAlign/fishCount;
            }
        }
 
        return alVector;
    }
    public Vector3 CohesionVector(GameObject[] importFish)
    {
        for (int i = 29; i > 0; i--)
        {
            if (Vector3.Distance(fishBody.position, fishList[i].GetComponent<Transform>().position) < closestFish[i])
            {
                closestFish[i] = Vector3.Distance(fishTransform.position, fishList[i].GetComponent<Transform>().position);
                closestFishPos.Set(fishList[i].GetComponent<Transform>().position.x, fishList[i].GetComponent<Transform>().position.y, fishList[i].GetComponent<Transform>().position.z);
                targetFishName = fishList[i].name;
            }
        }

        fishTarget = closestFishPos;
        currentFishPos = fishTransform.position;

        desiredVelocity = fishTarget - currentFishPos;

        desiredVelocity.Normalize();

        return desiredVelocity;
    }
    public Vector3 SeparationVector(GameObject[] importFish)
    {
        for (int i = 29; i > 0; i--)
        {
            if (Vector3.Distance(fishBody.position, fishList[i].GetComponent<Transform>().position) < closestFish[i])
            {
                closestFish[i] = Vector3.Distance(fishTransform.position, fishList[i].GetComponent<Transform>().position);
                closestFishPos.Set(fishList[i].GetComponent<Transform>().position.x, fishList[i].GetComponent<Transform>().position.y, fishList[i].GetComponent<Transform>().position.z);
                targetFishName = fishList[i].name;
            }
        }

        fishTarget = closestFishPos;
        currentFishPos = fishTransform.position;

        desiredVelocity = fishTarget - currentFishPos;

        desiredVelocity.Normalize();

        return desiredVelocity;
    }


}
