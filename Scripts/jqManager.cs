using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
public class jqManager
{
    private TMPro.TextMeshProUGUI textMeshPro;
    private TMPro.TextMeshProUGUI textMeshPro1;
    private string[] str = new string[6] { "task 1", "task 2", "task 3", "task 4", "task 5", "task 6" };
    private string[] str1 = new string[6] { "Retrieve the chlorella that a sardine has eaten.", "The sardine is angry. Come back quickly!",
    "A snake has entered our territory. Let's show it who's boss.","It's a school of fish, quick, retreat!","It's a catfish. We need to escape before it digests you.","Weekend! Thank you for your playing"};

    public jqManager() 
    {
        textMeshPro = GameObject.Find("Canvas/jqte/jvqingText").GetComponent<TMPro.TextMeshProUGUI>();
        textMeshPro1 = GameObject.Find("Canvas/jqte/jvqingText1").GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        int i = GameApp.gameManager.currentSceneIndex;
        textMeshPro.text = str[i];
        textMeshPro1.text = str1[i];
    }

}
