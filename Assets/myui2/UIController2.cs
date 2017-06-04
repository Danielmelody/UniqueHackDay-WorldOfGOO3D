using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if("Start_menu" == SceneManager.GetActiveScene().name)
        {
            GameObject continueObject = transform.GetChild(1).gameObject;
            continueObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < 3; i++)
                transform.GetChild(i).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //in other scene ,the 'Start 'Button should hide
            if ("Start_menu" == SceneManager.GetActiveScene().name)
                transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                if ("Start" == hit.transform.name)
                    SceneManager.LoadScene("scene1");
                else if ("Continue" == hit.transform.name)
                {
                    for (int i = 0; i < 3; i++)
                        transform.GetChild(i).gameObject.SetActive(false);
                }
                else if ("Return" == hit.transform.name)
                {
                    if ("Start_menu" == SceneManager.GetActiveScene().name)
                        Application.Quit();
                    SceneManager.LoadScene("Start_menu");
                }
            }
        }

    }
}
