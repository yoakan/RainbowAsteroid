using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField]
    private float torque = 0.2f;

    [SerializeField] private float coldownHit = 0.5f;
    [SerializeField] private Sprite spritePropulsion;
    [SerializeField]
    private Sprite defaultSpriteShip;

    [SerializeField] private AudioClip soundPushShip;

    private  void Start()
    {
        defaultSpriteShip = _spriteRenderer.sprite;
    }

    

    public void turn(bool rightRotate)
    {
        int direction = (rightRotate) ? -1 : 1;
        //this.rigidbody2D.AddTorque(direction*torque);
        this.transform.Rotate(0,0,direction*torque*Time.deltaTime);
    }

    

    public  void move()
    {

        float forcePush = shipModel.speed*force * Time.deltaTime;
        _rigidbody.AddForce(this.transform.up*forcePush);
        
        _spriteRenderer.sprite = spritePropulsion;
        playSound(soundPushShip);
    }

    public void stopMove()
    {
        _spriteRenderer.sprite = defaultSpriteShip;
    }
    public float getLife()
    {
        return shipModel.life;
    }

    public Color getColor()
    {
        return this.colorItem.Color;
    }

    public void activeShip(bool active)
    {

        if (active)
        {
            
            Invoke(nameof(canTeleported), 0.5f);
            if (_particleSystem == null)
            {
                _particleSystem = GetComponentInChildren<ParticleSystem>();
            }
            _particleSystem.Play();
        }
        else
        {
            this.isTeleportabled = active;
        }
        this.gameObject.active = active;    
    }
    protected override  void animeHit()
    {
        print("VIDAAA: "+matterModel.life);
        GameManager.Instance.GameUIManager.updateLifeShip((int)matterModel.life);
        StartCoroutine(animateHit());
        
    }

    private IEnumerator animateHit()
    {
        yield return new WaitForSeconds(desactiveObject());
        isTeleportabled = true;
        _spriteRenderer.enabled = true;
        _boxCollider2D.enabled = true;
    }
    protected override void checkDied()
    {
        GetComponentInParent<ShipPlayerManager>().removeShip(this);
        base.checkDied();
    }

    
    public  void canTeleported()
    {
        
        isTeleportabled = true;
        
    }
    
}
