using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {
    float timer = 0;

    private void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene("MainMenu");

        timer += Time.deltaTime;

        if(timer > 10)
            SceneManager.LoadScene("MainMenu");
    }

}
