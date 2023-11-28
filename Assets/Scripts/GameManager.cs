using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public bool atirou = false;
    public PlayerController PC;
    public CinemachineVirtualCamera CAMERA1;
    public CinemachineVirtualCamera CAMERA2;
    public Transform flag;
    public GameObject EnemyObj;
    public Transform Enemy;
    private bool apertar = false;
    public GameObject FIREIMAGE;
    private bool PREFIRED;
    public GameObject GM2;
    public AudioSource BG;

    public float speed = 0.2f;
    private bool move = false;


    // Start is called before the first frame update
    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        StartCoroutine(Intro());
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (apertar==false)
        {
            if (Vector2.Distance(Enemy.position, flag.position) < 0.1f && apertar == false)
            {
                move = false;

                apertar = true;

            }
        }
        


        if (apertar == true && PREFIRED==false)
        {
            //PC.startShoot = 1;

            FIREIMAGE.SetActive(true);

            PREFIRED = true;
     
        }

        if (PREFIRED == true && Input.GetKey(KeyCode.Space) )
        {
            PC.Shoot();
            FIREIMAGE.SetActive(false);
            GM2.SetActive(true);
            PC.start = 1;

            BG.Play();
            Destroy(this.gameObject);
        }



        if (move == true)
        {
            Enemy.localPosition = Vector2.MoveTowards(Enemy.position, flag.position, speed);
        }

    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(2f);

        CAMERA1.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        move = true;

        yield return new WaitForSeconds(2f);

        CAMERA1.gameObject.SetActive(true);
        CAMERA2.gameObject.SetActive(true);
    }

}
