using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(
    typeof(Rigidbody2D),
    typeof(BoxCollider2D),
    typeof(SpriteRenderer)
    )
]
[RequireComponent(
        typeof(AudioSource)
    )
]
public abstract class Matter : MonoBehaviour
{
    // Start is called before the first frame update

    
    [SerializeField]
    protected MatterModel matterModel;
    protected bool isTeleportabled = true;
    protected ColorType colorType;
    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _spriteRenderer;
    protected AudioSource _audioSource;
    [SerializeField] protected AudioClip soundExplotion;
    [SerializeField]
    protected ParticleSystem _particleSystem;
    protected BoxCollider2D _boxCollider2D;
    [SerializeField]
    protected ColorItem colorItem;

    protected virtual void Awake()
    {
        
        var newMatterModel = Instantiate(matterModel);
        newMatterModel.cloneMatter(matterModel);
        matterModel = newMatterModel;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        loadModelColor();

    }

    protected virtual void loadModelColor()
    {
        _spriteRenderer.color = colorItem.Color;
        colorType = colorItem.Type;
        if (_particleSystem is not null)
        {
            _particleSystem.startColor = colorItem.Color;

            
        }
    }

    private float Damage
    {
        set => matterModel.damage = value;
    }

    public bool IsTeleportabled => isTeleportabled;

    public void setColor(ColorItem colorItem)
    {
        this.colorItem = colorItem;
        loadModelColor();
    }

    public ColorItem getColorItem()
    {
        return colorItem;
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Matter _otherMatter = other.gameObject.GetComponent<Matter>();
        //print("Colisiono");
        float damage;
        if (_otherMatter != null)
        {
            
            if (other.gameObject.tag != this.gameObject.tag)
            {
                
                damage = _otherMatter.getDamage(getColor());
                matterModel.life -=  damage ;
                animeHit();
                if (matterModel.life<=0)
                {
                    checkDied();                
                }
                
            }
        }
    }

    protected virtual  void animeHit()
    {
        
    }


    protected virtual void checkDied()
    {
        float timeDied = desactiveObject();
        playSound(soundExplotion);
        Destroy(this.gameObject,timeDied);
    }

    protected void playSound(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }

    protected virtual float desactiveObject()
    {
        float time = 0;
        if (_particleSystem is not null)
        {
            _particleSystem.Play();
            isTeleportabled = false;
            _spriteRenderer.enabled = false;
            _boxCollider2D.enabled = false;
            
            time = _particleSystem.duration;
        }
        return time;
    }

    public float getDamage(ColorType enemy)
    {
        float damage = matterModel.damage;
        if (colorItem.isCounters(enemy))
        {
             damage /=   2;
        }

        if (colorItem.isStrong(enemy))
        {
            damage *=  2;
        }
        
        //print("Color: "+colorItem.Type+" Color enemigo "+enemy+" Damage recibido: "+damage);
        return damage;
    }
    
    public ColorType getColor()
    {
        return colorType;
    }

    

    protected void OnBecameInvisible()
    {
        //print("ESTOY AAA"+isTeleportabled);
        if (isTeleportabled)
        {
            if(GameManager.Instance!=null && GameManager.Instance.CameraUtil!=null)
                GameManager.Instance.CameraUtil.goAutLimit(this.transform);
        }
    }
    protected void OnDisable()
    {
        isTeleportabled = false;
    }

    protected virtual void OnEnable()
    {
        //print("HOLAAA NO ME QUIERO TELETRASPORTAR ON ENABLE");
        //Invoke(nameof(canTeleported),0.5f);
    }

    

    
}
