using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BlockType
{
    Null,//空
    Obstacle,//障碍物
    breakable,//可破坏的
    Wall,//墙
    HighPlace,
    throwAble,
}

public class Block : MonoBehaviour
{
    public int RowIndex;//行下标
    public int ColIndex;//列下标
    public BlockType Type;//格子类型
    public SpriteRenderer selectSp;
    public SpriteRenderer ObstacleSp;

    private void Awake()
    {
        selectSp = transform.Find("GridSelected").GetComponent<SpriteRenderer>();
        ObstacleSp = transform.Find("Obstacle").GetComponent<SpriteRenderer>();
    }

    //private void OnMouseEnter()
    //{
    //    selectSp.enabled = true;//当鼠标进入时 选择当前地块特效开启
    //}

    //private void OnMouseExit()
    //{
    //    selectSp.enabled = false;
    //}

    public BlockType GetBlockType()
    {
        return Type;
    }
    public void ChangeBlockType(BlockType type)
    {
        Type = type;
    }

    public void ChangeObsSp()
    {
        ObstacleSp.sprite = Resources.Load("obs") as Sprite;
        ObstacleSp.enabled = true;
    }

    public void DeleteObsSp()
    {
        ObstacleSp.sprite = null;
    }
}