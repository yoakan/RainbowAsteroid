using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject ShipPrefab;
    private ColorManager _colorManager;
    [SerializeField]
    private PlayerShip[] ships;
    [SerializeField]
    private AddShipUI addShipUI;
    private ShipController shipController;
    private GameUIManager gameUIManager;
    [SerializeField] private int probabilityAddShip = 75;
    private int limProb = 100;
    private bool isFirstShip = true;

    public void Awake()
    {
        gameUIManager = FindObjectOfType<GameUIManager>();
        shipController = this.GetComponent<ShipController>();
    }

    void Start()
    {
        _colorManager = GameManager.Instance.ColorManager;
        gameUIManager = GameManager.Instance.GameUIManager;
        createShip(_colorManager.getRandomColorItem(),0);
        isFirstShip = false;

    }

    public void createShip(ColorItem colorItem,int index)
    {
        PlayerShip  ship=Instantiate(ShipPrefab,this.transform).GetComponent<PlayerShip>();
        ship.setColor(colorItem);
        ships[index]=ship;
        
        shipController.Ships = ships;
        if (!isFirstShip)
        {
            shipController.desactiveControlShip(index);
        }
        
        gameUIManager.addShip(ship.getColor(),(int)ship.getLife());
    }

    private void loadAllLife()
    {
        gameUIManager.removeAllShipLifes();
        for (int i = 0; i < ships.Length; i++)
        {
            
            PlayerShip ship = ships[i];
            gameUIManager.addShip(ship.getColor(),(int)ship.getLife());
        }
        
    }

    public ShipController ShipController
    {
        get => shipController;
        
    }

    public AddShipUI ShipUI
    {
        get => addShipUI;
        set => addShipUI = value;
    }

    public bool checkEvents()
    {
        int probabilty = Random.Range(0, limProb);
        //print("He tenido suerte? "+probabilty);
        bool haveEvent = probabilty < probabilityAddShip;
        if (haveEvent)
        {
            addShipUI.loadAddShip(_colorManager.getRandomColorItem(),ships);
        }

        if (probabilityAddShip > 10)
        {
            probabilityAddShip -= 5;
        }

        return haveEvent;
    }

    public void removeShip(PlayerShip playerShip)
    {
        bool isTheFirstShip = false;
        PlayerShip modifyShip = playerShip;
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i] == modifyShip)
            {
                if (i == ships.Length - 1)
                {
                    ships[i] = null;
                }
                else
                {
                    ships[i] = ships[i + 1];
                    modifyShip = ships[i + 1];
                }
                
            }
        }
        shipController.Ships = ships;
        if (ships[0] == null)
        {
            GameManager.Instance.finishGame();
        }
        else
        {
            shipController.activeShip(0);
        }
        
        GameManager.Instance.GameUIManager.resetShips(ships);
    }
}
