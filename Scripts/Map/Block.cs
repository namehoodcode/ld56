using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BlockType
{
    Null,//��
    Obstacle,//�ϰ���
    breakable,//���ƻ���
    Wall,//ǽ
    HighPlace,
    throwAble,
}

public class Block : MonoBehaviour
{
    public int RowIndex;//���±�
    public int ColIndex;//���±�
    public BlockType Type;//��������
    public SpriteRenderer selectSp;
    public SpriteRenderer ObstacleSp;

    private void Awake()
    {
        selectSp = transform.Find("GridSelected").GetComponent<SpriteRenderer>();
        ObstacleSp = transform.Find("Obstacle").GetComponent<SpriteRenderer>();
    }

    //private void OnMouseEnter()
    //{
    //    selectSp.enabled = true;//��������ʱ ѡ��ǰ�ؿ���Ч����
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