using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialEvent : MonoBehaviour
{
    [SerializeField][TextArea] private string tutorialText;
    [SerializeField] private GameObject tutorialPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (tutorialPanel.activeInHierarchy == false)
            {
                tutorialPanel.SetActive(true);
                tutorialPanel.GetComponentInChildren<TextMeshProUGUI>().text = tutorialText;
            }        
        }
    }

    private void Update()
    {
        StartCoroutine(TutorialRead());
        //Debug.Log(Time.timeScale);
    }

    private IEnumerator TutorialRead()
    {
        //Time.timeScale = 0f;
        bool waitForInput = false;
        yield return new WaitForSecondsRealtime(1f);

        if(Input.anyKeyDown && tutorialPanel.activeInHierarchy == true)
        {       
            waitForInput = true;     
        }

        yield return new WaitUntil(() => waitForInput);
        tutorialPanel.SetActive(false);
        //Time.timeScale = 1f;
    }
}
