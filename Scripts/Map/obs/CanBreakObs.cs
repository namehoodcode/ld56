using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBreakObs : obsScript
{
    // Start is called before the first frame update
    public override int[] Init()
    {
        return base.Init();
    }
    public override void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex, ColIndex, BlockType.breakable);
    }

    private void OnDestroy()
    {
        if (GameApp.mapManager.isRemaking)
        {
            return;
        }
        GameApp.mapManager.ChangeBlockType(RowIndex,ColIndex, BlockType.Null);
        GameApp.gameManager.deadNum++;
        GameApp.barManager.UpdateDeadBar();
    }
}
