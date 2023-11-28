using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expscr : MonoBehaviour
{
    public float time=30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1;

        if (time <= 0)
        {
            Destroy(this);
        }
    }
}
