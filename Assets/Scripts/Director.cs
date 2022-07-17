using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static string Name;
    public static int Score;

    float time = 0;

    void UpdateRank()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if(this.time >= (3 * 60))
        {
            this.UpdateRank();
        }
    }
}
