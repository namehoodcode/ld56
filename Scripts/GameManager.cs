using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Player player;
    public int gameCount;
    public int deadNum;
    public int currentSceneIndex;

    public GameManager()
    {
        player = GameObject.FindGameObjectWithTag("ship").GetComponent<Player>();
    }
}
