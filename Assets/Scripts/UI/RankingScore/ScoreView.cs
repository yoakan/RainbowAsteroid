using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text position;
    [SerializeField] private Text name;
    [SerializeField] private InputField nameInput;
    [SerializeField] private Text score;
    
    private bool modifyText =false;
    public void addTexts(String position,ScoreModel score)
    {
        this.position.text = position;
        this.name.text = score.name;
        this.score.text = score.score.ToString();
    }

    public void modifyScore(int newScore)
    {
        this.score.text = newScore.ToString();
        activeName(false);
        nameInput.ActivateInputField();
        
        modifyText = true;
    }

    private void activeName(bool activate)
    {
        name.gameObject.SetActive(activate);
        nameInput.gameObject.SetActive(!activate);
    }
    private void Update()
    {
        if (modifyText)
        {
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.KeypadEnter))
            {
                modifyText = false;
                this.name.text = nameInput.text;
                activeName(true);
                GetComponentInParent<RankingManager>().modifyScore(name.text);
            }
        }
    }
}
