using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_4
{
    class ElectronicsStore
    {
        public static ElectronicsStore operator +(ElectronicsStore FirstApplicant, ElectronicsStore SecondApplicant)
        {
            return new ElectronicsStore
            { PriceOfProduct = FirstApplicant.PriceOfProduct + SecondApplicant.PriceOfProduct };
      
        }
        public static ElectronicsStore operator -(ElectronicsStore FirstApplicant, ElectronicsStore SecondApplicant)
        {
            return new ElectronicsStore
            { PriceOfProduct = FirstApplicant.PriceOfProduct - SecondApplicant.PriceOfProduct };

        }

        private string nameOfProduct;
        public string NameOfProduct
        {
            get
            {
                if (nameOfProduct.Length >1 && !String.IsNullOrEmpty(nameOfProduct))
                {
                    return nameOfProduct;
                }
                else
                {
                    return "Check the validity of entered name";
                }
            }
            set
            {
               
                    nameOfProduct = value;
                
                
            }
        }
        public double PriceOfProduct { get; set; }
        public int CountOfCurrentProduct;
        public int HowManySold { get; set; }
        public ElectronicsStore(string _nameOfProduct="No Data", double _priceOfProduct=0, int _CountOfCurrentProduct=0, int _HowManySold=0)
        {
            NameOfProduct = _nameOfProduct;
            PriceOfProduct = _priceOfProduct;
            CountOfCurrentProduct = _CountOfCurrentProduct;
            HowManySold = _HowManySold;
        }
        public override string ToString()
        {
            return $"Object : {base.ToString()} , Name : {NameOfProduct} , Price : {PriceOfProduct} , Count : {CountOfCurrentProduct} , Sold Products : {HowManySold}";
        }

    }
}
