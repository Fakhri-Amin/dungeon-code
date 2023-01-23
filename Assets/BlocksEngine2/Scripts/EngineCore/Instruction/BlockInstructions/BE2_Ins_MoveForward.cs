using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

public class BE2_Ins_MoveForward : BE2_InstructionBase, I_BE2_Instruction
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

        if (_counter < Mathf.Abs(Section0Inputs[0].FloatValue))
        {
            if (_timer <= 1)
            {
                _timer += Time.deltaTime / 0.5f;
                TargetObject.Transform.position = Vector3.Lerp(_initialPosition,
                _initialPosition +
                (TargetObject.Transform.forward * (Section0Inputs[0].FloatValue /
                Mathf.Abs(Section0Inputs[0].FloatValue))), _timer);
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
