using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image playerOneHealthBar;
    public float playerOneHealthAmount = 100f;

    public Image playerTwoHealthBar;
    public float playerTwoHealthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerOneTakeDamage(float damage)
    {
        playerOneHealthAmount -= damage;
        playerOneHealthBar.fillAmount = playerOneHealthAmount/100f;
    }

    public void playerTwoTakeDamage(float damage)
    {
        playerTwoHealthAmount -= damage;
        playerTwoHealthBar.fillAmount = playerTwoHealthAmount/100f;
    }

}