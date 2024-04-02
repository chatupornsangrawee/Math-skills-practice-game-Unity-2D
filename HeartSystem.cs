using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public int maxHearts = 3; // จำนวนหัวใจสูงสุด
    public int currentHearts; // จำนวนหัวใจปัจจุบัน
    public RawImage[] heartImages; // RawImage ที่ใช้แสดงหัวใจใน UI

    void Start()
    {
        currentHearts = maxHearts; // กำหนดจำนวนหัวใจเริ่มต้นเป็นจำนวนหัวใจสูงสุด
        UpdateHeartsUI(); // อัปเดต UI หัวใจ
    }

    // เพิ่มหัวใจ
    public void AddHearts(int amount)
    {
        currentHearts = Mathf.Min(currentHearts + amount, maxHearts); // ไม่ให้เกินจำนวนหัวใจสูงสุด
        UpdateHeartsUI(); // อัปเดต UI หัวใจ
    }

    // ลดหัวใจ
    public void RemoveHearts(int amount)
    {
        currentHearts = Mathf.Max(currentHearts - amount, 0); // ไม่ให้ต่ำกว่า 0
        UpdateHeartsUI(); // อัปเดต UI หัวใจ
        if (currentHearts == 0)
        {
            // โหลดฉาก GAMEOVER เมื่อหัวใจลดเหลือ 0
            SceneManager.LoadScene("GAMEOVER");
        }
    }

    // อัปเดต UI หัวใจ
    void UpdateHeartsUI()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                heartImages[i].enabled = true; // เปิดใช้งาน RawImage ตามจำนวนหัวใจปัจจุบัน
            }
            else
            {
                heartImages[i].enabled = false; // ปิดใช้งาน RawImage ตามจำนวนหัวใจปัจจุบัน
            }
        }
    }

    public void OnButtonClick()
    {
        RemoveHearts(1); // ลดจำนวนเลือดลง 1
    }
}