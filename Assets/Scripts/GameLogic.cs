using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private int numBalls;
    private static int score = 0;
    public Text scoreText;

    void Start(){

        if(SceneManager.GetActiveScene().buildIndex == 0){
            score = 0;
        }
        scoreText.text = score.ToString();

    }


    void Update()
    {
        if(numBalls == 0){
            Invoke("StartNextLevel", 3);
        }

    }

    public void BallRemove(){
        numBalls -= 1;
    }

    public void BallAdd(){
        numBalls += 1;
    }

    public void AddScore(){
        score += 1;
        scoreText.text = score.ToString();
    }

    public void DecScore(){
        score -= 1;
        scoreText.text = score.ToString();
    }

    private void StartNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }

}
