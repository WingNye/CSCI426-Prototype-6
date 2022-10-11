using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public List<KeyCode> ActiveKeyCodes;
    public List<KeyCode> KeyCodePossibilities;

    public float JumpForce;
    public float MoveSpeed;
    public Bullet bullet;

    [Header("Player One")] 
    public Rigidbody2D PlayerOneRb;
    public KeyCode P1Shoot;
    public KeyCode P1Jump;
    public KeyCode P1MoveLeft;
    public KeyCode P1MoveRight;
    public GameObject P1PewPew;

    public bool P1FacingRight = true;

    [Header("Player Two")] 
    public Rigidbody2D PlayerTwoRb;
    public KeyCode P2Shoot;
    public KeyCode P2Jump;
    public KeyCode P2MoveLeft;
    public KeyCode P2MoveRight;
    public GameObject P2PewPew;
    
    public bool P2FacingRight = true;
    
    
    
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
            PlayerOneRb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
        if (Input.GetKeyDown(P1Shoot))
        {
            Instantiate(bullet, P1PewPew.transform.position, P1PewPew.transform.rotation);
        }
        
        if (Input.GetKey(P1MoveLeft))
        {
            if (P1FacingRight)
            { /*
                Vector3 tempVector = PlayerOneRb.transform.localScale;
                tempVector.x = -1;
                PlayerOneRb.transform.localScale = tempVector;
                P1FacingRight = false;
                */
                PlayerOneRb.transform.rotation = Quaternion.Euler(0,180,0);
                P1FacingRight = false;
            }
            PlayerOneRb.AddForce(Vector2.left * MoveSpeed * 0.1f, ForceMode2D.Impulse);
        }
        
        if (Input.GetKey(P1MoveRight))
        {
            if (!P1FacingRight)
            {
                /*
                Vector3 tempVector = PlayerOneRb.transform.localScale;
                tempVector.x = 1;
                PlayerOneRb.transform.localScale = tempVector;
                P1FacingRight = true;
                */
                PlayerOneRb.transform.rotation = Quaternion.identity;
                P1FacingRight = true;
            }
            PlayerOneRb.AddForce(Vector2.right * MoveSpeed * 0.1f, ForceMode2D.Impulse);
        }
        
        if (Input.GetKeyDown(P2Jump))
        {
            PlayerTwoRb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
        if (Input.GetKeyDown(P2Shoot))
        {
            Instantiate(bullet, P2PewPew.transform.position, P2PewPew.transform.rotation);
        }
        
        if (Input.GetKey(P2MoveLeft))
        {
            if (P2FacingRight)
            {
                /*
                Vector3 tempVector = PlayerTwoRb.transform.rotation;
                tempVector.x = -1;
                PlayerTwoRb.transform.localScale = tempVector;
                P2FacingRight = false;
                */
                PlayerTwoRb.transform.rotation = Quaternion.Euler(0,180,0);
                P2FacingRight = false;
            }
            PlayerTwoRb.AddForce(Vector2.left *MoveSpeed * 0.1f, ForceMode2D.Impulse);
        }
        
        if (Input.GetKey(P2MoveRight))
        {
            if (!P2FacingRight)
            {
                /*
                Vector3 tempVector = PlayerTwoRb.transform.localScale;
                tempVector.x = 1;
                PlayerTwoRb.transform.localScale = tempVector;
                P2FacingRight = true;
                */
                PlayerTwoRb.transform.rotation = Quaternion.identity;
                P2FacingRight = true;
            }
            PlayerTwoRb.AddForce(Vector2.right * MoveSpeed * 0.1f, ForceMode2D.Impulse);
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
