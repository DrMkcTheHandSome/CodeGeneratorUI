using CatalystCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalystCodeGenerator.Interfaces
{
    public interface IModelService
    {
        public Model SetTableModel(string key, string dataType);
    }
}
