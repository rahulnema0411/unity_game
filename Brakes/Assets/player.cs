using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int health = 1;
    public GameObject GameOverUI;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameOverUI.SetActive(true);
            car.GetComponent<carCollider>().currentSpeed = 0;
            car.GetComponent<carCollider>().forward = 0;
            car.GetComponent<carCollider>().enabled = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
