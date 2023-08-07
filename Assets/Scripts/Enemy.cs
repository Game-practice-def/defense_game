using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPintCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private Movement2D movement2D;

    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        // 적 이동 경로 WayPoints 정보 설정
        wayPintCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPintCount];
        this.wayPoints = wayPoints;

        // 적의 위치를 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        // 적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }
    
    private IEnumerator OnMove()
    {
        NextMoveTo();

        while(true)
        {
            transform.Rotate(Vector3.forward * 10);

            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if(currentIndex < wayPintCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
