using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletSpawning : MonoBehaviour
{
    public GameObject beanBullet;
    public GameObject cameraPointer;

    public float despawnTime;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletInstance = Instantiate(beanBullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<Rigidbody>().AddForce(cameraPointer.GetComponent<Transform>().forward * 3500, ForceMode.Acceleration);

            StartCoroutine(BulletDespawn(despawnTime, bulletInstance));
        }
    }

    public IEnumerator BulletDespawn(float time, GameObject bullet)
    {
        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}
