using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipLifeUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text contLives ;
    [SerializeField]
    private Image shipInUsed;

    [SerializeField] private int opacityNotUsed = 90;

    private Color color;
    public void Started(String lives,Color color)
    {
        this.color = color;
        contLives.text = lives;
        shipInUsed.color = color;
    }

    public void  notUsedShip()
    {
        
        contLives.color = new Color(color.r,color.b,color.g,opacityNotUsed);
    }

    public void usingShip()
    {
        contLives.color = color;
    }

    public void setLiveActually(String lives)
    {
        contLives.text = lives;
    }
}
