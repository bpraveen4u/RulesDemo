using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.StoreExample
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer);
    }

    public class FirstTimeCustomerRule: IDiscountRule
    {

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {
                return 0;
            }
            else
            {
                return 0.15m;
            }
        }
    }

    public class SeniorRule : IDiscountRule
    {

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return 0.05m;
            }
            return 0;
        }
    }

    public class VetaranRule : IDiscountRule
    {

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.IsVetaran)
            {
                return 0.1m;
            }
            else
                return 0;
            {
            }
        }
    }

    public class LoyalCustomerRule : IDiscountRule
    {
        private readonly decimal _discount;
        private readonly int _yearsAsCustomer;

        public LoyalCustomerRule(int yearsAsCustomer, decimal discount)
        {
            this._discount = discount;
            this._yearsAsCustomer = yearsAsCustomer;
        }

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value.AddYears(_yearsAsCustomer) <= DateTime.Today)
                {
                    var birthDayRule = new BirthDayDiscountRule();
                    return _discount + birthDayRule.CalculateDiscount(customer);
                }
            }
            return 0;
        }
    }


    public class BirthDayDiscountRule : IDiscountRule
    {

        public decimal CalculateDiscount(Customer customer)
        {
            if (customer.DateOfBirth.Month == DateTime.Now.Month && customer.DateOfBirth.Day == DateTime.Now.Day)
            {
                return 0.10m;
            }
            return 0;
        }
    }

    public class DiscountCalculator
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();

        public DiscountCalculator()
        {
            _rules.Add(new BirthDayDiscountRule());
            _rules.Add(new FirstTimeCustomerRule());
            _rules.Add(new SeniorRule());
            _rules.Add(new LoyalCustomerRule(1, .10m));
            _rules.Add(new LoyalCustomerRule(5, .12m));
            _rules.Add(new LoyalCustomerRule(12, .20m));
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;

            foreach (var rule in _rules)
            {
                discount = Math.Max(rule.CalculateDiscount(customer), discount);
            }

            return discount;
        }
    }
}
