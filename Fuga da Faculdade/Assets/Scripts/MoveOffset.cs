using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
   private Renderer rend;
   public float speed;

   private float offset;

    void Start()
    {
        rend = GetComponent <Renderer>();
    }

    
    void Update()
    {
        offset = Time.time * speed;

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }
}
