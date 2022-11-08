using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp =  100;
    public GameObject target;
    private GameObject focusPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // 找到最近的一個目標 Player 的物件
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        float miniDist = 9999;
        foreach (GameObject player in players)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, player.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusPlayer = player;
            }
        }
        
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        // 調整角色面對方向
        // 判斷方向向量長度是否大於 0.1（代表有輸入）
        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            // 沒有移動輸入，並且有鎖定的敵人，漸漸面向敵人
            if (focusPlayer)
            {
                var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();

            hp -= bullet.atk;

            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
                target.SetActive(false);
                Destroy(target);
            }
        }
       
    }
}
