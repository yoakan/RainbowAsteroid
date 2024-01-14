using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Matter" )]
public class MatterModel: ScriptableObject
{
    
    public float damage=1;
    public float speed = 1;
    public float life = 1;

    public virtual void cloneMatter(MatterModel matterModel)
    {
        this.damage = matterModel.damage;
        this.speed = matterModel.speed;
        this.damage = matterModel.damage;
    }
}
