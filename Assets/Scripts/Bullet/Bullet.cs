using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : Matter
{
    // Start is called before the first frame update
    
    
    [SerializeField]
    private float startDamage = 0.03f;

    [SerializeField] private float timeDestroy= 4;
    [SerializeField]
    private float damage = 1f;
    [SerializeField] private float velocity = 5;

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    protected override void Awake()
    {
        base.Awake();
        Destroy( this.GameObject(),timeDestroy);
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.Awake();
        if (!other.gameObject.CompareTag(Constants.TAG_ZONE))
        {
            checkDied();
        }
    }

    public void executeTrown(Vector3 direction, float damage)
    {
        this.damage = damage;
        _rigidbody.AddForce(direction*velocity);
        
    }

    
}
