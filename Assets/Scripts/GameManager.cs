using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    public Transform spawnPoint;

    public GameObject currentBall;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        // CreateBall();
    }

    // Update is called once per frame
    public void CreateBall()
    {
        if (currentBall == null)
        {
            ballPrefab.transform.SetParent(spawnPoint.transform.parent);
            currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            currentBall.transform.SetParent(spawnPoint.transform.parent);
        } 
        else {
            currentBall.transform.position = spawnPoint.transform.position;
        }
        
    }
}
