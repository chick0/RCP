using System.Collections;
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

    int getComputerChoice()
    {
        return Random.Range(0, 2 + 1);
    }

    void humanWin()
    {
        print("�÷��̾ �̰���ϴ�!");
        Director.Score += 1;
    }

    public void CalcResult(int humanChoice)
    {
        int computerChoice = this.getComputerChoice();

        // ���º�
        if(humanChoice == computerChoice)
        {
            print("���º�");
        }
        // ����� �̱涧
        else if (humanChoice == Scissors && computerChoice == Paper)
        {
            this.humanWin();
        }
        else if(humanChoice == Rock && computerChoice == Scissors)
        {
            this.humanWin();
        }
        else if(humanChoice == Paper && computerChoice == Rock)
        {
            this.humanWin();
        }
        // ��ǻ�Ͱ� �̱涧
        else
        {
            print("��ǻ�Ͱ� �̰���ϴ�!");
            print($"����� ������ {Director.Score} �Դϴ�.");

            // TODO:��ŷǥ�� ������ ����
            Director.Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if(this.time <= 0)
        {
            this.time = this.defaultTime;
            StartCoroutine(this.rank.Pull());
        }
    }
}
