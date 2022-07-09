using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    public static class Modifiers
    {
        public static double GetCalsByFlourType(string flourType)
        {
            switch (flourType.ToLower())
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1;
            }
            return 1;
        }

        public static double GetCalsByBakingTechnique(string bakingTechnique)
        {
            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1;
            }

            return 1;
        }

        public static double GetCalsByTopping(string toppingType)
        {
            switch (toppingType.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
            }

            return 1;
        }
    }
}
