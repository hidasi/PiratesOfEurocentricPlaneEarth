using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject explosion;
    public bool tutoEnemy;
    private SpriteRenderer SR;
    public int life = 2;
    private int chaser1shooter2;
    public AudioSource cannon;
    public float ballSpeed = 15;

    public Sprite ChaserSRSprite1;
    public Sprite ChaserSRSprite2;
    public Sprite ChaserSRSprite3;

    public Sprite ShooterSRSprite1;
    public Sprite ShooterSRSprite2;
    public Sprite ShooterSRSprite3;

    public Transform FirePoint;
    public GameObject shotenemyPrefab;

    public Transform target, tgt;
    public Transform playerTarget, ptgt;
    public float speed = 4f;

    private float timer;
    public float timeshoot = 4f;

    public PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        cannon = FindObjectOfType<audio>().gameObject.GetComponent<AudioSource>();
        chaser1shooter2 = Random.Range(1, 3);
        SR = GetComponent<SpriteRenderer>();
        
        timer = timeshoot;
        tgt = FindObjectOfType<POINT>().transform;
        ptgt = FindObjectOfType<PlayerController>().transform;
        target = FindObjectOfType<POINT>().transform;
        playerTarget = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (chaser1shooter2 == 1)
        {
            SR.sprite = ChaserSRSprite1;
        }
        if (chaser1shooter2 == 2)
        {
            SR.sprite = ShooterSRSprite1;
        }


        if (tutoEnemy == false)
        {
            if (chaser1shooter2 == 1)
            {
                if (Vector3.Distance(transform.position, playerTarget.position) <= 13f)
                {
                    speed =5f;
                    target = ptgt;
                    MoveTowardsTarget();
                    RotateTowardsTarget();
                }

                else if (Vector3.Distance(transform.position, target.position) > 13f)
                {
                    speed = 4f;
                    target = tgt;
                    MoveTowardsTarget();
                    RotateTowardsTarget();
                    timer -= Time.deltaTime;

                }
            }

            if (chaser1shooter2 == 2)
            {

                if (Vector3.Distance(transform.position, playerTarget.position) <= 17f)
                {
                    ballSpeed = 20f;
                    target = ptgt;
                    //MoveTowardsTarget();
                    RotateTowardsTarget();
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        Shoot();
                        timer = timeshoot;
                    }
                }

                else if (Vector3.Distance(transform.position, target.position) > 17f)
                {
                    ballSpeed = 15f;
                    target = tgt;
                    MoveTowardsTarget();
                    RotateTowardsTarget();
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        Shoot();
                        timer = timeshoot;
                    }

                }
            }


        }
        /*
        if (Vector3.Distance(transform.position, playerTarget.position) < 0.3)
        {
            GameObject shot = Instantiate(shotenemyPrefab, FirePoint.position, FirePoint.rotation);

        }
        */


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform);

            PC.playerLife--;

            Destroy(this.gameObject);
        }


        if (collision.tag == "shoot")
        {
            if (tutoEnemy == true)
            {
                Instantiate(explosion, collision.transform);

                PC.score++;

                Destroy(this.gameObject, 0f);

            }
            else if (tutoEnemy == false)
            {
                Instantiate(explosion, collision.transform);
                life--;
                if (chaser1shooter2 == 1)
                {
                    if (life == 1)
                    {
                        Instantiate(explosion, collision.transform);
                        SR.sprite = ChaserSRSprite2;
                    }
                    if (life == 0)
                    {
                        Instantiate(explosion, collision.transform);
                        SR.sprite = ChaserSRSprite3;
                    }
                    if (life < 0)
                    {
                        Instantiate(explosion, collision.transform);
                        PC.score++;
                        Destroy(this.gameObject, 0f);
                    }

                }
                if (chaser1shooter2 == 2)
                {
                    if (life == 1)
                    {
                        Instantiate(explosion, collision.transform);
                        SR.sprite = ShooterSRSprite2;
                    }
                    if (life == 0)
                    {
                        Instantiate(explosion, collision.transform);
                        SR.sprite = ShooterSRSprite3;
                    }
                    if (life < 0)
                    {
                        Instantiate(explosion, collision.transform);
                        PC.score++;
                        Destroy(this.gameObject, 0f);
                    }
                }
            }


        }
    }


    private void MoveTowardsTarget()
    {
        if (chaser1shooter2 == 1 || chaser1shooter2 == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    private void RotateTowardsTarget()
    {
        var offset = 270f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    public void Shoot()
    {
        GameObject shot = Instantiate(shotenemyPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * ballSpeed, ForceMode2D.Impulse);
        cannon.Play();
        Destroy(shot, 4f);
    }

}
