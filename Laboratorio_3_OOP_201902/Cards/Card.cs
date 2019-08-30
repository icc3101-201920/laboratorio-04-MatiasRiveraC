using Laboratorio_3_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_3_OOP_201902.Cards
{
    public abstract class Card
    {
        //Atributos
        protected String name;
        protected EnumType type;
        protected EnumType effect;

        //Constructor
        public Card()
        {

        }

        //Propiedades
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public EnumType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public EnumType Effect
        {
            get
            {
                return this.effect;
            }
            set
            {
                this.effect = value;
            }
        }
        
    }
}
