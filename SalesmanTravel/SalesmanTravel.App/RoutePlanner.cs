using System;
using System.Collections.Generic;

namespace SalesmanTravel.App
{
    public class RoutePlanner : IRoutePlanner
    {
        public string Travel(string r, string zipcode)
        {
            string[] addressBook = r.Split(",");

            var zipcodeFound = false;

            List<string> listOfAddresses = new List<string>();
            List<string> listOfHouseNumbers = new List<string>();

            foreach (var address in addressBook)
            {
                string[] wordOrNumbers = address.Split(" ");
                string zipcodeInString = wordOrNumbers[wordOrNumbers.Length - 2] + " " + wordOrNumbers[wordOrNumbers.Length -1];
                if (zipcode.Equals(zipcodeInString))
                {
                    zipcodeFound = true;
                    for (int i = 1; i < wordOrNumbers.Length - 2; i++)
                    {
                        if(i == wordOrNumbers.Length-3)
                        {
                            listOfAddresses.Add(wordOrNumbers[i] + ",");
                            break;
                        }
                        listOfAddresses.Add(wordOrNumbers[i] + " ");
                    }
                    listOfHouseNumbers.Add(wordOrNumbers[0] + ",");
                }
            }           

            if (!zipcodeFound)
            {
                return $"{zipcode}:/";
            }

            string stringOfAddresses = string.Join("", listOfAddresses);
            string stringOfHouseNumbers = string.Join("", listOfHouseNumbers);

            return $"{zipcode}:{stringOfAddresses.Remove(stringOfAddresses.Length - 1)}/{stringOfHouseNumbers.Remove(stringOfHouseNumbers.Length - 1)}"; 
        }
    }
}
