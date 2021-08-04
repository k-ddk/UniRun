using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  //싱글턴을 할당할 전역변수

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;

    private int score = 0;

    // 게임 시작과 동시에 싱글턴을 구성
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager가 있다는 뜻
            // 씬에 두개 이상의 게임매니저가 존재하면 안되기 떄문에
            // 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재!");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // 게임 오버상태에서 게임을 재시작할 수 있게 하는 처리
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            // 게임오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
