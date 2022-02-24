using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CSzafranek_CalculateFactorial.Models
{

    public class CalculateFactorial
    {
        [Key]
        public int FactorialID { get; set;}

        [Display(Name="Number")]
        public double UserNumber { get; set; }

        [Display(Name = "Factorial")]
        public double FactorialAnswer { get; set; }

        public void CalculateUserFactorial()
        {
            FactorialAnswer = 1;

            for (double i = UserNumber; i> 0; i--)
            {
                FactorialAnswer = FactorialAnswer * i;
            }

        }
        public DateTime CreatedAt { get; set; }
    }
}