using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private CameraUtil _cameraUtil;
    private AsteroidManager asteroidManager;
    private ShipPlayerManager shipPlayerManager;

    private GameUIManager _gameUIManager;
    [SerializeField]
    private RankingManager _rankingManager;
    private ColorManager colorManager;

    private int score = 0;
    private int lvl = 0;
    
    
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public CameraUtil CameraUtil
    {
        get => _cameraUtil;
        set => _cameraUtil = value;
    }

    public AsteroidManager AsteroidManager
    {
        get => asteroidManager;
        set => asteroidManager = value;
    }

   

    public GameUIManager GameUIManager
    {
        get => _gameUIManager;
        set => _gameUIManager = value;
    }

    public ColorManager ColorManager
    {
        get => colorManager;
        set => colorManager = value;
    }

    public ShipPlayerManager PlayerManager
    {
        get => shipPlayerManager;
        set => shipPlayerManager = value;
    }


    private void Awake()
    {
        asteroidManager = FindObjectOfType<AsteroidManager>();
        _gameUIManager = FindObjectOfType<GameUIManager>();
        shipPlayerManager = FindObjectOfType<ShipPlayerManager>();
        _cameraUtil = FindObjectOfType<CameraUtil>();
        colorManager = FindObjectOfType<ColorManager>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }

    }

    public static void CreateInstance()
    {
        if (instance == null)
        {
            new GameObject("GameManager", typeof(GameManager));
        }
    }

    public void addScore(int objectScore)
    {
        score += objectScore;
        _gameUIManager.updateScore(score);
    }

    public void updateLvl()
    {
        lvl++;

        if (!shipPlayerManager.checkEvents())
        {
            advanceLvl();
        }
        
    }

    public void finishGame()
    {
        Invoke(nameof(showRanking),_gameUIManager.showGameOver());
        
    }

    public void showRanking()
    {

        _rankingManager.addScore(score);
    }
    public void advanceLvl()
    {
        _cameraUtil.changeMusic();
        asteroidManager.startLvl(lvl);
        _gameUIManager.updateLvl(lvl);
    }

    public void restarLvl()
    {
        SceneManager.LoadScene(0);
    }
}
