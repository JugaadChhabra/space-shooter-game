using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI life_holder;
    public static int life = 3;

    void Update()
    {
        life_holder.text = life.ToString();
    }
}
