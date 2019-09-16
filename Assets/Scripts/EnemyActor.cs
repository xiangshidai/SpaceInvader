 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : MonoBehaviour
{
    public bool isShoot;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().detectCollisions = true;
        isShoot = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Bullet" && collision.gameObject.GetComponent<BulletController>().hasEnergy)
        {
            isShoot = true;
            collision.gameObject.GetComponent<BulletController>().hasEnergy = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    private void FixedUpdate()
    {
        if(isShoot)
        {
            GetComponent<Rigidbody>().AddForce(-Vector3.forward * 9.8f * 10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
