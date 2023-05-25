using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissileCount : MonoBehaviour
{

    public TextMeshProUGUI MISSILECOUNT_textholder;
    public static int mcount = 50; 

    void Update()
    {
        MISSILECOUNT_textholder.text = mcount.ToString();
    }
}
