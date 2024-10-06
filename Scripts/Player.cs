using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int RowIndex;
    public int ColIndex;
    public Transform arrows;

    public Transform upBlue;
    public Transform rightBlue;
    public Transform leftBlue;
    public Transform downBlue;

    public bool chuansonged;
    public Collider2D col;

    public Transform water;
    private Rigidbody2D waterRb;
    private Transform bahen1;
    private Transform bahen2;
    public void Start()
    {
        GetIndex();
        arrows = transform.Find("arrow");
        upBlue = transform.Find("up_h");
        downBlue = transform.Find("down_h");
        rightBlue = transform.Find("right_h");
        leftBlue = transform.Find("left_h");
        col = GetComponent<Collider2D>();
        water = transform.Find("water");
        waterRb = water.GetComponent<Rigidbody2D>();
        bahen1 = transform.Find("bahen/bahen1");
        bahen2 = transform.Find("bahen/bahen2");
    }

    private void Update()
    {

    }

    public void GetIndex()
    {
        RowIndex = (int)transform.position.y;
        ColIndex = (int)transform.position.x;
    }

    public bool Move(Vector3 moveDir, float moveLength)
    {
        Vector2 to = transform.position + moveDir * moveLength;
        Block b = GameApp.mapManager.mapArr[(int)to.y, (int)to.x];
        if (b.GetBlockType() == BlockType.Obstacle || b.GetBlockType() == BlockType.Wall || b.GetBlockType() == BlockType.throwAble)
        {
            return false;
        }
        else if (b.GetBlockType() == BlockType.breakable)
        {
            GameApp.gameManager.gameCount++;
            GameApp.barManager.UpdateLiveBar();
            int i = GameApp.mapManager.obsIndex[(int)to.y, (int)to.x];
            Destroy(GameApp.mapManager.obses[i].gameObject);
            return false;
        }
        else if (b.GetBlockType() == BlockType.HighPlace)
        {
            if (RowIndex != b.RowIndex - 1 || ColIndex != b.ColIndex)
            {
                return false;
            }
        }
        GameApp.gameManager.gameCount++;
        GameApp.barManager.UpdateLiveBar();
        StartCoroutine(PlayerMoveAnimate(to));
        return true;
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public IEnumerator PlayerMoveAnimate(Vector3 to)
    {
        float elapsed = 0f;
        float duration = .1f;
        
        col.enabled = false;
        Vector3 from = transform.position;
        GameApp.playerInputManager.canMove = false;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        GameApp.playerInputManager.canMove = true;

        transform.position = to;
        col.enabled = true;
        col.enabled = true;
        chuansonged = false;
        GetIndex();
    }

    public void AllBlueArrowsSetToFalse()
    {
        upBlue.gameObject.SetActive(false);
        downBlue.gameObject.SetActive(false);
        rightBlue.gameObject.SetActive(false);
        leftBlue.gameObject.SetActive(false);
    }

    public void ChuanSong(Vector2 pos)
    {
        transform.position = pos;
        GetIndex() ;
    }

    public void WaterShoot(Vector2 dir)
    {
        waterRb.velocity = dir*3;
        col.enabled = false;
        this.water.position = transform.position;
        GameApp.playerInputManager.canMove=false;
        GameApp.gameManager.deadNum--;
        GameApp.barManager.UpdateDeadBar();
    }

    public void WindMove(Vector3 toPos)
    {
        StartCoroutine(PlayerMoveAnimate(new Vector2(toPos.y,toPos.x)));
    }


}

