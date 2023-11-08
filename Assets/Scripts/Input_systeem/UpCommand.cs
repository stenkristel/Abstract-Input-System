using System;
using UnityEngine;

[Serializable]
public class UpCommand : BaseCommand
{
    public override void Execute() 
    {
            gameObject.transform.position += new Vector3(0, 1, 0);
    }
}
