using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab,player;
    public Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EndGame();
            StartGame();
        }
    }

    public void StartGame()
    {
        player = Instantiate(playerPrefab,startPoint);
    }

    public void EndGame()
    {
        Destroy(player);
    }
}
