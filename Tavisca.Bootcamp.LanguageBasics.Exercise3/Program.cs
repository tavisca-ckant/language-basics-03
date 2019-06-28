using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int len = protein.Length;
            
            // Calculate total calories.
            int [] calories = CalculateCalories (protein, carbs, fat);

            // To store indexes of recommended meal.
            int[] meals = new int[dietPlans.Length];

            // Iterate through diet plans
            for (int i = 0; i < dietPlans.Length; i++) {
                meals[i] = GetIndexOfRecommendedMeal (protein, carbs, fat, calories, dietPlans[i]);
            }

            return meals;
        }

        private static int GetIndexOfRecommendedMeal (int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans)
        {
            string diet = dietPlans;
            List<int> indices = new List<int>();
            indices = AddDefaultIndexes (protein.Length);

            // Iterate through each character in diet plan
            for (int j = 0; j < diet.Length; j++) 
            {             
                indices = IndexesMatchingDietPlan (protein, carbs, fat, calories, diet[j], indices);
                // If length of last indices[] is 1 add that index to meals[] and break;
                if (indices.Count == 1) 
                {
                    return indices[0];
                }
            }
            // add smallest index to meals[]
            return indices[0];
        }

        private static List<int> AddDefaultIndexes (int size)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < size; i++)
            {
                indices.Add (i);
            }
            return indices;
        }

        private static List<int> IndexesMatchingDietPlan (int[] protein, int[] carbs, int[] fat, int[] calories, char diet, List<int> indices)
        {
                switch (diet) 
                {
                    case 'P':  
                            return GetTieIndexes (protein, Max(protein, indices), indices);
                    case 'p':  
                            return GetTieIndexes (protein, Min (protein, indices), indices);
                    case 'C':  
                            return GetTieIndexes (carbs, Max(carbs, indices), indices);
                    case 'c':  
                            return GetTieIndexes (carbs, Min (carbs, indices), indices);
                    case 'F':  
                            return GetTieIndexes (fat, Max(fat, indices), indices);
                    case 'f':  
                            return GetTieIndexes (fat, Min (fat, indices), indices);
                    case 'T':  
                            return GetTieIndexes (calories, Max(calories, indices), indices);
                    case 't':  
                            return GetTieIndexes (calories, Min (calories, indices), indices);
                    default:
                            return indices;
                }
        }

        private static int[] CalculateCalories (int[] protein, int[] carbs, int[] fat)
        {
            int [] calories = new int [protein.Length];
            for (int i = 0; i < protein.Length; i++) 
            {
                calories[i] = ((protein[i] + carbs[i]) * 5) + (fat[i] * 9);
            }  
            return calories;
        }

        private static int Max (int [] arr, List<int> indexes) 
        {
            var max = arr[indexes[0]];
            for (int i = 0; i < indexes.Count; i++) 
            {
                if (max < arr[indexes[i]]) 
                {
                    max = arr[indexes[i]];
                }
            }
            return max;
        }
       
        private static int Min (int [] arr, List<int> indexes) 
        {
            var min = arr[indexes[0]];
            for (int i = 0; i < indexes.Count; i++) 
            {
                if (min > arr[indexes[i]]) 
                {
                    min = arr[indexes[i]];
                }
            }
            return min;
        }

        private static List<int> GetTieIndexes (int[] arr, int value, List<int> indices) 
        {
            var list = new List<int>();
            foreach (int index in indices) 
            {
                if (arr[index] == value) 
                {
                    list.Add (index);
                }
            }
            return list;
        }
    }
}
