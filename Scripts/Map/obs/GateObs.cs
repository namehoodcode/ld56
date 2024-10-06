using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObs : obsScript
{
    public Vector2 toPos = new Vector2();
    public override int[] Init()
    {
        return base.Init();
    }

    public override void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex, ColIndex, BlockType.Null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<water>())
        {
            return;
        }
        if (player.chuansonged) { return;}
        player.chuansonged = true;
        player.ChuanSong(toPos);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
