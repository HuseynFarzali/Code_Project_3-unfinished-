using Code_Project_3._2.Models.Domain_Models;
using System;
using System.Collections.Generic;

namespace Code_Project_3._2.Models.Abstract_Models
{
    public abstract class Repository<ElementType> where ElementType : IRepositoryElement
    {
        public abstract List<ElementType> GetElements(Predicate<ElementType> criteria);
        public abstract void InsertElement(ElementType element);
        public abstract void DeleteElement(string elementUniqueProp);
        public abstract void UpdateElement(int elementId, ElementType newElementInstance);
    }
}
