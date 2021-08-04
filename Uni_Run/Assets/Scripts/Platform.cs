using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;
    
    //컴포넌트가 활성화 될 때마다 매번 실행되는 메서드
    private void OnEnable() {
        stepped = false;

        for (int i=0; i < obstacles.Length; i++)
        {
            // 3분의 1확률로 활성화됨 결국 (0, 1, 2 중에서니까)
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision) {
        // 플레이어가 자신을 밟았을 때 점수를 추가하는 처리
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
