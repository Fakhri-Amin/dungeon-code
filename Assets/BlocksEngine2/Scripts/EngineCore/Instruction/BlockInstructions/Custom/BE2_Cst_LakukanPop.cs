using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

public class BE2_Cst_LakukanPop : BE2_InstructionBase, I_BE2_Instruction
{
    bool I_BE2_Instruction.ExecuteInUpdate => true;
    bool _firstPlay = true;
    float _timer = 0;
    float _counter = 0;
    bool hasDone;

    public override void OnStackActive()
    {
        _firstPlay = true;
        _timer = 0;
        _counter = 0;
    }

    public new void Function()
    {
        if (_firstPlay)
        {
            _counter = 1;
            _firstPlay = false;
        }

        if (_counter > 0)
        {
            _counter -= Time.deltaTime / 0.3f;

            if (hasDone) return;
            string listName = "Daftar angka";
            BE2_VariablesListManager variableManager = BE2_VariablesListManager.instance;

            var x = variableManager.GetListValue(listName, variableManager.GetListStringValues(listName).Count - 1);
            variableManager.RemoveListItem(listName, variableManager.GetListStringValues(listName).Count - 1);
            BE2_AudioManager.instance.PlaySound(4);
            hasDone = true;
        }
        else
        {
            _counter = 0;
            ExecuteNextInstruction();
            _firstPlay = true;
            hasDone = false;
        }
    }
}
