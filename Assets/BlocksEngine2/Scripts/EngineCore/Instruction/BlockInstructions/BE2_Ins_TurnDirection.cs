using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

public class BE2_Ins_TurnDirection : BE2_InstructionBase, I_BE2_Instruction
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
            _direction = GetDirection(Section0Inputs[0].StringValue);
            _firstPlay = false;
        }

        if (_counter < 1)
        {
            if (_timer <= 1)
            {
                _timer += Time.deltaTime / 0.2f;

                TargetObject.Transform.rotation = Quaternion.Lerp(_initialRotation, _initialRotation * Quaternion.Euler(_direction.x, _direction.y, _direction.z), _timer);
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

    Vector3 GetDirection(string option)
    {
        // returns the look direction based on the string value
        switch (option)
        {
            case "Kanan":
                return new Vector3(0, 90f, 0);
            case "Kiri":
                return new Vector3(0, -90f, 0);
            default:
                return Vector3.zero;
        }
    }
}
