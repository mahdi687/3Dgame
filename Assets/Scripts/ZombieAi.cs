using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Processors;

public class ZombieAi : MonoBehaviour
{
    //public bool follow;//not used
    //public Transform StartPos;// the start position of the zombie and also to get back to if player in in zone ps:very wrong must be done in a different way
    //public Weapons weapon;// weapon script to check if the zombie is hit    
    //private Vector3 ZombieNewPos;//
    //public Zone zone;//zone script that checks if player is in bounds ps:very wrong must be done in a different way
    //private float speed = 6.0f;
    
    [Header("Global Variables")]
    public Vector3 correction = new Vector3(0f, 1f, 0f);   //correction to the target position    
    public Transform Player;    //player gameobject to follow
    public bool die;
    public bool dead;//check if this zombie is dead
    public bool hit;            //if is true then zombie is dead // used in weapons(sword) script
    public BoxCollider atkCollier;
    public GameObject gameOver;


    private void Awake()
    {
        atkCollier.enabled = false;
        
    }

    void Update()
    {
        distanceCheck();
        if (walk)    //check if player is in distance
        {
            animator.SetBool("isRunning", true);
            zombieMovement();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if(atk)
        {
            atkCollier.enabled = true;
            animator.SetTrigger("Atk");
            Invoke("waitForAtk", 2f);
        }
        death();

        if (dead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    void waitForAtk()
    {
        atkCollier.enabled = false;
        atk = false;
    }

    [Header("Zombie Movement")]
    public Animator animator;   //zombie animation handler
    public float rotationSpeed; //zombie rotaion speed
    public float moveSpeed;     //sombie move speed
    public Vector3 direction;   // vector betwwen zombie and player

    private void zombieMovement()
    {
        //rotate to direction and move to player
        //Rotate towards the player
        Vector3 direction = transform.position - (Player.position + correction);
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, Player.position + correction, moveSpeed * Time.deltaTime);
        
    }

    private void death()
    {
        if (die && hit)         //if zombie is dead and hit by weapon then disactivate the zombie
        {
            animator.SetTrigger("Death");
            Invoke("removeZombie", 3f);
        }
        
    }
    void removeZombie()
    {
        gameObject.SetActive(false);
        Debug.Log("zombie removed");
    }

    [Header("Detection Area")]
    public float maxDistance;
    public float atkDistance;
    public bool atk;
    public bool walk;

    
    void distanceCheck()
    {
        //create a direction to move to the player and check if plyer is in detection zone
        direction = (Player.position + correction) - transform.position;
        float distance = Vector3.Distance(transform.position, Player.position + correction);
        //distance < maxDistance

        if (distance < maxDistance)
        {
            walk = true;
        }
        else walk = false;
        if(distance < atkDistance)
        {
            atk = true;
        }
        else atk = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("weapon"))  //check for collisions with any weapon and if true then set death to true
        {
            die = true;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            dead = true; 
        }
    }

    private void OnDrawGizmos()
    {
        //draw a line from this game object to payer colored red and is masdistance long
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Player.position + correction);

    }
   


}
