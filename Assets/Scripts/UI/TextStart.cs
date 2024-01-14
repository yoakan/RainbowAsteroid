using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStart : MonoBehaviour
{
    [SerializeField] private Text play;

    [SerializeField] private float velocity = 0.9f;
    // Start is called before the first frame update
    private void Awake()
    {
        play = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        play.color = Color.Lerp(Color.white, new Color(255,255,255,0), Mathf.PingPong(Time.time*velocity, 1));

    }
}
