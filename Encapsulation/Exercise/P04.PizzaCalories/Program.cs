using System;
using System.Collections.Generic;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            string[] pizzaInput = Console.ReadLine().Split(" ");

            string name = pizzaInput[1];

            string[] doughInput = Console.ReadLine().Split(" ");

            string flour = doughInput[1];
            string baking = doughInput[2];
            double doughWeight = double.Parse(doughInput[3]);
            
            try
            {
                Dough dough = new Dough(flour, baking, doughWeight);
                Pizza pizza = new Pizza(name, dough);

                string cmd;
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = cmd.Split(" ");
                    
                    string type = toppingInput[1];
                    double weight = double.Parse(toppingInput[2]);
                    Topping topping = new Topping(type, weight);
                    
                    pizza.AddTopping(topping);
                }
                
                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
