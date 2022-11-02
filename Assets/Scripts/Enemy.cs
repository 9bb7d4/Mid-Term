using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp =  100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            //先取得子彈攻擊力
            Bullet bullet = other.GetComponent<Bullet>();

            hp -= bullet.atk;

            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
       
    }
}
