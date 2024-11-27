using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2Objective : MonoBehaviour
{
    public bool isComplete = false;
    public bool isCollectedCarrot = false;
    [SerializeField] TextMeshProUGUI objText;
    [SerializeField] Player player;
    [SerializeField] Character boss;

    private void Start()
    {
        UpdateObjectiveTxt();
    }

    private void Update()
    {
        UpdateObjectiveStats();
    }

    public void UpdateObjectiveTxt()
    {
        if (isComplete && !isCollectedCarrot)
        {
            objText.text = $"Objective : The Slug is dead. Hurry up!, Collect The Carrot";
        }
        else if (isComplete && isCollectedCarrot)
        {
            objText.text = $"Objective : Get into the house";
        }
        else
        {
            objText.text = $"Objective : Kill The Slug";
        }
    }

    public void UpdateObjectiveStats()
    {
        if (boss.Health < 0 && !isCollectedCarrot)
        {
            isComplete = true;
            UpdateObjectiveTxt();
        }

        if (isComplete && !isCollectedCarrot && player.NumOfCarrot >= 1)
        {
            isCollectedCarrot = true;
            UpdateObjectiveTxt();
        }
    }

}
