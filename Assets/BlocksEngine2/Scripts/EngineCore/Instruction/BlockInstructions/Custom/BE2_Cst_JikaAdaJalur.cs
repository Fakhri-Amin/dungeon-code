using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_JikaAdaJalur : BE2_InstructionBase, I_BE2_Instruction
{
    bool _isFirstPlay = true;

    protected override void OnButtonStop()
    {
        _isFirstPlay = true;
    }

    public override void OnStackActive()
    {
        _isFirstPlay = true;
    }

    public new void Function()
    {
        if (_isFirstPlay)
        {
            if (TargetObject.GetSidewayInfo(GetDirection(Section0Inputs[0].StringValue)))
            {
                _isFirstPlay = false;
                ExecuteSection(0);
            }
            else
            {
                _isFirstPlay = true;
                ExecuteNextInstruction();
            }
        }
        else
        {
            _isFirstPlay = true;
            ExecuteNextInstruction();
        }
    }

    Vector3 GetDirection(string option)
    {
        // returns the look direction based on the string value
        switch (option)
        {
            case "Ke kanan":
                return TargetObject.Transform.right;
            case "Ke kiri":
                return -TargetObject.Transform.right;
            default:
                return Vector3.zero;
        }
    }
}
