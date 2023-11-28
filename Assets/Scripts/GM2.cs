using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GM2 : MonoBehaviour
{
    public PlayerController PC;
    //public float ballSpeed=8;
    public GameObject timerzone, menu, prefabenemy;
    public TextMeshProUGUI timer, score, hiscore;
    public Transform POINT, ponto, p1, p2, p3, p4;
    private int hiscoreint;
    private Animator anim;
    private int Rp;
    private float DistancePOINTtoPlayer;
    public float timeenemy, timefull;
    private float timertotal,totaltime=1f,timershoot,timerenemy;
    private bool readyshoot=false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("spawn"))
        {
            timeenemy = 4f;
        } else if (PlayerPrefs.GetInt("spawn")==5)
        {
            timeenemy = 4f;
        }
        else if (PlayerPrefs.GetInt("spawn") == 3)
        {
            timeenemy = 3f;
        }
            timerenemy = timeenemy;
        timershoot = totaltime;
        timerzone.SetActive(true);
        if (PlayerPrefs.HasKey("high"))
        {
            var playerScore = PlayerPrefs.GetInt("high");
            hiscore.text = playerScore.ToString();
            hiscoreint=int.Parse(hiscore.text);
            
        }

        if (!PlayerPrefs.HasKey("timefull"))
        {
            timefull = 180f;
        }
        else if (PlayerPrefs.GetInt("timefull") == 180)
        {
            timefull = 180f;
        }
        else if (PlayerPrefs.GetInt("timefull") == 90)
        {
            timefull = 90f;
        }

        timertotal = timefull;


        PC = FindObjectOfType<PlayerController>();
        anim = PC.gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        timerenemy -= 1f * Time.deltaTime;
        if (timerenemy <= 0)
        {
            Rp = Random.Range(1, 5);
            if (Rp == 1) { ponto = p1; }
            if (Rp == 2) { ponto = p2; }
            if (Rp == 3) { ponto = p3; }
            if (Rp == 4) { ponto = p4; }
            GameObject En = Instantiate(prefabenemy, ponto);
            timerenemy = timeenemy;
        }

        timershoot -=1f*Time.deltaTime;
        if (timershoot <= 0)
        {            
            readyshoot = true;
        }

        if (Input.GetKey(KeyCode.Space) && readyshoot==true)
        {
            PC.Shoot();
            timershoot = totaltime;
            readyshoot =false;
        }

        if (Input.GetKey(KeyCode.LeftControl) && readyshoot == true)
        {
            PC.TripleShoot();
            timershoot = totaltime;
            readyshoot = false;
        }

        timertotal -= 1f * Time.deltaTime;
        var timertotalrounded=Mathf.Round(timertotal);
        timer.text = "Time: "+timertotalrounded.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //score = PC.score;
        score.text = "Score: "+PC.score.ToString();

        if (PC.score > hiscoreint)
        {
            hiscoreint = PC.score;
            hiscore.text = "HiScore: "+hiscoreint.ToString();
            PlayerPrefs.SetInt("high",hiscoreint);
        }
        if (PC.playerLife <= 0)
        {
            PC.moveSpeed = 0;
            StartCoroutine(falling());
        }

        if( Vector2.Distance(POINT.position,PC.transform.position)>23f){
            PC.moveSpeed = 0;
            StartCoroutine(falling());
        }

    }

    IEnumerator falling()
    {
        anim.SetTrigger("fall");
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    IEnumerator exploding()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

}
