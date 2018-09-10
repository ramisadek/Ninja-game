using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlComplete : MonoBehaviour {

    [SerializeField] private string newlvl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(newlvl);
            Debug.Log("aaaaaaaaaaaa");
        }
    }
}
