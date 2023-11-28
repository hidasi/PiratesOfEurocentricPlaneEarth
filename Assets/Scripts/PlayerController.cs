using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float steerSpeed = 1f;
    public float moveSpeed = 0.3f;
    public int start = 0;
    public GameObject shotPrefab;
    public Transform FirePoint,esquerdo1,esquerdo2,esquerdo3,direito1,direito2,direito3;
    public float ballSpeed;
    public int startShoot=0;
    public AudioSource cannon;
    public int playerLife=2;
    public int score=0;
    private SpriteRenderer SRplayer;
    public Sprite SpritePlayer1;
    public Sprite SpritePlayer2;
    public Sprite SpritePlayer3;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Transform>();
        SRplayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (start != 0)
        {

            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
            transform.Rotate(0, 0, -steerAmount);
            //transform.Translate(0, moveAmount, 0);
            if (moveAmount > 0)
            {
                transform.Translate(0, moveAmount, 0);
            }

            /*if (startShoot != 0)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Shoot();
                    //StartCoroutine(Shooting());
                }

            }*/

        }


    }

    private void Update()
    {
        if (playerLife == 2)
        {
            SRplayer.sprite = SpritePlayer1;
            
        }
        if (playerLife == 1)
        {
            SRplayer.sprite = SpritePlayer2;
        }
        if (playerLife == 0)
        {
            SRplayer.sprite = SpritePlayer3;
        }
        if (playerLife < 0)
        {
            SRplayer.sprite = null;
        }

    }

    public void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * ballSpeed, ForceMode2D.Impulse);
        cannon.Play();
        Destroy(shot, 3f);
    }

    public void TripleShoot()
    {
        GameObject shot1 = Instantiate(shotPrefab, esquerdo1.position, esquerdo1.rotation) ;
        Rigidbody2D rb1 = shot1.GetComponent<Rigidbody2D>();
        rb1.AddForce(transform.right * -ballSpeed, ForceMode2D.Impulse);
        GameObject shot2 = Instantiate(shotPrefab, esquerdo2.position, esquerdo2.rotation);
        Rigidbody2D rb2 = shot2.GetComponent<Rigidbody2D>();
        rb2.AddForce(transform.right * -ballSpeed, ForceMode2D.Impulse);
        GameObject shot3 = Instantiate(shotPrefab, esquerdo3.position, esquerdo3.rotation);
        Rigidbody2D rb3 = shot3.GetComponent<Rigidbody2D>();
        rb3.AddForce(transform.right * -ballSpeed, ForceMode2D.Impulse);

        GameObject shot4 = Instantiate(shotPrefab, direito1.position, direito1.localRotation) ;
        Rigidbody2D rb4 = shot4.GetComponent<Rigidbody2D>();
        rb4.AddForce(transform.right * ballSpeed, ForceMode2D.Impulse);
        GameObject shot5 = Instantiate(shotPrefab, direito2.position, direito2.localRotation);
        Rigidbody2D rb5 = shot5.GetComponent<Rigidbody2D>();
        rb5.AddForce(transform.right * ballSpeed, ForceMode2D.Impulse);
        GameObject shot6 = Instantiate(shotPrefab, direito3.position, direito3.localRotation);
        Rigidbody2D rb6 = shot6.GetComponent<Rigidbody2D>();
        rb6.AddForce(transform.right * ballSpeed, ForceMode2D.Impulse);

        cannon.Play();
        Destroy(shot1, 0.25f);
        Destroy(shot2, 0.25f);
        Destroy(shot3, 0.25f);
        Destroy(shot4, 0.25f);
        Destroy(shot5, 0.25f);
        Destroy(shot6, 0.25f);
    }


}
