using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private BomberMan bomberMan;
    [SerializeField] EnemyController enemyController;

    private void Start()
    {
        bomberMan = FindObjectOfType<BomberMan>();
        if (bomberMan != null)
        {
            bomberMan.OnPlayerDeath += StartGameOverSequence;
        }
        enemyController.OnPlayerDeath += StartGameOverSequence;
        
    }

    private void OnDisable()
    {
        if (bomberMan != null)
        {
            bomberMan.OnPlayerDeath -= StartGameOverSequence;
        }
    }

    private void StartGameOverSequence()
    {
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(3); 
        EnableGameOverMenu();
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true); 
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLevelMenu()
    {
        SceneManager.LoadScene(1);
    }
}