using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public bool follow;
    public bool die;
    public Zone zone;
    public Transform StartPos;
    public GameObject Player;
    public Weapons weapon;
    private Vector3 ZombieNewPos;
    
    private float speed = 6.0f;
    public bool hit;

    void Update()
    {
        if (zone.PlayerIn)
        {
            ZombieNewPos = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
            
            transform.position = Vector3.MoveTowards(transform.position, ZombieNewPos, speed * Time.deltaTime);
        }
        else if (!zone.PlayerIn)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position , speed * Time.deltaTime);
        }
        if(die&&hit)
        gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            die = true;  
        }
    }


}
