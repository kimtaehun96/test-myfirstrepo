using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    [SerializeField]
    private Player player;
    private UIController uiController;
    private int currentSpawn = 0;

    private void Awake()
    {
        uiController = GetComponent<UIController>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.GameStart();
                uiController.GameStart();
                yield break;
            }

            yield return null;
        }
    }

    public void CollisionWithWall()
    {
        // 현재 가시 비활성화 , 반대 방향의 가시 활성화
        UpdatetSpikes();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    } 

    private void UpdatetSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        // currentSpawn에 0과 1을 번갈아가며 넣어줌.
        // idnex = (index + 1) % max 알고리즘 : 0 ~ max - 1 값을 순환
        currentSpawn = (currentSpawn + 1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }

}