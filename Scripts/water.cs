using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (collision.gameObject.GetComponent<Block>() || collision.gameObject.GetComponent<fire>())
        {
            return;
        }
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
        GameApp.playerInputManager.canMove = true;
        GameApp.gameManager.player.col.enabled = true;
    }
}
