using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreText;
        
    void Update()
    {
        ScoreText.text = $"Score: {Score}";
    }
}
