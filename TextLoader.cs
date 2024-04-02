using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour
{
    public Text displayText;

    void Start()
    {
        LoadTextFromFile();
    }

    void LoadTextFromFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "score.txt");

        // ตรวจสอบว่าไฟล์มีอยู่จริงหรือไม่ก่อนทำการโหลด
        if (File.Exists(filePath))
        {
            string textData = File.ReadAllText(filePath);
            displayText.text = textData; // กำหนดข้อความที่โหลดได้ให้กับ UI Text
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}
