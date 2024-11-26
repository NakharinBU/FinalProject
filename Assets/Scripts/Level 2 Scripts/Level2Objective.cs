using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2Objective : MonoBehaviour
{
    public bool isComplete = false;
    [SerializeField] TextMeshProUGUI objText;
    [SerializeField] Character Boss;

    private void Start()
    {
        UpdateObjectiveTxt();
    }

    private void Update()
    {
        // ตรวจสอบว่า Objective เสร็จสิ้นหรือยัง
        if (!isComplete && Boss.Health < 0)
        {
            UpdateObjectiveStats();
        }
    }

    public void UpdateObjectiveTxt()
    {
        if (isComplete)
        {
            objText.text = $"Objective : The Slug is dead. Hurry up!, Collect The Carrot";
        }
        else
        {
            objText.text = $"Objective : Kill The Slug";
        }
    }

    public void UpdateObjectiveStats()
    {
        if (Boss.Health < 0)
        {
            isComplete = true;
            UpdateObjectiveTxt();
        }
    }

}
