using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WindObs : obsScript
{
    public float Count => GameApp.gameManager.gameCount;
    public Vector2 faceDir = Vector2.right;
    private Transform arrow;
    Vector3 toPos;
    public override int[] Init()
    {
        return base.Init();
    }

    public override void ChangeBlockType()
    {
        base.ChangeBlockType();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameApp.gameManager.gameCount--;
        //player.Move(faceDir,3);
        if (collision.gameObject.GetComponent<water>())
        {
            return;
        }
        int toRow = RowIndex;
        int toCol = ColIndex;
        for (int i = 1; i <=7; i++) 
        {
            toRow += (int)faceDir.y;
            toCol += (int)faceDir.x;
            if (GameApp.mapManager.GetBlockType(toRow, toCol) == BlockType.Obstacle || GameApp.mapManager.GetBlockType(toRow, toCol) == BlockType.Wall || GameApp.mapManager.GetBlockType(toRow,toCol) == BlockType.breakable)
            {
                toPos = new Vector3(toRow - faceDir.y, toCol - faceDir.x, 0);
                break;
            }
            toPos = new Vector3(toRow, toCol, 0);
        }
        player.WindMove(toPos);
    }
}
