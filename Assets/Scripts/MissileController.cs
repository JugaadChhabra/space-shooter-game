using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{

    public float MissileSpeed = 25f;
    public GameObject Explosion;
    [SerializeField] public GameObject text1;
    [SerializeField] public GameObject text2;


    void Update()
    {
        transform.Translate(Vector3.up * MissileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ScoreManager.score += 1;
            GameObject gm = Instantiate(Explosion, transform.position, transform.rotation);
            GameObject sc = Instantiate(text1, transform.position, transform.rotation);
            Destroy(gm, 2f);
            Destroy(sc, 0.5f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy2")
        {
            ScoreManager.score += 5;
            GameObject gm = Instantiate(Explosion, transform.position, transform.rotation);
            GameObject sc = Instantiate(text2, transform.position, transform.rotation);
            Destroy(gm, 2f);
            Destroy(sc, 0.5f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
