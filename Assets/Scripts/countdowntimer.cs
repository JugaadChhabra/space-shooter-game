using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdowntimer : MonoBehaviour
{
    // public Text countdowntext;
    public static int CountDown = 1;
    void Start()
    {
       StartCoroutine("countDown");
    }

    void Update()
    {
        // countdowntext.text = CountDown.ToString();
    }

    public IEnumerator countDown()
    {
        while (CountDown > 0)
        {
            CountDown -= 1;
            yield return new WaitForSeconds (1f);
        }
    }
}
