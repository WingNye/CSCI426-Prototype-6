using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public List<KeyCode> ActiveKeyCodes;
    public List<KeyCode> KeyCodePossibilities;
    
    [Header("Player One")]
    public KeyCode P1Shoot;
    public KeyCode P1Jump;
    public KeyCode P1MoveLeft;
    public KeyCode P1MoveRight;

    [Header("Player Two")] 
    public KeyCode P2Shoot;
    public KeyCode P2Jump;
    public KeyCode P2MoveLeft;
    public KeyCode P2MoveRight;
    
    void Start()
    {
        ActiveKeyCodes.Add(P1Shoot);
        ActiveKeyCodes.Add(P1Jump);
        ActiveKeyCodes.Add(P1MoveLeft);
        ActiveKeyCodes.Add(P1MoveRight);
        
        ActiveKeyCodes.Add(P2Shoot);
        ActiveKeyCodes.Add(P2Jump);
        ActiveKeyCodes.Add(P2MoveLeft);
        ActiveKeyCodes.Add(P2MoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomizeControls();
            foreach (var VARIABLE in ActiveKeyCodes)
            {
                Debug.Log("Current Keycode for " + VARIABLE);
            }
        }
        
        //TODO: Fill in Movement Functionality

        if (Input.GetKeyDown(P1Jump))
        {
            //Player 1 Jump
        }
        
        if (Input.GetKeyDown(P1Shoot))
        {
            //Player 1 Shoot
        }
        
        if (Input.GetKeyDown(P1MoveLeft))
        {
            //Player 1 Left
        }
        
        if (Input.GetKeyDown(P1MoveRight))
        {
            //Player 1 Right
        }
        
        if (Input.GetKeyDown(P2Jump))
        {
            //Player 2 Jump
        }
        
        if (Input.GetKeyDown(P2Shoot))
        {
            //Player 2 Shoot
        }
        
        if (Input.GetKeyDown(P2MoveLeft))
        {
            //Player 2 Left
        }
        
        if (Input.GetKeyDown(P2MoveRight))
        {
            //Player 2 Right
        }
    }

    void RandomizeControls()
    {
        for (int i = 0; i < ActiveKeyCodes.Count; i++)
        {
            KeyCode temp = KeyCodePossibilities[Random.Range(0, KeyCodePossibilities.Count - 1)];
            while (ActiveKeyCodes.Contains(temp)) //if keycode is already in use, look again.
            {
                temp = KeyCodePossibilities[Random.Range(0, KeyCodePossibilities.Count - 1)]; 
            }

            ActiveKeyCodes[i] = temp;
        }

        P1Shoot = ActiveKeyCodes[0];
        P1Jump = ActiveKeyCodes[1];
        P1MoveLeft = ActiveKeyCodes[2];
        P1MoveRight = ActiveKeyCodes[3];

        P2Shoot= ActiveKeyCodes[4];
        P2Jump = ActiveKeyCodes[5];
        P2MoveLeft= ActiveKeyCodes[6];
        P2MoveRight = ActiveKeyCodes[7];
    }
}
