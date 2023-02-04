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
    public new void Function()
    {
        string listName = "Daftar angka";
        BE2_VariablesListManager variableManager = BE2_VariablesListManager.instance;
        variableManager.RemoveListItem(listName, variableManager.GetListStringValues(listName).Count - 1);
        ExecuteNextInstruction();
    }
}
