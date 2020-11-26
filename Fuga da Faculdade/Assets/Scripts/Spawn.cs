using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private int posicao;
    private float y;
    
    public GameObject Bomba;
    public float rateSpawn;

    public float currentTime;

    void Start()
    {
        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if(currentTime >= rateSpawn){

            posicao = Random.Range(1,100);
            if(posicao > 50){
                y = -0.250f;
                GameObject tempPrefab = Instantiate(Bomba) as GameObject;
                tempPrefab.transform.position = new Vector2(transform.position.x, y);
       
            }else{
                y = -0.100f;
                GameObject tempPrefab = Instantiate(Bomba) as GameObject;
                tempPrefab.transform.position = new Vector2(transform.position.x, y);
       
            }
            currentTime = 0;
             }
    }
}
