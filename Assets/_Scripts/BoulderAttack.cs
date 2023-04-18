using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoulderAttack : MonoBehaviour {
    public string mainMenu;
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Here");
            collision.gameObject.transform.Rotate(new Vector3(90,0,0));
            SceneManager.LoadScene(mainMenu);
        }
    }
}
