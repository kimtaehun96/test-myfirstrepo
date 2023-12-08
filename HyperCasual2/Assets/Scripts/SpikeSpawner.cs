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


    // 0 ~ maxCount ������ ���� �� ��ġ�� �ʴ� n���� ������ �ʿ��� �� ��� (�˰���)
    private int[] RandomNumerics(int maxCount, int n)
    {
        int[] defaults = new int[maxCount]; // 0 ~ maxCount���� ������� �����ϴ� �迭
        int[] results = new int[n]; // ��� ������ �����ϴ� �迭

        // �迭 ��ü�� 0���� maxCount�� ���� ������� ����
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
