using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using System;

public class SceneChange : MonoBehaviour
{
    public GameObject fader;
    public MonoBehaviour scriptableWriter;
    private string currentScene;

    // Start is called before the first frame update
    private void Start()
    {
        fader.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name;
    }
    
    public void nextScene(string sceneName){
        StartCoroutine(FadetoNextScene(sceneName));
    }

    public IEnumerator FadetoNextScene(string sceneName){
        //start timer
        float timer = 0f;
        while(timer < 1){
            //increment timer
            timer += 0.5f;
            yield return new WaitForSeconds(1);
        }
        //done fading to black
        SceneManager.LoadScene(sceneName);
    }
}
