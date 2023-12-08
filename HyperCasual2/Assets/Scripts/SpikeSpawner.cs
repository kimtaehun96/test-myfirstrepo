using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Spike[] spikes;
    [SerializeField]
    private float activateX; // 가시들이 활성화 되는 x 위치
    [SerializeField]
    private float deactivateX; // 비활성화 되는 x 위치

    public void ActivateAll()
    {
        // 등장하는 가시의 개수
        int count = Random.Range(1, spikes.Length);
        // 등장하는 가시의 순번
        int[] numerics = RandomNumerics(spikes.Length, count);

        for(int i = 0; i < numerics.Length; i++)
        {
            spikes[numerics[i]].OnMove(activateX);
        }

    }

    public void DeactivateAll()
    {
        for(int i = 0; i < spikes.Length; i++)
        {
            spikes[i].OnMove(deactivateX);
        }
    }


    // 0 ~ maxCount 까지의 숫자 중 겹치지 않는 n개의 난수가 필요할 때 사용 (알고리즘)
    private int[] RandomNumerics(int maxCount, int n)
    {
        int[] defaults = new int[maxCount]; // 0 ~ maxCount까지 순서대로 저장하는 배열
        int[] results = new int[n]; // 결과 값들을 저장하는 배열

        // 배열 전체에 0부터 maxCount의 값을 순서대로 저장
        for(int i = 0; i < maxCount; i++)
        {
            defaults[i] = i;
        }

        for(int i = 0; i < n; i++)
        {
            int index = Random.Range(0, maxCount);

            results[i] = defaults[index];
            defaults[index] = defaults[maxCount - 1];

            maxCount--;
        }

        return results;
    }

}
