using CatalystCodeGenerator.Interfaces;
using CatalystCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalystCodeGenerator.Services
{
    public class ModelService : IModelService
    {
     
        public Model SetTableModel(string key, string dataType)
        {
            var model = new Model();
            model.Key = key;
            model.DataType = dataType;
            return model;
        }
    }
}
