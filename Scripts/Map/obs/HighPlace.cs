using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPlace : obsScript
{
    public Vector2 podaoDir = Vector2.down;//�ǵ��ڱ༭��ҳ���޸�
    public override int[] Init()
    {
        return base.Init();
    }

    public override void ChangeBlockType()
    {
        GameApp.mapManager.ChangeBlockType(RowIndex,ColIndex,BlockType.HighPlace);
    }
}
