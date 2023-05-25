using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_textholder;
    public TextMeshProUGUI Final_Score_holder;
    public static int score = 0;
    public static int Final_Score = 0;
    
    void Update()
    {
        score_textholder.text = score.ToString();
        Final_Score_holder.text = Final_Score.ToString();
    }
}
