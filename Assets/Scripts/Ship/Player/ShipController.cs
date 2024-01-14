using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private PlayerShip[] ships;

    [SerializeField] private SpriteRenderer[] lastPositionShip;

    [SerializeField] private KeyCode[] keyboardChange;

    [SerializeField] private KeyCode butonGoUp = KeyCode.W;
    private AudioSource _audioSource;
    private GameUIManager gameUIManager;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameUIManager = GameManager.Instance.GameUIManager;
    }


    private int shipUsed = 0;

    public PlayerShip[] Ships
    {
        get => ships;
        set => ships = value;
    }

    

    public PlayerShip[] getPlayerShips()
    {
        return ships;
    }
    // Update is called once per frame
    void Update()
    {
        updateMovement();
        if (ships[1] != null)
        {
            changeShip();
        }
        
        checkFire();
    }

    private void changeShip()
    {
        for (int i = 0; i < keyboardChange.Length; i++)
        {
            if (ships[i] != null & Input.GetKeyDown(keyboardChange[i]))
            {
                
                desactiveControlShip(shipUsed);
                activeShip(i);
                _audioSource.Play();
                if(gameUIManager!=null)
                    gameUIManager.ShipInUsed = i;
            }
        }
    }

    public void activeShip(int i)
    {
        shipUsed = i;
        ships[i].activeShip(true);
        lastPositionShip[i].gameObject.SetActive(false);
    }
    public void desactiveControlShip(int index)
    {
        lastPositionShip[index].color = ships[index].getColor();
        lastPositionShip[index].transform.position = ships[index].transform.position;
        lastPositionShip[index].gameObject.SetActive(true);
        
        ships[index].activeShip(false);
    }
    private void checkFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("PULZO DISPARO");
            ships[shipUsed].fire();
        }
    }

    private void updateMovement()
    {

        //ship.move(Vector3.up * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal"));
        if(Input.GetAxis("Horizontal") !=0)
            ships[shipUsed].turn(Input.GetAxis("Horizontal")>0);
        if(Input.GetKey(butonGoUp) )
            ships[shipUsed].move();
        if (Input.GetKeyUp(butonGoUp))
        {
            ships[shipUsed].stopMove();
        }
    }
    private void changeVelocity(float input,Vector3 direction)
    {
        if (input != 0)
        {
            Vector3 velocity = ships[shipUsed].GetComponent<Rigidbody2D>().velocity;
            //ship.GetComponent<Rigidbody2D>().velocity= velocity-velocity*direction
        }
    }
    
}
enum Movement
{
    Up = 1,
    Down = -1,
    Left = -1,
    Right = 1,

}
