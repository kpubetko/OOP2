﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Класс Товара
    /// </summary>
    internal class Item
    {
        private static int _count = 0;

        private readonly int _id = _count++;
        private string _name;
        private string _info;
        private float _cost;

        ValueValidator Validator = new ValueValidator();
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Наименование</param>
        /// <param name="info">Описание</param>
        /// <param name="cost">Цена</param>
        public Item(string name, string info, float cost)
        {
            Name = name;
            Info = info;
            Cost = cost;
        }

        /// <summary>
        /// Свойство Id
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Свойство наименования
        /// </summary>
        public string Name
        {
            set
            {
                _name = Validator.AssertStringOnLength(value, 200, Name);
            }
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Свойство описания
        /// </summary>
        public string Info
        {
            set
            {
                _info = Validator.AssertStringOnLength(value, 1000, Info);
            }
            get
            {
                return _info;
            }
        }

        /// <summary>
        /// Свойство цены
        /// </summary>
        public float Cost
        {
            set
            {
                if (value <0 || value > 100000)
                {
                    throw new ArgumentException("Your price is wrong, check it");
                }
                else
                {
                    _cost = value; 
                }
            }
            get
            {
                return _cost;
            }
        }

    }
}