using System;
using UnityEngine;

[Serializable]
public class LeftCommand : BaseCommand
{
    public override void Execute()
    {
        gameObject.transform.position += new Vector3(-1, 0, 0);
    }
}