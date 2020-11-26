using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;

    private float x;


    private GameObject Player;
    private bool pont;

    void Start()
    {
        Player = GameObject.Find("Player") as GameObject;
    }

  
    void Update()
    {
       x = transform.position.x;
       x -= speed * Time.deltaTime; 
       transform.position = new Vector2(x, transform.position.y);

        if((x < Player.transform.position.x) && pont == false ){
            pont = true;
            PlayerControler.pontuacao++;
        }
        
       if(x <= -3){
           Destroy(transform.gameObject);
       }
    }
}
