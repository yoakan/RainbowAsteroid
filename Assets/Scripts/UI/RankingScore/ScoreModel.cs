using System;
using UnityEngine;

[Serializable]
public class ScoreModel
{
    
    public string name;
    
    public int score;

    public ScoreModel(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
