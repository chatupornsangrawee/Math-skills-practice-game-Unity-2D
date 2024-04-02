using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objectsToToggle; // อาร์เรย์ของเกมออบเจ็กต์ที่จะสุ่มเปิด/ปิดใช้งาน
    private int n = 0;
    public GameObject objectSSS;

    private List<int> usedIndexes = new List<int>(); // เก็บ index ที่ถูกเปิดใช้งานไปแล้ว

    void Start()
    {
        StartCoroutine(CheckAllObjectsDisabled());
    }

    IEnumerator CheckAllObjectsDisabled()
    {
        while (true)
        {
            // ตรวจสอบว่าวัตถุทั้งหมดถูกปิดใช้งานหรือไม่
            bool allDisabled = true;
            foreach (GameObject obj in objectsToToggle)
            {
                if (obj.activeSelf)
                {
                    allDisabled = false;
                    break;
                }
            }

            // ถ้าวัตถุทั้งหมดถูกปิดใช้งานแล้ว ให้ทำการสุ่มเปิดใช้งานวัตถุใหม่
            if (allDisabled)
            {
                n++;
                if (n < 11)
                {
                    if (!ToggleRandomObject()) // ตรวจสอบว่าสามารถสุ่มเปิดใช้งานอ็อบเจ็กต์ได้หรือไม่
                    {
                        Debug.Log("Cannot toggle more objects. All objects are enabled.");
                        break; // หยุดการทำงานของ Coroutine เมื่อไม่สามารถสุ่มเปิดใช้งานอ็อบเจ็กต์ได้แล้ว
                    }
                }
                else if (n == 11)
                {
                    objectSSS.SetActive(true); // ปิดการใช้งานวัตถุที่กำหนด
                }
            }

            // รอสักครู่ก่อนที่จะทำการตรวจสอบอีกครั้ง
            yield return new WaitForSeconds(0.01f);
        }
    }

    bool ToggleRandomObject()
    {
        List<int> availableIndexes = new List<int>();

        // ตรวจสอบและเก็บ index ของอ็อบเจ็กต์ที่ยังไม่ถูกเปิดใช้งาน และไม่ได้เปิดใช้งานไปแล้ว
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            if (!objectsToToggle[i].activeSelf && !usedIndexes.Contains(i))
            {
                availableIndexes.Add(i);
            }
        }

        // ตรวจสอบว่ามีอย่างน้อย 1 วัตถุที่ยังไม่ถูกเปิดใช้งาน
        if (availableIndexes.Count > 0)
        {
            // สุ่ม index จาก List ของอ็อบเจ็กต์ที่ยังไม่ถูกเปิดใช้งาน
            int randomIndex = Random.Range(0, availableIndexes.Count);
            int objectIndex = availableIndexes[randomIndex]; // เลือก index จาก List
            objectsToToggle[objectIndex].SetActive(true); // เปิดใช้งานอ็อบเจ็กต์ตาม index ที่สุ่มได้

            // เพิ่ม index ที่ใช้งานแล้วลงใน List เพื่อไม่ให้สุ่ม index นี้อีก
            usedIndexes.Add(objectIndex);

            return true; // สามารถสุ่มเปิดใช้งานได้
        }

        return false; // ไม่สามารถสุ่มเปิดใช้งานได้
    }
}
