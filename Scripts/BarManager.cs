using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarManager
{
    public Slider liveBarSlider;
    private TextMeshProUGUI liveNum;
    public int liveNumMax;
    public Slider deadBarSlider;
    private TextMeshProUGUI deadNum;
    public int deadNumMax;
    private int count => GameApp.gameManager.gameCount;
    private int deadCount => GameApp.gameManager.deadNum;   
    public BarManager()
    {
        liveBarSlider = GameObject.Find("Canvas/FireSlider").GetComponent<Slider>();
        liveNum = GameObject.Find("Canvas/NumManager/fireNum").GetComponent<TextMeshProUGUI>();
        liveNumMax = 12;
        deadBarSlider = GameObject.Find("Canvas/WaterSlider").GetComponent<Slider>();
        deadNum = GameObject.Find("Canvas/NumManager/waterNum").GetComponent<TextMeshProUGUI>();
        deadNumMax = 3;
    }

    public void Init()
    {
        liveBarSlider.value = 1;
        deadBarSlider.value = 0;
        liveNum.text = liveNumMax.ToString();
        deadNum.text = "0"; 
    }


    public void UpdateLiveBar()
    {
        if(GameApp.gameManager.currentSceneIndex == 5)
        {
            liveNum.text = "12";
            liveBarSlider.value = 1;
            return;
        }

        if((liveNumMax - count) <= 0)
        {
            liveNum.text = "0";
        }
        else
        {
            liveNum.text = (liveNumMax - count).ToString();
        }
        liveBarSlider.value = (float)(liveNumMax - count) / liveNumMax;
    }

    public void UpdateDeadBar()
    {
        if (GameApp.gameManager.currentSceneIndex == 5)
        {
            deadNum.text = "3";
            deadBarSlider.value = 1;
            return;
        }

        if (deadCount >= deadNumMax)
        {
            deadNum.text = deadNumMax.ToString();
        }
        else
        {
            deadNum.text = deadCount.ToString();
        }
        deadBarSlider.value = (float)deadCount / deadNumMax;
    }

    public void ResetNum()
    {
        GameApp.gameManager.gameCount = 0;
        GameApp.gameManager.deadNum = 0;
        UpdateLiveBar();
        UpdateDeadBar();
    }
}
