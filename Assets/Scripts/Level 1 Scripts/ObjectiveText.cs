using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveText : MonoBehaviour
{
    public bool isComplete = false;
    private int kills = 0;
    [SerializeField] TextMeshProUGUI objText;
    [SerializeField] Character[] numOfEnemy;

    private void Start()
    {
        UpdateObjectiveTxt();
    }


    public void UpdateObjectiveTxt() 
    {
        objText.text = $"Objective : Destroy {kills} / {numOfEnemy.Length} Tree of Bee";
    }


    public void UpdateKills() 
    {
        kills++;
        if (kills == numOfEnemy.Length)
        {
            isComplete = true;
        }
        UpdateObjectiveTxt();
    }

}
