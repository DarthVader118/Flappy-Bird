using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private int score;

    [HideInInspector]
    public Queue<Transform> pillars;

    [HideInInspector]
    public const float SCREENTOP = 5;

    [HideInInspector]
    public const float SCREENBOTTOM = -5;

    private const float PLAYER_X = 0;



    private void Awake()
    {
        score = 0;
        pillars = new Queue<Transform>();
    }

    private void Update()
    {
        if (pillars.Any() && pillars.Peek().position.x < PLAYER_X)
        {
            score += 1;
            pillars.Dequeue();
        }
    }

    public void endGame()
    {

        pillars.Clear();
        scoreText.text = "Your score was: " + score;
        gameOverScreen.SetActive(true);  
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }
}
