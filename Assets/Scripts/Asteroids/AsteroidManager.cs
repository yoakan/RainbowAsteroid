
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private PushAsteroidPoint[] points;
    [SerializeField]
    private GameObject[] asteroidType;

    private ColorManager colorManager;
    
    [SerializeField] private float forcePush = 2;
    private List<GameObject> asteroids = new List<GameObject>();
    [Header("LvlAdjust")]
    [SerializeField]
    private int lengtAsteroidDefault =4;

    private int addAsteroid = 0;

    //Obeder el orden que se usa en astroidType
    [SerializeField]
    private int probAsteroidSmall = 60;
    [SerializeField]
    private int probAsteroidMedium = 30;
    [SerializeField]
    private int probAsteroidBig = 10;
    private void Start()
    {
        colorManager = GameManager.Instance.ColorManager;
        generateAsteroid();
    }

    public void startLvl(int lvl)
    {
        rulesAsteroidLvl(lvl);
        generateAsteroid();
    }

    private void rulesAsteroidLvl(int lvl)
    {
        if(lvl<30)
            addAsteroid++;
        if (lvl / 10 == 0)
        {
            probAsteroidSmall -= 2;
            probAsteroidMedium += 2;
        }else if (lvl / 20 == 0)
        {
            probAsteroidSmall -= 3;
            probAsteroidMedium += 1;
            probAsteroidBig += 2;
        }else if (lvl / 30 == 0)
        {
            probAsteroidMedium -= 3;
            probAsteroidBig += 3;
        }
    }

    private void generateAsteroid()
    {
        int countAsteoroid = lengtAsteroidDefault + addAsteroid;
        for (int i = 0; i < countAsteoroid; i++)
        {
            GameObject asteroid=Instantiate(selectTypeAsteroid(), this.transform);
            int roundIdex = i - points.Length*(i/points.Length);
           // print("INDEX ROUND: "+roundIdex);
            asteroid.transform.position = points[roundIdex].transform.position;
            asteroid.GetComponent<Asteroid>().setColor(colorManager.getRandomColorItem());
            points[roundIdex].pushAsteroid(asteroid.GetComponent<Rigidbody2D>(),forcePush);
            asteroids.Add(asteroid);
        }
    }

    private GameObject selectTypeAsteroid()
    {
        int selected = 0;
        int probability = Random.Range(0, probAsteroidSmall+probAsteroidMedium+probAsteroidBig);
        if (probability > 0 && probability < probAsteroidSmall)
        {
            selected = (int)AsteroidType.Small;
        }else if (probability > probAsteroidSmall && probability < probAsteroidSmall + probAsteroidMedium)
        {
            selected = (int)AsteroidType.Medium;
        }else if (probability > probAsteroidSmall + probAsteroidMedium)
        {
            selected = (int)AsteroidType.Big;
        }
        return asteroidType[selected];
    }

    public void generateAsteroidsChildren(GameObject[] asteroids,Vector3 position,Asteroid asteroidFather)
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            GameObject asteroid= Instantiate(asteroids[i],this.transform);
            asteroid.transform.position = position ;
            asteroid.GetComponent<Asteroid>().setColor(asteroidFather.getColorItem());
            asteroid.GetComponent<Asteroid>().SpriteUsed = asteroidFather.SpriteUsed;
            asteroid.GetComponent<Rigidbody2D>().AddForce(randomMoveAsteroid()*forcePush*asteroidFather.ForceMiniChild);
            this.asteroids.Add(asteroid);
        }
    }
    private Vector2 randomMoveAsteroid()
    {
        return new Vector2(Random.Range(-1, 1),Random.Range(-1, 1));
    }
    public void quitAsteroid(GameObject asteroid)
    {
        int indexAsteroid = asteroids.IndexOf(asteroid);
        if (indexAsteroid!=-1)
        {
            asteroids.Remove(asteroids[indexAsteroid]);
            if (asteroids.Count == 0)
            {
                GameManager.Instance.updateLvl();
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject asteroid in asteroids)
        {
            
        }
    }
}
