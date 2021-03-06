﻿using System.Collections.Generic;
using WinDbgDebug.WinDbg.Data;

namespace WinDbgDebug.WinDbg.Visualizers
{
    public interface IVisualizer
    {
        bool CanHandle(VariableMetaData meta);
        VisualizationResult Handle(VariableMetaData meta);
        IEnumerable<VariableMetaData> GetChildren(VariableMetaData meta);
    }
}
