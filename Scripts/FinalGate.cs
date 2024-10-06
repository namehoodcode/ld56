using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinalGate : obsScript
{
    public Vector2 playerPos;
    public override int[] Init()
    {
        return base.Init();
    }

    public override void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex,ColIndex,BlockType.Null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameApp.gameManager.currentSceneIndex++;
        Debug.Log(GameApp.gameManager.currentSceneIndex);
        GameApp.mapManager.SwitchObses();
        GameApp.barManager.ResetNum();
        GameApp.jqManager.UpdateText();
    }
    private void OnDestroy()
    {

    }
}
