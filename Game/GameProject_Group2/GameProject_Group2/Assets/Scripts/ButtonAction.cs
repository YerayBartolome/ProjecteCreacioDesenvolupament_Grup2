using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ButtonAction
{
    void Action();
    bool State { get; set; }
}
