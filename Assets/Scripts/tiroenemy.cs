using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroenemy : MonoBehaviour
{
    public GameObject explosion;
    private PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject exp = Instantiate(explosion, collision.transform);
            Destroy(collision.gameObject);
            Destroy(exp, 0.1f);
        }

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject exp = Instantiate(explosion, collision.transform);
            
            PC.playerLife--;
            Destroy(exp, 0.4f);
            Destroy(this.gameObject);
        }

    }

}
