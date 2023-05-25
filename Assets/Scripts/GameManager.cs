using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool startGame;

    public static GameManager instance;
    public float MinInstantiateValue;
    public float MaxInstantiateValue;
    public float EnemyDestroyTime = 3f;
    public float spawnRate = 1f;
    
    public static int i = 1;

    [Header("Particle Effects")]
    public GameObject Explosion;
    public GameObject MuzzleFlash;
    
    [Header("Pannels")]
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject FireButton;
    public GameObject Joystick;
    public GameObject Heart;
    public GameObject Score;
    public GameObject Lives;
    public GameObject Countdown;
    public AudioSource BGM;
    public static AudioSource boom;



    private void Start()
    {
        StartCoroutine("gamestart");
        // StartMenu.SetActive(true);
        // PauseMenu.SetActive(false);
        // GameOverMenu.SetActive(false);
        // FireButton.SetActive(false);
        // Joystick.SetActive(false);
        // Heart.SetActive(false);
        // Score.SetActive(false);
        // Lives.SetActive(false);
        // Player.SetActive(false);
        // Countdown.SetActive(false);
        // // Missilecount.SetActive(false);
        // Time.timeScale = 0f;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     ResumeGame(true);
        // }
    }

    public IEnumerator enemySpawn()
    {
        EnemyController enemy = new EnemyController();

        while (spawnRate > 0.5f)
        {
            InvokeRepeating("InstantiateEnemy", 0.5f, spawnRate);
            InvokeRepeating("InstantiateEnemy2", 2f, 1.5f);
            yield return new WaitForSeconds(15f);
            if (spawnRate > 0.3f )
            {
                spawnRate -= 0.2f;
            }
        }
        
    }


    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(MinInstantiateValue, MaxInstantiateValue), (6f));
        GameObject enemy = Instantiate(Enemy, enemypos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy, EnemyDestroyTime);
    }

    void InstantiateEnemy2()
    {
        Vector3 enemypos2 = new Vector3(Random.Range(MinInstantiateValue, MaxInstantiateValue), (6f));
        GameObject enemy2 = Instantiate(Enemy2, enemypos2, Quaternion.Euler(0f, 0f, 180f));
        Destroy(enemy2, EnemyDestroyTime);
    }

    public void StartGameButton()
    {
        StartCoroutine("gamestart");
    }

    public void ResumeGame(bool isPause)
    {
        if (isPause == true)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            FireButton.SetActive(false);
            Joystick.SetActive(false);
            BGM.Stop();
        }

        else
        {
            PauseMenu.SetActive(false);
            FireButton.SetActive(true);
            Joystick.SetActive(false);
            Time.timeScale = 1f;
            BGM.Play();
        }
    }

    public void RestartTheGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("GameScene");
        i = 1;
        countdowntimer.CountDown = 1;
        LifeManager.life = 3;
        ScoreManager.score = 0;
        MissileCount.mcount = 50;
        Time.timeScale = 1f;
        Debug.Log("It works.");
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator gamestart()
    {
        while (i != 0)
        {
            Countdown.SetActive(true);
            StartMenu.SetActive(false);
            Player.SetActive(true);
            Time.timeScale = 1f;
            yield return new WaitForSeconds(1f);
            Debug.Log(countdowntimer.CountDown);
            if (countdowntimer.CountDown < 1)
            {
                Time.timeScale = 1f;
                Debug.Log("entered for loop countdown ke baad");
                // InvokeRepeating("InstantiateEnemy", 0.5f, spawnRate);
                StartCoroutine("enemySpawn");
                Countdown.SetActive(false);
                Joystick.SetActive(false);
                FireButton.SetActive(true);
                Heart.SetActive(true);
                Score.SetActive(false);
                Lives.SetActive(true);
                // Missilecount.SetActive(true);
                BGM.Play();
                startGame = true;
            }
            i--;
        }
    }
}