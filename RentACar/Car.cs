//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public string TransmissionType { get; set; }
        public string NumberOfDoors { get; set; }
        public string NumberOfPassengers { get; set; }
        public string TrunkVolume { get; set; }
        public string EngineCapacity { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ModelName { get; set; }
        public string Price { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
