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


    private int[] RandomNumerics(int maxCount, int n)
    {

        return new int[3];
    }

}
