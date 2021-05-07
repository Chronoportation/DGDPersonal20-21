using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public GameObject healthBar;
    public TextMeshProUGUI enemiesText;
    public Button restartButton;
    public Button startButton;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        enemiesText.text = "Enemies Left: " + spawnManager.enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesText.text = "Enemies Left: " + spawnManager.enemyCount;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        healthBar.SetActive(true);
        enemiesText.gameObject.SetActive(true);
    }
}
