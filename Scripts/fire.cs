using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "water")
        {
            return;
        }
        GameApp.gameManager.gameCount = 0;
        GameApp.barManager.UpdateLiveBar();
        Destroy(this.gameObject);
    }
}
