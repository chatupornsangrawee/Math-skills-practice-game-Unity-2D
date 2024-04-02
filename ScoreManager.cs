using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();

        // เรียกใช้เมธอด SaveScoreToFile เพื่อบันทึกคะแนนลงในไฟล์ .txt
        SaveScoreToFile(score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "คะแนน : " + score + " / 10";
        scoreText2.text = "คะแนน : " + score + " / 10";
    }

    private void SaveScoreToFile(int scoreValue)
    {
        string filePath = Application.streamingAssetsPath + "/score.txt"; // ระบุที่อยู่ของไฟล์ .txt ใน StreamingAssets
        string scoreData = "คะแนน : " + scoreValue + " / 10";

        // เขียนข้อมูลลงในไฟล์ .txt
        File.WriteAllText(filePath, scoreData);

        Debug.Log("บันทึกคะแนนลงในไฟล์แล้ว");
    }
}
