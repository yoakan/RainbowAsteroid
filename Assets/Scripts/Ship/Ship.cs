using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ship : Matter
{
    // Start is called before the first frame update
    protected ShipModel shipModel;
    [SerializeField] private GameObject PrefabsBullet;
    protected bool canFire = true;
    
   

    [SerializeField] protected Transform pointShot;
    [SerializeField]
    protected float force = 500;

    [SerializeField] protected AudioClip soundShoot;
    protected override void Awake()
    {
         shipModel= (ShipModel)matterModel;
        base.Awake();
        
        if (pointShot == null)
        {
            pointShot = this.transform;
        }
    }
    
    public void FixedUpdate()
    {
        limitVelocity();
    }

    

    private void limitVelocity()
    {
        _rigidbody.velocity = new Vector2(
                checkLimitValue(_rigidbody.velocity.x, ShipConstants.MAX_VELOCITY * shipModel.speed),
                checkLimitValue(_rigidbody.velocity.y, ShipConstants.MAX_VELOCITY * shipModel.speed)
            );
        
    }
    private float checkLimitValue(float velocity , float maxVelocity)
    {
         
        if (Math.Abs(_rigidbody.velocity.x) > maxVelocity )
        {
            velocity = Math.Sign(velocity)* maxVelocity;
        }
        return velocity;
    }
    /*
    public void move(Vector3 direction)
    {
        rigidbody2D.AddForce(direction*shipModel.speed*force*Time.deltaTime);
    }*/

    

    public void fire()
    {
        if (canFire)
        {
            //print("FIGHT");
            canFire = false;
            Bullet bullet = Instantiate(PrefabsBullet).GetComponent<Bullet>();
            bullet.setColor(colorItem);
            bullet.transform.position = pointShot.position;
            bullet.executeTrown(this.transform.up.normalized*shipModel.speedFight,shipModel.damage);
            Invoke(nameof(finishFire),shipModel.timeFight);
            playSound(soundShoot);
        }
    }

    protected void finishFire()
    {
        canFire = true;
    }
}
