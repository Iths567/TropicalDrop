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
    bool parse;
    int score;
    GameObject OldLayer = null;
    #endregion


    //fix side hitbox on platforms


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
        SceneManager.LoadScene(currentLevel); //this will instead cause a menu to appear, on clicking retry the scene will then load
    }
    
    IEnumerator LoadNextLevel()
    {
        Debug.Log("Loading");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Thanks");
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "point") // add 1 to the score when going through points trigger
        {
            score++;
            //destroyLayer(coll.gameObject);
            GameObject.Destroy(coll);
        }

    }

 /*   
  *   This section is not needed as levels are not endless
  *   
  *   private void destroyLayer(GameObject newLayer)
    {
        if (newLayer != OldLayer && OldLayer != null)
        {
            GameObject.Destroy(OldLayer);
            Debug.Log("New layer is not old layer");
            OldLayer = newLayer;
        }
        else
        {
            OldLayer = newLayer;
            Debug.Log("Old layer has been changed");
        }
    }
 */
    private void Update()
    {
        string uiString = score + " points";
        points.text = uiString;
        //update the points text on screen
    }


}
