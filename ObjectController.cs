using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToDisable; // ตัวแปร public เพื่อเก็บวัตถุที่ต้องการปิดใช้งาน

    void Start()
    {
        // หาปุ่ม UI ที่ต้องการใช้งานและกำหนดให้เรียกใช้งานเมธอด DisableObject เมื่อกด
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(DisableObject);
        }
    }

    void DisableObject()
    {
        // ตรวจสอบว่า objectToDisable ไม่เป็น null และตัวอ้างอิงยังไม่ถูกทำลายก่อนที่จะปิดการใช้งาน
        if (objectToDisable != null && !objectToDisable.Equals(null))
        {
            objectToDisable.SetActive(false); // ปิดการใช้งานวัตถุที่กำหนด
        }
    }
}