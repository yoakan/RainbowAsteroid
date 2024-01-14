
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUi : MonoBehaviour
{
    [SerializeField] private GameObject ranking;
    [SerializeField] private GameObject asteroids;
    [SerializeField] private GameObject spacesTutorial;
    [SerializeField] private GameObject infoTutorial;

    
    [SerializeField] private float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        //play.color = Color.Lerp(Color.white, Color.clear, Time.deltaTime * velocity);
    }

    // Update is called once per frame
   

    public void chechRanking(bool active)
    {
        ranking.SetActive(active);
        this.gameObject.SetActive(!active);
    }

    public void checkTutorial(bool active)
    {
        this.infoTutorial.SetActive(active);
        this.spacesTutorial.SetActive(active);
        this.asteroids.SetActive(!active);
        this.gameObject.SetActive(!active);
        print("HOLAAA");
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void guideGame()
    {
        
    }

    
}
