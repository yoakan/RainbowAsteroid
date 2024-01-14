using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class RankingManager : MonoBehaviour
{
    [SerializeField] private Transform layaoutPrefabScore;
    [SerializeField] private GameObject PrefabScoreModel;
    [SerializeField] private int sizeScore = 10;
    [SerializeField] private String urlScore="Assets/Resource/Scores.json";
    [SerializeField] 
    private ScoresModel scoresModel;

    private Button _button;
    private List<ScoreView> scoreViews = new List<ScoreView>();
    private int scoreModify = -1;
    private bool existScore = false;
    [SerializeField] private TextAsset json;
    private void Awake()
    {
        _button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        
        //scoresModel.scores.OrderBy(c=> c.score);
        if (!existScore)
        {
            createScoreView();
        }
    }

    private void addViewScore()
    {
        for (int i = 0; i < sizeScore; i++)
        {
            ScoreView scoreView = Instantiate(PrefabScoreModel, layaoutPrefabScore).GetComponent<ScoreView>();
            scoreView.addTexts((i+1).ToString(),scoresModel.getScore(i));
            scoreViews.Add(scoreView);
        }
    }
    private void modifyViewScore()
    {
        for (int i = 0; i < sizeScore; i++)
        {
            scoreViews[i].addTexts((i+1).ToString(),scoresModel.getScore(i));
            
        }
    }
    public void addScore(int score)
    {

        existScore = true;
        createScoreView();
        this.gameObject.SetActive(true);
        int position = scoresModel.getScoreUp(score);
        if (position != -1)
        {
            scoresModel.setScore(position,new ScoreModel("", score)) ;
            scoreModify = position;
            scoreViews[position].modifyScore(score);
            modifyViewScore();
             _button.enabled = false;
            
            
        }
        else
        {
            scoresModel.addScore(new ScoreModel("BadScore",score));
        }
    }

    private void createScoreView()
    {
       print(Application.dataPath+urlScore);
        //scoresModel = JsonUtils.getJsonObject<ScoresModel>(Application.dataPath+urlScore);
        scoresModel = JsonUtility.FromJson<ScoresModel>(json.text);
        print("QUE TENGOOO "+JsonUtility.ToJson(scoresModel));
        addViewScore();
    }

    public void modifyScore(string name)
    {
        _button.enabled = true;
        scoresModel.setNameScore(scoreModify,name) ;
    }

    private void OnDisable()
    {
        scoresModel.sortScore();
        
        JsonUtils.writeJsonWebObject(urlScore,scoresModel);
        //JsonUtils.writeJsonObject(json,scoresModel);
    }

    
}
