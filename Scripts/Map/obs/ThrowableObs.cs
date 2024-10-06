using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObs : obsScript
{
    public override int[] Init()
    {
        return base.Init();
    }

    public override void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex,ColIndex,BlockType.throwAble);
    }
}
