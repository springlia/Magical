using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public Transform Player;
    public float magicmoveSpeed;

    public PlayerMove playermove;

    public void Magical()
    {
        gameObject.SetActive(true);
        if (Player != null)
        {
            transform.position = Player.position;
        }
    }
    
    void Update()
    {      
        Vector3 currentPosition = transform.position;
        currentPosition.x += magicmoveSpeed * Time.deltaTime;
        
        // 이동 정지
        if (currentPosition.x >= 20.0f)
        {
            currentPosition.x = 20.0f;
        }
        transform.position = currentPosition;
    }

   
}
