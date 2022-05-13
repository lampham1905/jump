using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isJumpingEnemy = false;
    public bool isShootingEnemy = false;
    public bool isShootingEnemyStop = false;
    public static GameManager instance;
    bool isPaused = false;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    }
    //public int currEndPoint;
    //public GameObject endPointCurrent;
    //public GameObject[] endPoint;
    // Start is called before the first frame update
    void Start()
    {
        //currEndPoint = -1;
        //endPointCurrent = endPoint[currEndPoint];
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndPoint();
    }
    public void CheckEndPoint(){
        //endPointCurrent = endPoint[currEndPoint];
    }
    public void  NextScene(){
        //SceneManager.LoadScene(PlayerController.instance.nextScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerController.instance.canJump = false;
    }
    public void PauseGame(){
        Time.timeScale = 0;
    }
    public void ResumeGame(){
        Time.timeScale = 1;
    }
}
