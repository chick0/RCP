using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public Rank rank;
    public List<RankData> RankTable;

    public static string Name;
    public static int Score;

    public readonly int Scissors = 0;
    public readonly int Rock     = 1;
    public readonly int Paper    = 2;

    readonly float defaultTime = 15;
    float time = 0;

    int GetComputerChoice()
    {
        return Random.Range(0, 2 + 1);
    }

    void HumanWin()
    {
        print("�÷��̾ �̰���ϴ�!");
        Score += 1;
    }

    public void CalcResult(int humanChoice)
    {
        int computerChoice = GetComputerChoice();

        // ���º�
        if(humanChoice == computerChoice)
        {
            print("���º�");
        }
        // ����� �̱涧
        else if (
            (humanChoice == Scissors && computerChoice == Paper)    || 
            (humanChoice == Rock     && computerChoice == Scissors) ||
            (humanChoice == Paper    && computerChoice == Rock)
        )
        {
            HumanWin();
        }
        // ��ǻ�Ͱ� �̱涧
        else
        {
            print("��ǻ�Ͱ� �̰���ϴ�!");
            print($"����� ������ {Score} �Դϴ�.");

            // TODO:��ŷǥ�� ������ ����
            Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = defaultTime;
            StartCoroutine(rank.Pull());
        }
    }
}
