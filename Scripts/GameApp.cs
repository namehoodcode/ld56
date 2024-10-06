using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : Singleton<GameApp>
{
    public static MapManager mapManager;
    public static PlayerInputManager playerInputManager;
    public static GameManager gameManager;
    public static BarManager barManager;
    public static jqManager jqManager;
    
    public override void Init()
    {
        gameManager = new GameManager();
        mapManager = new MapManager();
        playerInputManager = new PlayerInputManager();
        barManager = new BarManager();
        jqManager = new jqManager();
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        playerInputManager.Update();
    }
}
