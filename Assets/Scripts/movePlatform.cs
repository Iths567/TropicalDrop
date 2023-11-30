using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    #region variables
    GameObject Ground;
    [SerializeField] float moveSpeed = 4f;
    #endregion 


    void Start()
    {
        //gets the ground
        Ground = GameObject.Find("Ground"); 
    }


    void Update()
    {
        //gets the left/right input
        float horizontalInput = Input.GetAxis("Horizontal");

        //moves ground left/right by speed of movespeed and time.
        Ground.transform.Rotate(new Vector3(0, horizontalInput, 0) * moveSpeed * Time.deltaTime);
    }


}
