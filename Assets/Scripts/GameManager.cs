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
    private GameObject enemyIndicator;

    // Start is called before the first frame update
    void Start()
    {
        //set up enemy system
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        enemiesText.text = "Enemies Left: " + spawnManager.enemyCount;

        //set up enemy indicator
        enemyIndicator = GameObject.Find("Enemy Indicator");
        enemyIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //display the number of enemies left to destroy
        enemiesText.text = "Enemies Left: " + spawnManager.enemyCount;
    }

    //method to initiate procedures for ending the game
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        enemyIndicator.SetActive(false);
    }

    //method to reset the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //method to initiate the game to a playable state
    public void StartGame()
    {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        healthBar.SetActive(true);
        enemiesText.gameObject.SetActive(true);
        enemyIndicator.SetActive(true);
    }
}
