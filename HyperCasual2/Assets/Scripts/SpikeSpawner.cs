using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Spike[] spikes;
    [SerializeField]
    private float activateX; // ���õ��� Ȱ��ȭ �Ǵ� x ��ġ
    [SerializeField]
    private float deactivateX; // ��Ȱ��ȭ �Ǵ� x ��ġ

    public void ActivateAll()
    {
        // �����ϴ� ������ ����
        int count = Random.Range(1, spikes.Length);
        // �����ϴ� ������ ����
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
