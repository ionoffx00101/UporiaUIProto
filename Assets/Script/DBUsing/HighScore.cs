using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public int rank { get; set; }
    public string playerName { get; set; }
    public int score { get; set; }

    public HighScore(int rank,string playerName,int score)
    {
        this.rank = rank;
        this.playerName = playerName;
        this.score = score;
    }
}
