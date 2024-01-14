using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddShipUI : MonoBehaviour
{
    [SerializeField]
    private List<ShipElementUI> shipElements;

    [SerializeField] private Image newShip;
    [SerializeField] private Text textForget; 
    private PlayerShip[] ships;
    private ColorItem colorUsed;

    public ColorItem ColorUsed
    {
        get => colorUsed;
        set => colorUsed = value;
    }

    public PlayerShip[] Ships
    {
        
        set => ships = value;
    }

    private void Start()
    {
    }

    public void loadAddShip(ColorItem colorUsed,PlayerShip[] ships)
    {
        this.Ships = ships;
        this.gameObject.SetActive(true);
        this.colorUsed = colorUsed;
        newShip.color = colorUsed.Color;
        textForget.color = colorUsed.Color;
        addShipElemets();
        
    }

    private void addShipElemets()
    {
        int contShipExist = 0;
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i]!=null)
            {
                print("SOY EL NUMERO: "+i);
                shipElements[i].addStatShip((int)ships[i].getLife(),ships[i].getColor());
                shipElements[i].gameObject.SetActive(true);
                contShipExist = i;
            }
        }
        
        if (contShipExist < shipElements.Count - 1)
        {
            contShipExist++;
            shipElements[contShipExist].gameObject.SetActive(true);
            shipElements[contShipExist].addStatShip(
                (int)ships[contShipExist].getLife(),
                ships[contShipExist].getColorItem().Color);
        }
    }

    public void overImage(bool isEntry)
    {
        textForget.gameObject.SetActive(isEntry);
    }
    public void changeColor(ShipElementUI shipElementUI)
    {
        
        GameManager.Instance.PlayerManager.createShip(colorUsed,shipElements.IndexOf(shipElementUI));
        continueLvl();
        
    }

    public void clickForgetShip()
    {
        continueLvl();
    }

    private void continueLvl()
    {
        GameManager.Instance.advanceLvl();
        this.gameObject.SetActive(false);
        
    }

    private void restarUIElement()
    {
        for (int i = 0; i < shipElements.Count; i++)
        {
            shipElements[i].gameObject.SetActive(false);
        }
    }
}
