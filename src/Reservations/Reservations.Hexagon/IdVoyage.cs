using System;
using System.Collections.Generic;
using Shared.Core.DomainModeling;

namespace Reservations.Hexagon
{
    public class IdVoyage : Id<int>
    {
        public IdVoyage(int internalValue) : base(internalValue) { }
    }
    
    public class CodePostal : StringBasedValueObject
    {
        public CodePostal(string internalValue) : base(internalValue)
        {
        }
    }
}