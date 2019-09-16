using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject explosionAsteriod;
    public GameObject explosionEnemy;
    public EnemyController enemyC;
    

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        enemyC = GameObject.Find("/Enemies").gameObject.GetComponent<EnemyController>();
        hasEnergy = true;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 9 || transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    public bool hasEnergy = true;

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Enemy" && hasEnergy)
        {
            GetComponent<Rigidbody>().useGravity = true;
            enemyC.GetComponent<EnemyController>().enemyShot.Play(0);



            GameController.score += 10;
        }
        if (other.gameObject.tag == "Bonus" && hasEnergy)
        {
            Instantiate(explosionAsteriod, other.gameObject.transform.position, other.gameObject.transform.rotation);
            enemyC.asteriodExplosion.Play(0);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameController.score += 30;
        }
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
   
}
