
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ScoresModel
{
    public List<ScoreModel> scores;
    //public ScoreModel[] scores;
    public ScoreModel getScore(int i)
    {
        return scores[i];
    }

    public void setScore(int i , ScoreModel scoreModel)
    {
        scores.Insert(i,scoreModel);
    }

    public void sortScore()
    {
        scores= scores.OrderByDescending(c=> c.score).ToList();
    }

    public void setNameScore(int i , string scoreName)
    {
        scores[i].name = scoreName;
    }

    public int getScoreUp(int score)
    {
        return scores.FindIndex(s => s.score < score);
    }

    public void addScore(ScoreModel scoreModel)
    {
        scores.Add(scoreModel);
    }
}
