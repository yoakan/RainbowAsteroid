using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoGuide : MonoBehaviour
{
    [SerializeField] private Text play;
    [SerializeField] private float velocity = 0.9f;
    

    // Update is called once per frame
    void Update()
    {
        play.color = Color.Lerp(Color.white, new Color(255,255,255,0), Mathf.PingPong(Time.time*velocity, 1));
    }
}
