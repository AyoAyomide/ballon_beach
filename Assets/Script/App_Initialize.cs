using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class App_Initialize : MonoBehaviour
{
    public GameObject onStartUI;
    public GameObject onPlayUI;
    public GameObject onOverUI;
    public GameObject player;
    public GameObject adButton;
    public GameObject restartButton;
    private bool hasGameStarted = false;
    private bool hasSeenRewardedAds = false;

    void Awake() {
        Shader.SetGlobalFloat("_Curvature",2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
        restartButton.GetComponent<Animator>().enabled = false;
    }

    void Start() {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        onStartUI.gameObject.SetActive(true);
        onPlayUI.gameObject.SetActive(false);
        onOverUI.gameObject.SetActive(false);
    }

    public void PlayGame(){
        if(hasGameStarted == true)
        { 
            StartCoroutine(StartGame(1.0f));
        }
        else{
            StartCoroutine(StartGame(0.0f));
        }
    }

    public void PauseGame(){
        hasGameStarted = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        onStartUI.gameObject.SetActive(true);
        onPlayUI.gameObject.SetActive(false);
        onOverUI.gameObject.SetActive(false);
    }

    public void GameOver(){
        hasGameStarted = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        onStartUI.gameObject.SetActive(false);
        onPlayUI.gameObject.SetActive(false);
        onOverUI.gameObject.SetActive(true);

        if(hasSeenRewardedAds == true){
            adButton.GetComponent<Image>().color = new Color (1,1,1,0.5f);
            adButton.GetComponent<Button>().enabled = false;
            adButton.GetComponent<Animator>().enabled = false;
            restartButton.GetComponent<Animator>().enabled = true;
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }

    public void ShowAds(){
        hasSeenRewardedAds = true;
        StartCoroutine(StartGame(1.0f));
    }

    IEnumerator StartGame(float waitTime){
        onStartUI.gameObject.SetActive(false);
        onPlayUI.gameObject.SetActive(true);
        onOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
