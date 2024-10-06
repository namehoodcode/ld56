using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganzi : obsScript
{
    public Transform door;
    public Sprite[] doorSprites;
    public bool opening;

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
        gameObject.transform.Rotate(0, 180, 0);
        if(opening == false)
        {
            door.GetComponent<SpriteRenderer>().sprite = doorSprites[1];
            int rowIndex = door.GetComponent<obsScript>().RowIndex;
            int colIndex = door.GetComponent<obsScript>().ColIndex;
            GameApp.mapManager.ChangeBlockType(rowIndex, colIndex, BlockType.Null);
        }
        else
        {
            door.GetComponent<SpriteRenderer>().sprite = doorSprites[0]; 
            door.GetComponent<obsScript>().ChangeBlockType();
        }
        opening = !opening;
    }
}
