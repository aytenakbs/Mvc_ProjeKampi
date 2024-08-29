﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        void AddWriter(Writer writer);
        void RemoveWriter(Writer writer);
        void UpdateWriter(Writer writer);
        Writer GetWriterById(int id); 

    }
}
