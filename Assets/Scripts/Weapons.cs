using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Animator animator;
    public ZombieAi zombie;
    [Header("Weapons")]
    [SerializeField] GameObject Sword;
    bool sword;
    [SerializeField] GameObject Gun;
    bool gun;
    public Projectile Bullet;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                zombie.hit = true;              //the player is now attacking and the zombie can be hit
                animator.SetTrigger("Slash");   //trigger player slash animation 
                Invoke("resetHit", 1f);         //reset hit after 0.5 seconds => player is not attacking
            }  
    }

    public void resetHit()
    {
        zombie.hit=false;
    }
   
   
}
