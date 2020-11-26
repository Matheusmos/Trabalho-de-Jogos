using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour
{
    
    public Rigidbody2D playerRigidBody;
    public int forceJump;

    public Animator animator;

    public bool jump, dash;

    public Transform GroundCheck;
    public bool grounded;
    public LayerMask whatIsGround;

    public float dashTemp;
    public float timeTemp;


    public Transform colider;


    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundDash;




    public static int pontuacao;
    public UnityEngine.UI.Text txtPoints;


    void Start()
    {
      pontuacao = 0;
      audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = pontuacao.ToString();
        if(Input.GetButtonDown("Jump") && grounded){
            
            if(dash == false){
                playerRigidBody.AddForce(new Vector2(0,forceJump));
                audio.PlayOneShot(soundJump);
                jump = true;
            }
            
        }
        if(Input.GetButtonDown("Dash") && grounded){
            audio.PlayOneShot(soundDash);
            if(dash == false){
                dash = true;
                timeTemp = 0;
                MoveColider(-0.15f);
        
            }
            }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);

        if(dash){
            timeTemp += Time.deltaTime;
            if(timeTemp >= dashTemp){
                MoveColider(0.15f);
                dash = false;
            }
        }
        animator.SetBool ("Jump", !grounded);
        animator.SetBool ("Dash", dash);
    }

    void MoveColider(float y){
        colider.position = new Vector2(colider.position.x, colider.position.y + y);
    }

    void OnTriggerEnter2D(Collider2D other){
        PlayerPrefs.SetInt("score", pontuacao);

        if(pontuacao > PlayerPrefs.GetInt("record")){
            PlayerPrefs.SetInt("record", pontuacao);
        }
        SceneManager.LoadScene("GameOver");
    }
}
