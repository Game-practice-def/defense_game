using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;

    public void Setup(Transform target)
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
    }

    void Update()
    {
        if (target != null)     // target이 존재하면
        {
            // 발차세를 target의 위치로 이동
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
           
        else                    // 여러 이유로 target이 사라지면
        {
            // 발사체 오브젝트 삭제
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy")) { return; }
        if(collision.transform != target) { return; }

        collision.GetComponent<Enemy>().OnDie();
        Destroy(gameObject);
    }
}


/*
 * File : Projectile.cs
 * Desc
 *  : 타워가 발사하는 기본 발사체에 부착
 *  
 * Function
 *  : OnTriggerEnter2D() - 타켁으로 설정된 적과 부딪혔을 때 둘다 삭제
 * 
 */