using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;
    public GameObject gamemanager;
    public float speed;

   void Update()
   {
       transform.Translate(Vector3.up * speed * Time.deltaTime);
   }
}