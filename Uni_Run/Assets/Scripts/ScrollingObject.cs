using UnityEngine;

// 게임오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            Debug.Log("업데이트if들어옴");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
