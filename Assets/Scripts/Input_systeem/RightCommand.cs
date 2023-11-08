using System;
using UnityEngine;

[Serializable]
public class RightCommand : BaseCommand
{
    public override void Execute()
    {
        gameObject.transform.position += new Vector3(1, 0, 0);
    }
}