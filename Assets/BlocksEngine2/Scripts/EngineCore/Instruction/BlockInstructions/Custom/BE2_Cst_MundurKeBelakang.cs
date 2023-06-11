using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_MundurKeBelakang : BE2_InstructionBase, I_BE2_Instruction
{
    bool I_BE2_Instruction.ExecuteInUpdate => true;
    bool _firstPlay = true;
    float _timer = 0;
    int _counter = 0;
    Vector3 _initialPosition;
    Quaternion _initialRotation;

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

    protected override void OnStart()
    {

    }

    I_BE2_BlockSectionHeaderInput _input0;
    float _value;

    //protected override void OnPlay()
    //{
    //    
    //}

    public new void Function()
    {
        // _input0 = Section0Inputs[0];
        // _value = _input0.FloatValue;
        // StartCoroutine(IterateThroughInput());
        // ExecuteNextInstruction();

        if (_firstPlay)
        {
            _initialPosition = TargetObject.Transform.position;
            _firstPlay = false;
        }

        if (_counter < 1)
        {
            if (_timer <= 1)
            {
                _timer += Time.deltaTime / 0.5f;
                TargetObject.Transform.position = Vector3.Lerp(_initialPosition,
                _initialPosition +
                (-TargetObject.Transform.forward), _timer);
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