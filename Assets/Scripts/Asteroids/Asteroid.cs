using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : Matter
{
    [SerializeField] private GameObject[] asteroidChildren;
    [SerializeField] private Sprite[] spritesType;
    private int spriteUsed = 0;
    [SerializeField]
    private float forceMiniChild = 2.3f;
    [SerializeField] private int score = 100;
    private Vector2 velocityDefault;

    public int SpriteUsed
    {
        get => spriteUsed;
        set { spriteUsed = value;
            changeSprite();
        }
    }

    public float ForceMiniChild => forceMiniChild;


    protected override void Awake()
    {
        base.Awake();
        isTeleportabled = false;
        matterModel.life = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteUsed = Random.Range(0, spritesType.Length);
        Invoke(nameof(setVelocity),0.25f);
        changeSprite();
    }

    private void setVelocity()
    {
        velocityDefault = _rigidbody.velocity;
    }
    public void changeSprite()
    {
        _spriteRenderer.sprite = spritesType[spriteUsed];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void checkDied()
    {
        AsteroidManager asteroidManager = GameManager.Instance.AsteroidManager;
        
        asteroidManager.generateAsteroidsChildren(
            asteroidChildren,
            this.transform.position,
            this
            );
        GameManager.Instance.addScore(score);
        asteroidManager.quitAsteroid(this.gameObject);
        base.checkDied();
    }

    private Vector2 randomMoveAsteroid()
    {
        return new Vector2(Random.Range(-10, 10),Random.Range(-10, 10));
    }

    private void OnBecameVisible()
    {
        isTeleportabled = true;
    }

    

    protected override void OnEnable()
    {
        base.OnEnable();
        _rigidbody.velocity = velocityDefault;
    }
}

public enum AsteroidType
{
    Small =0,
    Medium=1,
    Big =2
}