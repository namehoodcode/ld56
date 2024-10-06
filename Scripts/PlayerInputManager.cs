using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputManager
{
    Player player;
    public bool canMove = true;
    public bool isCanceling;
    public Vector3 mouseVecMinusTrans => Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
    private Vector2 shootDir;
    public bool qiehuan;
    public Vector2[] playerPos;
    private int sceneCount;
    private GameObject kaishi;

    public PlayerInputManager()
    {
        playerPos = new Vector2[2] { new Vector2( 1, 9 ), new Vector2 ( 1, 1 ) };
        kaishi = GameObject.Find("Canvas/kaishi");
    }

    public void Init()
    {
        this.player = GameApp.gameManager.player;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            kaishi.SetActive(false);
        }

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (PlayerFireRunOut())
                {
                }
                else
                {
                    player.Move(Vector3.up, 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (PlayerFireRunOut())
                {
                }
                else
                {
                    player.Move(Vector3.down, 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (PlayerFireRunOut())
                {
                }
                else
                {
                    player.Move(Vector3.left, 1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (PlayerFireRunOut())
                {
                }
                else
                {
                    player.Move(Vector3.right, 1f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(GameApp.gameManager.deadNum == 0)
            {
                return;
            }
            if (isCanceling)
            {
                player.AllBlueArrowsSetToFalse();
            }
            canMove = isCanceling;
            isCanceling = !isCanceling;
            player.arrows.gameObject.SetActive(isCanceling);
        }

        if (isCanceling)
        {
            if(mouseVecMinusTrans.y<mouseVecMinusTrans.x)
            {
                if(mouseVecMinusTrans.y > -mouseVecMinusTrans.x)
                {
                    player.AllBlueArrowsSetToFalse();
                    player.rightBlue.gameObject.SetActive(true);
                    shootDir = Vector2.right;
                }
                else
                {
                    player.AllBlueArrowsSetToFalse();
                    player.downBlue.gameObject.SetActive(true);
                    shootDir = Vector2.down;
                }
            }
            else
            {
                if(mouseVecMinusTrans.y> -mouseVecMinusTrans.x)
                {
                    player.AllBlueArrowsSetToFalse();
                    player.upBlue.gameObject.SetActive(true);
                    shootDir = Vector2.up;
                }
                else
                {
                    player.AllBlueArrowsSetToFalse();
                    player.leftBlue.gameObject.SetActive(true);
                    shootDir = Vector2.left;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && isCanceling)
        {
            if (isCanceling)
            {
                player.AllBlueArrowsSetToFalse();
            }
            canMove = isCanceling;
            isCanceling = !isCanceling;
            player.arrows.gameObject.SetActive(isCanceling);
            player.water.gameObject.SetActive(true);
            player.WaterShoot(shootDir);
        }
    }

    private bool PlayerFireRunOut() => GameApp.barManager.liveBarSlider.value == 0;

}
