using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject Gun;
    public ZombieAi zombie;
    public Projectile Bullet;
    bool sword;
    bool gun;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                zombie.hit = true;
                animator.SetTrigger("Slash");
                Invoke("resetHit", 0.5f);
            }  
    }

    public void resetHit()
    {
        zombie.hit=false;
    }
   
   
}
