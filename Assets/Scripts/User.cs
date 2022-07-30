using UnityEngine;

public class User : MonoBehaviour
{
    public Director director;

    public void RockClick()
    {
        director.CalcResult(director.Rock);
    }

    public void ScissorsClick()
    {
        director.CalcResult(director.Scissors);
    }

    public void PaperClick()
    {
        director.CalcResult(director.Paper);
    }
}
