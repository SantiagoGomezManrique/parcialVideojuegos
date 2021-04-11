using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Dangerous?")]
    [SerializeField] public bool isDangerous = false;

    private void Start()
    {
        ChangingColorIfDangerous();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (isDangerous)
            {
                collision.GetComponent<Player>().currentLives--;
            }
            else
            {
                collision.GetComponent<Player>().currentPoints++;
            }


            if (collision.GetComponent<Player>().currentLives == 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
    }

    private void ChangingColorIfDangerous()
    {
        if (isDangerous)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
        }
    }

}
