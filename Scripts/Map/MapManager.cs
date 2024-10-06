using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager
{
    private Tilemap groundTileMap;

    public Block[,] mapArr;

    public int RowCount;//地图行
    public int ColCount;//地图列

    public int[,] obsIndex;
    public List<obsScript> obses;

    public GameObject[] obsPack;

    public int[] playerPos = new int[12] {3,1,6,9,15,8,15,9,15,5,1,1};
    private int[] guoguanplayerPos = new int[4] { 14, 1 , 15, 8 };

    public bool isRemaking;
    //初始化地图信息
    public void Init()
    {
        obsPack = new GameObject[6];

        obsPack[0] = GameObject.Find("obses0");
        obsPack[1] = GameObject.Find("obses1");
        obsPack[2] = GameObject.Find("obses2");
        obsPack[3] = GameObject.Find("obses3");
        obsPack[4] = GameObject.Find("obses4");
        obsPack[5] = GameObject.Find("obses5");
        for (int i = 1; i < obsPack.Length; i++)
        {
            obsPack[i].SetActive(false);
        }

        groundTileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();

        //地图大小 可以将这个信息写到配置表中进行设置
        RowCount = 11;
        ColCount = 17;

        mapArr = new Block[RowCount, ColCount];

        List<Vector3Int> tempPosArr = new List<Vector3Int>();//临时记录瓦片地图每个格子的位置

        //遍历瓦片地图
        foreach (var pos in groundTileMap.cellBounds.allPositionsWithin)
        {
            if (groundTileMap.HasTile(pos))
            {
                tempPosArr.Add(pos);
            }
        }

        //将一维数组的位置转换为二维数组的Block进行储存
        Object prefabObj = Resources.Load("Model/block");
        for (int i = 0; i < tempPosArr.Count; i++)
        {
            int row = i / ColCount;
            int col = i % ColCount;
            Block b = (Object.Instantiate(prefabObj,GameObject.Find("Grid/ground").transform) as GameObject).AddComponent<Block>();
            
            b.RowIndex = row;
            b.ColIndex = col;
            b.transform.position = groundTileMap.CellToWorld(tempPosArr[i]) + new Vector3(.5f, .5f, 0);
            mapArr[row, col] = b;
        }


        //给地图制造墙壁
        for (int i = 0; i <= 16; i++)
        {
            mapArr[0, i].ChangeBlockType(BlockType.Wall);
            mapArr[10, i].ChangeBlockType(BlockType.Wall);
        }
        for (int j = 1; j <= 9; j++)
        {
            mapArr[j, 0].ChangeBlockType(BlockType.Wall);
            mapArr[j, 16].ChangeBlockType(BlockType.Wall);
        }
        GameApp.gameManager.player.transform.position = new Vector2(playerPos[0], playerPos[1]);
    }

    public Vector3 GetBlockPos(int row, int col)
    {
        Debug.Log(row + " " + col);
        return mapArr[row, col].transform.position;
    }

    public BlockType GetBlockType(int row, int col)
    {
        return mapArr[row, col].Type;
    }

    public void ChangeBlockType(int row, int col, BlockType type)
    {
        mapArr[row, col].Type = type;
        //if(type == BlockType.Obstacle)
        //{
        //    mapArr[row, col].ChangeObsSp();
        //}
    }

    public void ResetMapBlockType()
    {
        for (int i = 1;i < 16; i++)
        {
            for(int j = 1;j <= 9; j++)
            {
                ChangeBlockType(j, i, BlockType.Null);
            }
        }
    }

    public void ObsDeal()
    {
        obses = new List<obsScript>();//真正存障碍物脚本实例的列表
        GameObject[] obj = GameObject.FindGameObjectsWithTag("obs");
        obsIndex = new int[GameApp.mapManager.RowCount, GameApp.mapManager.ColCount];
        for (int i = 0; i < obj.Length; i++)
        {
            obsScript obs = obj[i].GetComponent<obsScript>();
            int[] obsin = obs.Init();
            obsIndex[obsin[0], obsin[1]] = i;
            obses.Add(obs);
            obses[i].ChangeBlockType();
        }
    }

    public void SwitchObses()
    {

        ResetMapBlockType();

        int cursI = GameApp.gameManager.currentSceneIndex;
        obsPack[cursI-1].SetActive(false);
        obsPack[cursI].SetActive(true);
        ObsDeal();
        //GameApp.gameManager.player.transform.position = new Vector2(guoguanplayerPos[2*(cursI-1)],guoguanplayerPos[2*cursI-1]);
        GameApp.gameManager.player.transform.position = new Vector2(playerPos[2*cursI],playerPos[2*cursI+1]);
    }

    public void Restart()
    {
        int i = GameApp.gameManager.currentSceneIndex;
        
    }
}
