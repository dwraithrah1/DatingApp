using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    //static keyword means will not create new instance of extensions when we want to use its methods
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message )
        {
            //when we send an error using this extention, it will have the header: "Application-Error" with the message passed to it
            //the other two headers merely allow the message to be displayed
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}