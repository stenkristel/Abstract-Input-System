using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DownCommand : BaseCommand
{
    public override void Execute()
    {
        gameObject.transform.position += new Vector3(0, -1, 0);
    }
}
