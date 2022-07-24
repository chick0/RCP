using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static string Name;
    public static int Score;

    public readonly int Scissors = 0;
    public readonly int Rock     = 1;
    public readonly int Paper    = 2;

    float time = 0;

    int getComputerChoice()
    {
        return Random.Range(0, 2 + 1);
    }

    void humanWin()
    {
        print("플레이어가 이겼습니다!");
        Director.Score += 1;
    }

    public void CalcResult(int humanChoice)
    {
        int computerChoice = this.getComputerChoice();

        // 무승부
        if(humanChoice == computerChoice)
        {
            print("무승부");
        }
        // 사람이 이길때
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
        // 컴퓨터가 이길때
        else
        {
            print("컴퓨터가 이겼습니다!");
            print($"당신의 점수는 {Director.Score} 입니다.");

            // TODO:랭킹표에 정보를 전달
            Director.Score = 0;
        }
    }

    void UpdateRank()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if(this.time >= (3 * 60))
        {
            this.UpdateRank();
        }
    }
}
