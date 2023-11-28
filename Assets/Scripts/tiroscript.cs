using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroscript : MonoBehaviour
{
    //public float angleBetween = 0.0f;
    //public Transform Transf;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        //Transf = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetDir = Transf.position - transform.position;
        //angleBetween = Vector3.Angle(transform.forward, targetDir);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject exp = Instantiate(explosion, collision.transform);

            if (collision.GetComponent<enemy>().tutoEnemy == true)
            {
                Destroy(collision.gameObject);
            }

            if (collision.GetComponent<enemy>().tutoEnemy == false)
            {
                collision.gameObject.GetComponent<enemy>().life--;
            }

            

            //Destroy(collision.gameObject);
            Destroy(exp,0.5f);
        }
         
    }
}
