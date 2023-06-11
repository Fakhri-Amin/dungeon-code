using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_BalikKanan : BE2_InstructionBase, I_BE2_Instruction
{
    bool I_BE2_Instruction.ExecuteInUpdate => true;
    bool _firstPlay = true;
    float _timer = 0;
    int _counter = 0;
    Vector3 _initialPosition;
    Quaternion _initialRotation;
    Vector3 _direction;

    public override void OnStackActive()
    {
        _firstPlay = true;
        _timer = 0;
        _counter = 0;
    }

    //protected override void OnAwake()
    //{
    //
    //}

    //protected override void OnStart()
    //{
    //    
    //}

    I_BE2_BlockSectionHeaderInput _input0;
    string _value;
    Vector3 _axis = Vector3.up;

    public new void Function()
    {
        if (_firstPlay)
        {
            _initialRotation = TargetObject.Transform.rotation;
            _firstPlay = false;
        }

        if (_counter < 1)
        {
            if (_timer <= 1)
            {
                _timer += Time.deltaTime / 0.2f;

                TargetObject.Transform.rotation = Quaternion.Lerp(_initialRotation, _initialRotation * Quaternion.Euler(0, 180, 0), _timer);
            }
            else
            {
                _timer = 0;
                _counter++;
                _firstPlay = true;
            }
        }
        else
        {
            ExecuteNextInstruction();
            _counter = 0;
            _timer = 0;
            _firstPlay = true;
        }
    }
}
