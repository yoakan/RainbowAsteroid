using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject ShipUIPrefab;
    [SerializeField] private Text score;

    [SerializeField]private Text lvl;
    [SerializeField] private Text gameOver;

    [SerializeField] private Transform boxShipLives;

    private List<ShipLifeUI> shipLifes= new List<ShipLifeUI>();

    private int shipInUsed = 0;

    public int ShipInUsed
    {
        set => shipInUsed = value;
    }

    // Start is called before the first frame update
    public void addShip(Color color, int life)
    {
        ShipLifeUI lifeUI= Instantiate(ShipUIPrefab, boxShipLives).GetComponent<ShipLifeUI>();
        lifeUI.Started(""+life,color);
        shipLifes.Add(lifeUI);
    }

    public void removeAllShipLifes()
    {
        for (int i = 0; i < shipLifes.Count; i++)
        {
            Destroy(shipLifes[i].gameObject);
        }
        shipLifes.Clear();
    }

    public void resetShips(PlayerShip[] ships)
    {
        removeAllShipLifes();
        foreach (var ship in ships)
        {
            if (ship!=null)
            {
                addShip(ship.getColor(),(int)ship.getLife());
            }
            
        }
    }

    public float showGameOver()
    {
        float duration = 1.5f;
        gameOver.enabled = true;
        return duration;
    }
    public void removeShipUsed()
    {
        Destroy(shipLifes[shipInUsed].gameObject);
    }
    public void updateLifeShip(float life)
    {
        print("ACTUALIZO LA VIDAA");
        shipLifes[shipInUsed].setLiveActually(""+life);
    }

    public void changeShip(int numShip)
    {
        shipLifes[shipInUsed].notUsedShip();
        shipLifes[numShip].usingShip();
        shipInUsed = numShip;
        
    }
    // Update is called once per frame
    public void updateScore(int score)
    {
        this.score.text = ""+score;
    }

    public void updateLvl(int lvl)
    {
        this.lvl.text = "" + lvl;
    }
}
