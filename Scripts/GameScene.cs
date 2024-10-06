using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private float dt;
    private static bool isLoaded = false;
    
    private void Awake()
    {
        if (isLoaded)
        {
            Destroy(gameObject);
        }
        else
        {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);
            GameApp.Instance.Init();
        }
    }
    void Start()
    {
        GameApp.mapManager.Init();
        GameApp.playerInputManager.Init();
        GameApp.mapManager.ObsDeal();
        GameApp.barManager.Init();
        GameApp.jqManager.UpdateText();
    }


    void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
        if (Input.GetKeyDown(KeyCode.R))
        {
            int i = GameApp.gameManager.currentSceneIndex;
            GameApp.mapManager.isRemaking = true;
            Destroy(GameApp.mapManager.obsPack[i]);
            GameApp.mapManager.obsPack[i] = Instantiate(Resources.Load($"Prefabs/obses{i}")) as GameObject;
            GameApp.mapManager.ObsDeal();
            GameApp.barManager.ResetNum();
            GameApp.gameManager.player.transform.position = new Vector2(GameApp.mapManager.playerPos[2 *i],GameApp.mapManager.playerPos[2 * i + 1]);
        }
        else
        {
            GameApp.mapManager.isRemaking=false;
        }
    }
}
