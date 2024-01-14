using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Game/Ship" )]
public class ShipModel :MatterModel
{
    public float speedFight=1;
    public float timeFight = 2;
    public float critical = 1;
    public float precision = 1;
    public float bulletPush = 1;
    public override void cloneMatter(MatterModel matterModel)
    {
        base.cloneMatter(matterModel);
        speedFight = ((ShipModel)matterModel).speedFight;
        timeFight = ((ShipModel)matterModel).timeFight;
        critical = ((ShipModel)matterModel).critical;
        critical = ((ShipModel)matterModel).critical;
        precision = ((ShipModel)matterModel).precision;
        bulletPush = ((ShipModel)matterModel).bulletPush;
    }
}
