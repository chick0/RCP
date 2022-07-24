using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Director director;

    public void rockClick()
    {
        this.director.CalcResult(this.director.Rock);
    }

    public void scissorsClick()
    {
        this.director.CalcResult(this.director.Scissors);
    }

    public void paperClick()
    {
        this.director.CalcResult(this.director.Paper);
    }
}
