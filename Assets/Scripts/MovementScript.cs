using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform footObject;
    public float footRadius = 0.2f;
    public LayerMask floorlayers;

    public float leftRight, frontBack;
    public float moveSpeed = 0.2f;

    public float jumpingPower = 15;
    public bool groundCheck;

    private bool jumpCall;
    private Rigidbody rigiComponent;

    public Transform cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        rigiComponent = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = Physics.CheckSphere(footObject.position, footRadius, floorlayers);
        

        leftRight = Input.GetAxis("Horizontal");
        frontBack = Input.GetAxis("Vertical");

        if (!jumpCall && Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            jumpCall = true;
        }
    }

    private void FixedUpdate()
    {
        rigiComponent.AddForce((frontBack * moveSpeed * cameraObject.forward + leftRight * moveSpeed * cameraObject.right) , ForceMode.Force);
        

        if (jumpCall)
        {
            rigiComponent.AddForce(new Vector3(0, jumpingPower, 0), ForceMode.Impulse);
            rigiComponent.GetComponent<ConstantForce>().force = new Vector3(0, -30, 0);
            jumpCall = false;
            StartCoroutine(GravityForce(0.5f));
        }
    }

    public IEnumerator GravityForce(float time)
    {
        yield return new WaitForSeconds(time);
        rigiComponent.GetComponent<ConstantForce>().force = new Vector3(0, -15, 0);
    }
}
