using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;

    public GameObject pauseUI;
    public Text endMessage;

    public static GameManager instance;
    private EnemySpawner enemySpawner;

    private void Awake() {
        instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Update() {
        if (Input.GetKey ("escape")){
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnButtonContinue(){
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Win(){
        endMessage.text = "Victory";
        endUI.SetActive(true);
        
    }

    public void Lose(){
        enemySpawner.stop();
        endMessage.text = "Defeat";
        endUI.SetActive(true);
        
    }

    public void OnButtonRetry(){
        Time.timeScale = 1;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void OnButtonMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene( 0 );
    }
}
