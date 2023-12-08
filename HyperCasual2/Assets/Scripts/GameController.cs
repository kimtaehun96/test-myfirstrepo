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
        // ���� ���� ��Ȱ��ȭ , �ݴ� ������ ���� Ȱ��ȭ
        UpdatetSpikes();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    } 

    private void UpdatetSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        // currentSpawn�� 0�� 1�� �����ư��� �־���.
        // idnex = (index + 1) % max �˰��� : 0 ~ max - 1 ���� ��ȯ
        currentSpawn = (currentSpawn + 1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }

}