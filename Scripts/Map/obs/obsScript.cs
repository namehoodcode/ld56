using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class obsScript : MonoBehaviour
{
    public int RowIndex;
    public int ColIndex;
    public Player player;

    public void Start()
    {
    }

    public virtual int[] Init()
    {
        //GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        player = GameApp.gameManager.player;
        RowIndex = (int)Mathf.Round(transform.position.y);
        ColIndex = (int)Mathf.Round(transform.position.x);
        return new int[2] {RowIndex, ColIndex};
    }

    public virtual void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex, ColIndex,BlockType.Obstacle);
    }
}
