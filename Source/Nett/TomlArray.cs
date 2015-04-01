﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nett
{
    public class TomlArray : TomlObject
    {
        private readonly List<TomlObject> items = new List<TomlObject>();

        public void Add(TomlObject o)
        {
            this.items.Add(o);
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public TomlObject this[int index]
        {
            get
            {
                return this.items[index];
            }
        }

        public T Get<T>(int index)
        {
            return this.items[index].Get<T>();
        }

        public override T Get<T>()
        {
            return Converter.Convert<T>(this);
        }

        public override object Get(Type t)
        {
            return Converter.Convert(t, this);
        }

        public IEnumerable<T> To<T>()
        {
            return this.items.Select((to) => to.Get<T>());
        }

        public override void WriteTo(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
