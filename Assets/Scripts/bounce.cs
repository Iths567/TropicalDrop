using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class bounce : MonoBehaviour
{
    #region variables
    [SerializeField] float bounciness;
    Rigidbody m_Rigidbody;
    GameObject player;
    string currentLevel;
    [SerializeField] TextMeshProUGUI points;
    int score;

    #endregion


    


    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        m_Rigidbody = GetComponent<Rigidbody>();
        currentLevel = SceneManager.GetActiveScene().name;
        score = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //causes bounce when player collides with normal platform
        if (collision.gameObject.tag == "platform")
        {
            m_Rigidbody.velocity = transform.up * bounciness;
        }
        
        //if a player hits a platform tagged death then DoDeath coroutine will run, this will end the level.
        else if (collision.gameObject.tag == "death")
        {
            StartCoroutine(DoDeath());
        }
        else if (collision.gameObject.tag == "finish")
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator DoDeath()
    {
        GameObject.Destroy(player); // don't necessarily need to destroy player

        
        Debug.Log("Death");
        yield return new WaitForSeconds(1); 
        SceneManager.LoadScene(currentLevel); //this will eventually cause a menu to appear, on clicking retry the scene will then reload and next the next level should load 
    }
    
    IEnumerator LoadNextLevel()
    {
        Debug.Log("Loading");
        yield return new WaitForSeconds(1);
        switch (currentLevel)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                break;
            case "Level2":
                    SceneManager.LoadScene("Thanks");
                break;
        }
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "point") // add 1 to the score when going through points trigger
        {
            score++;
            GameObject.Destroy(coll.gameObject);
        }

    }

    private void Update()
    {
        string uiString = score + " points";
        points.text = uiString;
        //update the points text on screen
    }


}
