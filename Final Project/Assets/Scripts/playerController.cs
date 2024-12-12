using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    public MainMenu mainMenu;
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;



    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.pauseGame();
        }
            if(Input.GetKeyDown(KeyCode.Backslash))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision) {   
        

         if(collision.gameObject.CompareTag("Ground"))
         {
            isOnGround = true;
            dirtParticle.Play();
         }

         //this is death
         else if(collision.gameObject.CompareTag("Obstacle"))
         {
            StartCoroutine(handleDeath());
         }

    }

    private IEnumerator handleDeath()
    {
        playerAudio.PlayOneShot(crashSound, 1.0f);
        Debug.Log("Game Over");
        gameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        dirtParticle.Stop();
        
        mainMenu.endScreen();
        Time.timeScale = 0;

        yield return new WaitForSeconds(2f);
        
    }
}

