using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCollector.Common
{
    public class Amount
    {
        private bool _isQuantity;
        private decimal _quantity;
        private decimal _start;
        private decimal _end;
        private string _unit;
        private string _size;
        private string _separator;

        private Amount(decimal quantity, string unit = null, string size = null, string separator = null)
        {
            _isQuantity = true;
            _unit = unit;
            _size = size;
            _separator = separator;

        }
        private Amount(decimal start, decimal end, string unit = null, string size = null, string separator = null)
        {
            _isQuantity = false;
            _unit = unit;
            _size = size;
            _separator = separator;
        }

        public decimal Quantity 
        {
            get
            {
                if (!_isQuantity)
                {
                    throw new InvalidOperationException("This amount is a range, not a quantity");
                }
                return _quantity;
            }
        }


        public decimal Start
        {
            get
            {
                if (_isQuantity)
                {
                    throw new InvalidOperationException("This amount is a quantity, not a range");
                }
                return _start;
            }
        }

        public decimal End
        {
            get
            {
                if (_isQuantity)
                {
                    throw new InvalidOperationException("This amount is a quantity, not a range");
                }
                return _end;
            }
        }

    }
}
