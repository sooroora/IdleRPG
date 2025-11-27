using System.Collections.Generic;
using UnityEngine;

public class MonsterRayDetector : RayDetector<Monster>
{
    public override List< Monster > CurrentTargets
    {
        get
        {
            UpdateTarget();
            
            List<Monster> aliveTargets = new List<Monster>();

            foreach ( Monster monster in currentTargetList )
            {
                if ( monster.Status.NowHealth > 0 )
                {
                    aliveTargets.Add(monster);
                }
            }
            
            return aliveTargets;
        }
    }

    public override Monster CurrentTarget
    {
        get
        {
            if ( CurrentTargets.Count > 0 )
            {
                return CurrentTargets[0];
            }
            return null;
            
        }
    }
}
