using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public Scroll player;
    public InstantiateObjects iObjects;
    public Transform startPoint;

    public CanvasPanels panels;

    bool gameOverPanel = false;
    bool playing = false;

    float score = 0;
    float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        OpenPanel(panels.mainGroup, true);
        OpenPanel(panels.interfaceGroup, false);
        OpenPanel(panels.gameOverGroup, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EndGame();
            StartGame();
        }
       /* if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }*/

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            if (!gameOverPanel) panels.mainGroupButton.Select();
            else panels.gameOverGroupButton.Select();
        }

        if (playing)
        {
            score += Time.deltaTime;
        }

    }

    public void StartGame()
    {
        if(player != null)
        {
            player.AutoDestruccion();
        }
        player = Instantiate(playerPrefab,startPoint).GetComponent<Scroll>();
        //iObjects.Initialize();
        OpenPanel(panels.mainGroup, false);
        OpenPanel(panels.gameOverGroup, false);
        OpenPanel(panels.interfaceGroup, true);
        panels.mainGroupButton.Select();
        gameOverPanel = false;
        playing = true;
        score = 0;

    }

    public void EndGame()
    {
        if (player != null)
        {
            player.AutoDestruccion();
        }

        OpenPanel(panels.interfaceGroup, false);
        OpenPanel(panels.mainGroup, false);
        OpenPanel(panels.gameOverGroup, true);
        panels.gameOverGroupButton.Select();
        gameOverPanel = true;
        playing = false;
    }

    public void Escape()
    {
        if (player != null)
        {
            player.AutoDestruccion();
        }

        OpenPanel(panels.interfaceGroup, false);
        OpenPanel(panels.gameOverGroup, false);
        OpenPanel(panels.mainGroup, true);
        panels.mainGroupButton.Select();
        gameOverPanel = false;
        playing = false;
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    void OpenPanel(CanvasGroup panel, bool state)
    {
        if (state) panel.alpha = 1;
        else panel.alpha = 0;

        panel.interactable = state;
    }
}

[System.Serializable]
public class CanvasPanels
{
    public CanvasGroup mainGroup;
    public CanvasGroup interfaceGroup;
    public CanvasGroup gameOverGroup;
    public Button mainGroupButton;
    public Button gameOverGroupButton;
}
