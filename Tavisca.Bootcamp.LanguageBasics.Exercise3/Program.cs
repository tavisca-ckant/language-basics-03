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
            int [] calories = new int [len];
            for (int i = 0; i < len; i++) {
                calories[i] = ((protein[i] + carbs[i]) * 5) + (fat[i] * 9);
            }
            // To store indexes of recommended meal.
            int[] meals = new int[dietPlans.Length];
            int max = 0;
            int min = 0;

            // Iterate through diet plans
            for (int i = 0; i < dietPlans.Length; i++) {
                string diet = dietPlans[i];
                List<int> indices = new List<int>();
                // Iterate through each character in diet plan
                for (int j = 0; j < diet.Length; j++) {
                    switch (diet[j]) {
                        case 'P':  
                            // First Iteration
                            if (j == 0) {
                                // Find max value
                                max = Max (protein);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (protein, max);
                            }
                            // Iteration 2 - len
                            else {
                                // Find max value
                                max = Max (protein, indices);
                                // Get index where max values are present.
                                // Update indices []
                                indices = GetTieIndexes (protein, max, indices);
                            }
                            break;
                        case 'p':  
                            // First Iteration
                            if (j == 0) {
                                // Find min value
                                 min = Min (protein);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (protein, min);
                            }
                            // Iteration 2 - len
                            else {
                                // Find min value
                                min = Min (protein, indices);
                                // Get index where min values are present.
                                // Update indices []
                                indices = GetTieIndexes (protein, min, indices);
                            }
                            break;
                        case 'C':
                            // First Iteration
                            if (j == 0) {
                                // Find max value
                                max = Max (carbs);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (carbs, max);
                            }
                            // Iteration 2 - len
                            else { 
                                // Find max value
                                max = Max (carbs, indices);
                                // Get index where max values are present.
                                // Update indices []
                                indices = GetTieIndexes (carbs, max, indices);
                            }
                            break;
                        case 'c':
                            // First Iteration
                            if (j == 0) {
                                // Find min value
                                min = Min (carbs);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (carbs, min);
                            }
                            // Iteration 2 - len
                            else {
                                // Find min value
                                min = Min (carbs, indices);
                                // Get index where min values are present.
                                // Update indices []
                                indices = GetTieIndexes (carbs, min, indices);
                            }
                            break;
                        case 'F':
                            // First Iteration
                            if (j == 0) {
                                // Find max value
                                max = Max (fat);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (fat, max);
                            }
                            // Iteration 2 - len
                            else {
                                // Find max value
                                max = Max (fat, indices);
                                // Get index where max values are present.
                                // Update indices []
                                indices = GetTieIndexes (fat, max, indices);
                            }
                            break;
                        case 'f':
                            // First Iteration
                            if (j == 0) {
                                // Find min value
                                min = Min (fat);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (fat, min);
                            }
                            // Iteration 2 - len
                            else {
                                // Find min value
                                min = Min (fat, indices);
                                // Get index where min values are present.
                                // Update indices []
                                indices = GetTieIndexes (fat, min, indices);
                            }
                            break;
                        case 'T':
                            // First Iteration
                            if (j == 0) {
                                // Find max value
                                max = Max (calories);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (calories, max);
                            }
                            // Iteration 2 - len
                            else {
                                // Find max value
                                max = Max (calories, indices);
                                // Get index where max values are present.
                                // Update indices []
                                indices = GetTieIndexes (calories, max, indices);
                            }
                            break;
                        case 't': 
                            // First Iteration
                            if (j == 0) {
                                // Find min value
                                min = Min (calories);
                                // Get index where max values are present.
                                // Add index to a list.
                                indices = GetTieIndexes (calories, min);
                            }
                            // Iteration 2 - len
                            else {
                                // Find min value
                                min = Min (calories, indices);
                                // Get index where min values are present.
                                // Update indices []
                                indices = GetTieIndexes (calories, min, indices);
                            }
                            break;
                    }
                    // Find length of last indices[]
                    // If 1 add that index to meals[] and break;
                    if (indices.Count == 1) {
                        meals[i] = indices[0];
                        break;
                    }
                }
                // add smallest index to meals[]
                // Console.WriteLine (indices.Count + "");
                if (indices.Count > 1) {
                    meals[i] = indices[0];
                }
            }

            return meals;
        } // End of SelectMeals method.

        // Helper methods
        static int Max (int [] arr) {
            var max = arr[0];
            for (int i = 1; i < arr.Length; i++) {
                if (max < arr[i]) {
                    max = arr[i];
                }
            }
            return max;
        }
        static int Max (int [] arr, List<int> indexes) {
            var max = arr[indexes[0]];
            for (int i = 0; i < indexes.Count; i++) {
                if (max < arr[indexes[i]]) {
                    max = arr[indexes[i]];
                }
            }
            return max;
        }
        static int Min (int [] arr) {
            var min = arr[0];
            for (int i = 1; i < arr.Length; i++) {
                if (min > arr[i]) {
                    min = arr[i];
                }
            }
            return min;
        }
        static int Min (int [] arr, List<int> indexes) {
            var min = arr[indexes[0]];
            for (int i = 0; i < indexes.Count; i++) {
                if (min > arr[indexes[i]]) {
                    min = arr[indexes[i]];
                }
            }
            return min;
        }
        static List<int> GetTieIndexes (int[] arr, int value) {
            var list = new List<int>();
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == value) {
                    list.Add (i);
                }
            }
            return list;
        }
        static List<int> GetTieIndexes (int[] arr, int value, List<int> indices) {
            var list = new List<int>();
            foreach (int index in indices) {
                if (arr[index] == value) {
                    list.Add (index);
                }
            }
            return list;
        }
    }
}
