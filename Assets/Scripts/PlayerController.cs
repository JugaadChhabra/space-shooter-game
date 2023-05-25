using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityStandardAssests.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public bool isShoot;

    GameManager gameManager;
    public GameObject gamemanager;
    private float playerSpeed = 0.01f;
    private Touch touch;

    public float speed = 10f;
    public static float DestroyTime = 5f;
    public float shipBoundaryRadius = 0.5f;
    public static AudioSource shoot;


    [Header ("Flash")]
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    private SpriteRenderer spriteRenderer;

    // [Header("Missile")]
    // public GameObject missile;
    // public GameObject MuzzleFlash;
    // public Transform MissileSpawnPosition;
    // public Transform MuzzleSpawnPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    void Awake()
    {
        gameManager = gamemanager.GetComponent<GameManager>();
    }

    void Update()
    {        

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved && GameManager.i == 0) 
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * playerSpeed, transform.position.y,0);
                // MissileShoot();
            }
        }

        float xpos = SimpleInput.GetAxis("Horizontal");
        // float ypos = SimpleInput.GetAxis("Vertical");
        Vector3 movement = new Vector3(xpos,0,0) * speed * Time.deltaTime;
        transform.Translate(movement);

        float ScreenRatio = (float) Screen.width / (float) Screen.height;
        float widthOrtho = ScreenRatio;

        if (xpos + shipBoundaryRadius > widthOrtho)
        {
            xpos = widthOrtho - shipBoundaryRadius;
        }
    }

    // public void MissileShoot()
    // {
    //     if (checkShooting)
    //     {
    //         Debug.Log("SHOOTING");
    //         InvokeRepeating("missileShoot",0f,0.5f);
    //     }
    // }
    
    // public void missileShoot()
    // {
    //     // if (MissileCount.mcount != 0)
    //     shoot.Play();
    //     SpawnMuzzleFlash();
    //     SpawnMissile();
    //     // MissileCount.mcount -= 1;
    // }
    
    // void PlayerShoot()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         SpawnMissile();
    //         SpawnMuzzleFlash();
    //     }
    // }

    // public void SpawnMissile()
    // {
    //     GameObject gm = Instantiate(missile, MissileSpawnPosition);
    //     gm.transform.SetParent(null);
    //     Destroy(gm, DestroyTime);
    // }

    // public void SpawnMuzzleFlash()
    // {
    //     GameObject muzzle = Instantiate(MuzzleFlash, MuzzleSpawnPosition);
    //     muzzle.transform.SetParent(null);
    //     Destroy(muzzle, DestroyTime);
    // }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2") && LifeManager.life == 1)
        {
            Debug.Log(LifeManager.life);
            Destroy(this.gameObject);
            Time.timeScale = 0f;
            gameManager.GameOverMenu.SetActive(false);
            ScoreManager.Final_Score = ScoreManager.score;
            gameManager.BGM.Stop();
            gameManager.FireButton.SetActive(false);
            gameManager.Joystick.SetActive(false);
            gameManager.Heart.SetActive(false);
            gameManager.Score.SetActive(false);
            gameManager.Lives.SetActive(false);
            gameManager.Countdown.SetActive(false);
            // gameManager.Missilecount.SetActive(false);
            Debug.Log("Game Over");
        }

        else if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2") && flashRoutine == null)
        {
            flashRoutine = StartCoroutine(FlashRoutine());
            LifeManager.life = LifeManager.life - 1; 
            Debug.Log("Hit");
        }
    }  
}
