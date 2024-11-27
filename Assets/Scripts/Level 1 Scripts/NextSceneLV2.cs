using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLV2 : MonoBehaviour
{
    [SerializeField] ObjectiveText objective;
    protected bool checkObjective;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        checkObjective = false;
        this.spriteRenderer.enabled = false;
    }

    public void checkLevelComplete()
    {
        if (objective.isComplete == true)
        {
            checkObjective = true;
            this.spriteRenderer.enabled = true;
        }
    }

    private void Update()
    {
        checkLevelComplete();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && checkObjective)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
