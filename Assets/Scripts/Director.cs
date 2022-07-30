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
        print("플레이어가 이겼습니다!");
        Score += 1;
    }

    public void CalcResult(int humanChoice)
    {
        int computerChoice = GetComputerChoice();

        // 무승부
        if(humanChoice == computerChoice)
        {
            print("무승부");
        }
        // 사람이 이길때
        else if (
            (humanChoice == Scissors && computerChoice == Paper)    || 
            (humanChoice == Rock     && computerChoice == Scissors) ||
            (humanChoice == Paper    && computerChoice == Rock)
        )
        {
            HumanWin();
        }
        // 컴퓨터가 이길때
        else
        {
            print("컴퓨터가 이겼습니다!");
            print($"당신의 점수는 {Score} 입니다.");

            // TODO:랭킹표에 정보를 전달
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
